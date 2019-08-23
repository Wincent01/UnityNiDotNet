using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Fdb.Database;
using Fdb.Object;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NiEditorApplication.Fdb
{
    public class ObjectEditor : NiEditor
    {
        public static FdbObject Object;

        public static Table ComponentsTable;

        public static Table LootMatrixDbTable;
        
        public static Table LootDbTable;

        public static ObjectEditor Singleton;
        
        [Header("Header Buttons")]
        public Button OpenButton;
        public Button SaveButton;
        
        [Header("Components")]
        public TextMeshProUGUI ComponentsTitle;

        [Header("Component Prefabs")]
        public GameObject ComponentPrefab;
        public RectTransform ComponentParent;

        [Header("Macros")]
        public GameObject Health;
        public GameObject Armor;
        public GameObject Imagination;
        public GameObject ItemDropPrefab;
        public RectTransform ItemDropParent;
        
        [Header("Images")]
        public Sprite AddImage;
        public Sprite RemoveImage;

        [Header("Object Input")]
        public GameObject ObjectInput;
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
        }

        public void Update()
        {
            SaveButton.interactable = Object != default;
        }

        private void OpenObject()
        {
            RaycastCover.SetActive(true);
            ObjectInput.SetActive(true);
        }

        private void LoadObject()
        {
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

            var objectId = int.Parse(ObjectIdInput.text);

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
                    LoadObject();
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
                    LoadObject();
                });

                _onReloadComponents.Add(instance);
            }

            LoadStats();

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
                Debug.Assert(destroyableComponent.ComponentRow != default);
                var comp = new DestructibleComponent(destroyableComponent.ComponentRow);
                healthInput.text = comp.life.ToString();
                armorInput.text = comp.armor.ToString(CultureInfo.CurrentCulture);
                imaginationInput.text = comp.imagination.ToString();
                
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

            if (rebuildComponent != default && destroyableComponent == default)
            {
                var comp = new RebuildComponent(rebuildComponent.ComponentRow);
                imaginationInput.text = comp.take_imagination.ToString();
                imaginationInput.onEndEdit.AddListener(s => { comp.take_imagination = int.Parse(s); });
                
                imaginationInput.interactable = true;
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

            float visualIndex = default;
            foreach (var lootMatrix in lootMatrices)
            {
                var loots = LootDbTable.Rows.Where(r => (int) r.Fields[1].Value == lootMatrix.LootTableIndex)
                    .Select(r => new LootTable(r)).ToArray();

                for (var index = 0; index < loots.Length; index++)
                {
                    var loot = loots[index];
                    var instance = Instantiate(ItemDropPrefab, ItemDropParent);

                    instance.SetActive(true);

                    var id = instance.GetComponentsInChildren<TextMeshProUGUI>().First(t => t.gameObject.name == "Id");

                    id.text = loot.id.ToString();

                    id.transform.parent.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        FdbEditor.Singleton.SeekRow(LootDbTable, loot.DatabaseRow);
                        FdbEditor.Singleton.Activate();
                    });

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
                    
                    if (index != default)
                    {
                        dropRate.interactable = false;
                        minRate.interactable = false;
                        maxRate.interactable = false;
                    }
                    else
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
    }
}