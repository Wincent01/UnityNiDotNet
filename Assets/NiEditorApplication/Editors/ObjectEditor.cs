using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Fdb.Database;
using Fdb.Enums;
using Fdb.Object;
using NIF;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NiEditorApplication.Editor
{
    public class ObjectEditor : NiEditor
    {
        public static FdbObject Object;

        public static Table ComponentsTable;

        public static Table LootMatrixDbTable;

        public static Table LootDbTable;

        public static Table ObjectTable;

        public static ObjectEditor Singleton;

        [Header("Header Buttons")]
        public Button OpenButton;
        public Button NewButton;
        public Button SeekRowButton;

        [Header("Components")] public TextMeshProUGUI ComponentsTitle;

        [Header("Component Prefabs")] public GameObject ComponentPrefab;
        public RectTransform ComponentParent;

        [Header("Macros")] public GameObject Health;
        public GameObject Armor;
        public GameObject Imagination;
        public GameObject ItemDropPrefab;
        public TMP_InputField NameUs;
        public TMP_InputField NameGb;
        public TMP_InputField NameDe;
        public RectTransform ItemDropParent;
        public Button AddLootButton;

        [Header("Visual")] public RawImage Icon;

        [Header("Images")] public Sprite AddImage;
        public Sprite RemoveImage;

        [Header("Object Input")] public GameObject ObjectInput;
        public TMP_InputField ObjectIdInput;
        public Button SubmitObjectIdButton;

        private Vector3 _pullPosition;

        private int _lootSeekIndex;

        private readonly List<GameObject> _onReloadComponents = new List<GameObject>();

        private readonly List<GameObject> _onReloadItems = new List<GameObject>();

        private void Awake()
        {
            Singleton = this;

            SubmitObjectIdButton.onClick.AddListener(LoadObject);

            OpenButton.onClick.AddListener(OpenObject);
            
            NewButton.onClick.AddListener(() =>
            {
                if (ObjectTable == default) ObjectTable = FdbEditor.Database.Tables.First(t => t.Name == "Objects");
                
                var newLot = ObjectTable.Rows.Select(r => new Objects(r).id).Max() + 1;

                var row = new Objects(NewRow(ObjectTable)) {id = newLot, localize = true};

                LoadComponents(row.id);
            });

            SeekRowButton.onClick.AddListener(() =>
            {
                FdbEditor.Singleton.SeekRow(ObjectTable,
                    ObjectTable.Rows.First(r => (int) r.Fields[0].Value == Object.Lot));
                FdbEditor.Singleton.Activate();
            });
        }

        private void Update()
        {
            SeekRowButton.interactable = Object != default;
        }

        private void OpenObject()
        {
            RaycastCover.SetActive(true);
            ObjectInput.SetActive(true);
        }

        private void LoadObject()
        {
            LoadComponents(int.Parse(ObjectIdInput.text));
        }

        private void LoadComponents(int objectId)
        {
            if (ObjectTable == default) 
                ObjectTable = FdbEditor.Database.Tables.First(t => t.Name == "Objects");
            
            if (ComponentsTable == default)
                ComponentsTable = FdbEditor.Database.Tables.First(t => t.Name == "ComponentsRegistry");

            if (LootMatrixDbTable == default)
                LootMatrixDbTable = FdbEditor.Database.Tables.First(t => t.Name == "LootMatrix");

            if (LootDbTable == default)
                LootDbTable = FdbEditor.Database.Tables.First(t => t.Name == "LootTable");

            foreach (var reloadComponent in _onReloadComponents)
            {
                Destroy(reloadComponent);
            }

            foreach (var reloadItem in _onReloadItems)
            {
                Destroy(reloadItem);
            }

            _onReloadComponents.Clear();
            _onReloadItems.Clear();

            Object = new FdbObject(objectId);

            ApplicationTitle.text = $"Object Editor - {objectId}";

            var components = ComponentsTable.Rows.Where(r => (int) r.Fields[0].Value == objectId).ToArray();

            ComponentsTitle.text = $"{components.Length} Component" + (components.Length > 1 ? "s" : "");

            var allComponents = Enum.GetValues(typeof(ReplicaComponentsId));

            ComponentParent.sizeDelta =
                new Vector2(0, 20 * (allComponents.Length + 1) + (float) (ComponentParent.sizeDelta.y / 4d));

            int visualIndex = default;
            foreach (var registryComponent in components)
            {
                var id = (ReplicaComponentsId) (int) registryComponent.Fields[1].Value;

                var instance = Instantiate(ComponentPrefab, ComponentParent, true);

                instance.SetActive(true);

                instance.name = id.ToString();

                instance.transform.position -= new Vector3(0, 20, 0) * visualIndex++;

                instance.GetComponentInChildren<TextMeshProUGUI>().text = id.ToString();

                var extendedButton = instance.AddComponent<ExtendedButton>();

                extendedButton.MiddleClick += () =>
                {
                    Object.DeleteComponent(id);
                    LoadComponents(Object.Lot);
                };

                instance.GetComponentsInChildren<Image>().First(c => c.name == "Image").sprite = RemoveImage;

                _onReloadComponents.Add(instance);

                var table = FdbEditor.Database.Tables.FirstOrDefault(t => t.Name == id.ToString());

                Row componentRow = default;

                if (table != default)
                {
                    var component = registryComponent;
                    componentRow = table.Rows.FirstOrDefault(r =>
                        (int) r.Fields[0].Value == (int) component.Fields[2].Value
                    );

                    extendedButton.LeftClick += () =>
                    {
                        FdbEditor.Singleton.SeekRow(table, componentRow);
                        FdbEditor.Singleton.Activate();
                    };
                }

                var objComp = new ObjectComponent
                {
                    ComponentType = id,
                    RegistryRow = registryComponent,
                    ComponentRow = componentRow
                };

                Object.Components.Add(objComp);
            }

            visualIndex++;

            foreach (ReplicaComponentsId comp in allComponents)
            {
                if (Object.Components.Any(c => c.ComponentType == comp)) continue;

                var instance = Instantiate(ComponentPrefab, ComponentParent, true);

                instance.SetActive(true);

                instance.name = comp.ToString();

                instance.transform.position -= new Vector3(0, 20, 0) * visualIndex++;

                instance.GetComponentInChildren<TextMeshProUGUI>().text = comp.ToString();

                instance.GetComponentsInChildren<Image>().First(c => c.name == "Image").sprite = AddImage;

                instance.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Object.AddComponent(comp);
                    LoadComponents(Object.Lot);
                });

                _onReloadComponents.Add(instance);
            }

            LoadStats();
            LoadXml();

            RaycastCover.SetActive(false);
            ObjectInput.SetActive(false);
        }

        private void LoadStats()
        {
            var healthInput = Health.GetComponentInChildren<TMP_InputField>();
            var armorInput = Armor.GetComponentInChildren<TMP_InputField>();
            var imaginationInput = Imagination.GetComponentInChildren<TMP_InputField>();

            healthInput.text = "";
            armorInput.text = "";
            imaginationInput.text = "";
            healthInput.onEndEdit.RemoveAllListeners();
            armorInput.onEndEdit.RemoveAllListeners();
            imaginationInput.onEndEdit.RemoveAllListeners();
            healthInput.interactable = false;
            armorInput.interactable = false;
            imaginationInput.interactable = false;

            var destroyableComponent = Object.Components.FirstOrDefault(
                c => c.ComponentType == ReplicaComponentsId.DestructibleComponent
            );

            if (destroyableComponent != default)
            {
                var comp = new DestructibleComponent(destroyableComponent.ComponentRow);

                try
                {
                    healthInput.text = comp.life.ToString();
                }
                catch
                {
                    healthInput.text = "0";
                }

                try
                {
                    armorInput.text = comp.armor.ToString(CultureInfo.CurrentCulture);
                }
                catch
                {
                    armorInput.text = "0";
                }

                try
                {
                    imaginationInput.text = comp.imagination.ToString();
                }
                catch
                {
                    imaginationInput.text = "0";
                }

                healthInput.onEndEdit.AddListener(s => { comp.life = int.Parse(s); });
                armorInput.onEndEdit.AddListener(s => { comp.armor = int.Parse(s); });
                imaginationInput.onEndEdit.AddListener(s => { comp.imagination = int.Parse(s); });

                healthInput.interactable = true;
                armorInput.interactable = true;
                imaginationInput.interactable = true;

                SetupLoot(comp.LootMatrixIndex);
            }

            var rebuildComponent = Object.Components.FirstOrDefault(
                c => c.ComponentType == ReplicaComponentsId.RebuildComponent
            );

            AddLootButton.interactable = destroyableComponent != default;

            if (rebuildComponent == default || destroyableComponent != default) return;
            {
                var comp = new RebuildComponent(rebuildComponent.ComponentRow);
                imaginationInput.text = comp.take_imagination.ToString();
                imaginationInput.onEndEdit.AddListener(s => { comp.take_imagination = int.Parse(s); });

                imaginationInput.interactable = true;
            }
        }

        private void LoadXml()
        {
            var nameUs = LocaleEditor.GetObjectName(Object.Lot);
            var nameGb = LocaleEditor.GetObjectName(Object.Lot, Locale.GreatBritain);
            var nameDe = LocaleEditor.GetObjectName(Object.Lot, Locale.Germany);

            NameUs.text = nameUs ?? "";
            NameGb.text = nameGb ?? "";
            NameDe.text = nameDe ?? "";
            
            NameUs.onEndEdit.RemoveAllListeners();
            NameGb.onEndEdit.RemoveAllListeners();
            NameDe.onEndEdit.RemoveAllListeners();

            NameUs.onEndEdit.AddListener(s =>
            {
                LocaleEditor.SetObjectName(Object.Lot, s);
                
                var row = ObjectTable.Rows.First(o => (int) o.Fields[0].Value == Object.Lot);
                row.Fields[1].Value = s;
                row.Fields[1].DataType = DataType.Text;
            });
            
            NameGb.onEndEdit.AddListener(s => { LocaleEditor.SetObjectName(Object.Lot, s, Locale.GreatBritain); });
            NameDe.onEndEdit.AddListener(s => { LocaleEditor.SetObjectName(Object.Lot, s, Locale.Germany); });
        }

        private void SetupVisual()
        {
            var renderComponent = Object.Components.FirstOrDefault(
                c => c.ComponentType == ReplicaComponentsId.RenderComponent
            );

            if (renderComponent == default) return;

            try
            {
                var managed = new RenderComponent(renderComponent.ComponentRow);

                var nifPath = Path.Combine(FdbEditor.RecurseFolder, managed.render_asset.Replace('\\', '/').ToLower());

                Debug.Log(nifPath);
                if (nifPath.EndsWith("kfm")) return;
                
                var nifRuntime = NifRuntime.FromFile(nifPath, out var gm);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        private void SetupLoot(int lootMatrixIndex)
        {
            var lootMatrices = LootMatrixDbTable.Rows
                .Where(r => (int) r.Fields[0].Value == lootMatrixIndex).Select(r => new LootMatrix(r))
                .ToArray();

            foreach (var reloadItem in _onReloadItems)
            {
                Destroy(reloadItem);
            }

            _onReloadItems.Clear();

            AddLootButton.onClick.RemoveAllListeners();
            
            AddLootButton.onClick.AddListener(AddDrop);

            float visualIndex = default;

            foreach (var lootMatrix in lootMatrices)
            {
                var loots = LootDbTable.Rows.Where(r => (int) r.Fields[1].Value == lootMatrix.LootTableIndex)
                    .Select(r => new LootTable(r)).ToArray();

                foreach (var loot in loots)
                {
                    var instance = Instantiate(ItemDropPrefab, ItemDropParent);

                    instance.SetActive(true);

                    var id = instance.GetComponentsInChildren<TextMeshProUGUI>().First(t => t.gameObject.name == "Id");

                    id.text = loot.itemid.ToString();

                    var extended = id.transform.parent.gameObject.AddComponent<ExtendedButton>();

                    var loot1 = loot;
                    extended.LeftClick += () =>
                    {
                        FdbEditor.Singleton.SeekRow(LootDbTable, loot1.DatabaseRow);
                        FdbEditor.Singleton.Activate();
                    };

                    extended.MiddleClick += () => { LoadComponents(loot.itemid); };

                    instance.GetComponentsInChildren<Button>().First(b => b.gameObject.name == "Image").onClick
                        .AddListener(() =>
                        {
                            FdbEditor.Singleton.SeekRow(LootMatrixDbTable, lootMatrix.DatabaseRow);
                            FdbEditor.Singleton.Activate();
                        });

                    var inputs = instance.GetComponentsInChildren<TMP_InputField>();

                    var dropRate = inputs.First(d => d.gameObject.name == "DropRate");
                    var minRate = inputs.First(d => d.gameObject.name == "MinDrop");
                    var maxRate = inputs.First(d => d.gameObject.name == "MaxDrop");

                    dropRate.text = lootMatrix.percent.ToString(CultureInfo.CurrentCulture);
                    minRate.text = lootMatrix.minToDrop.ToString();
                    maxRate.text = lootMatrix.maxToDrop.ToString();

                    {
                        dropRate.onEndEdit.AddListener(s =>
                        {
                            lootMatrix.percent = float.Parse(s.Replace('.', ','));
                            SetupLoot(lootMatrixIndex);
                        });

                        minRate.onEndEdit.AddListener(s =>
                        {
                            lootMatrix.minToDrop = int.Parse(s);
                            SetupLoot(lootMatrixIndex);
                        });

                        maxRate.onEndEdit.AddListener(s =>
                        {
                            lootMatrix.maxToDrop = int.Parse(s);
                            SetupLoot(lootMatrixIndex);
                        });
                    }

                    instance.transform.localPosition =
                        new Vector3(0, -32 * visualIndex++, 0);

                    _onReloadItems.Add(instance);
                }

                visualIndex += .5f;
            }

            ItemDropParent.sizeDelta = new Vector2(ItemDropParent.sizeDelta.x, visualIndex * 32);
        }

        private void AddDrop()
        {
            Debug.Log("Adding Drop...");

            var destroyableComponent = Object.Components.First(
                c => c.ComponentType == ReplicaComponentsId.DestructibleComponent
            );

            var comp = new DestructibleComponent(destroyableComponent.ComponentRow);

            var matrix = NewRow(LootMatrixDbTable);

            LootMatrixDbTable.AppendRow(matrix);

            var managedMatrix = new LootMatrix(matrix)
            {
                LootMatrixIndex = comp.LootMatrixIndex,
                id = LootMatrixDbTable.Rows.Select(r => (int) r.Fields[6].Value).Max() + 1,
                percent = 100,
                minToDrop = 1,
                maxToDrop = 1
            };

            var lootIndex = LootDbTable.Rows.Select(r => (int) r.Fields[1].Value).Max() + 1;

            managedMatrix.LootTableIndex = lootIndex;

            var loot = NewRow(LootDbTable);

            LootDbTable.AppendRow(loot);

            var managedLoot = new LootTable(loot)
            {
                LootTableIndex = lootIndex,
                id = LootDbTable.Rows.Select(r => (int) r.Fields[2].Value).Max() + 1
            };

            SetupLoot(comp.LootMatrixIndex);
        }
    }
}