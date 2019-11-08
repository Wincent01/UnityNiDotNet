using System;
using System.Linq;
using Fdb.Database;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NiEditorApplication.Editor
{
    public class MissionEditor : NiEditor
    {
        public int MissionId { get; set; } = -1;

        public static Table MissionTable;

        public static Table NpcTable;

        [Header("Header Buttons")] public Button OpenButton;
        public Button SeekRowButton;
        public Button NewButton;

        [Header("Object Input")] public GameObject ObjectInput;
        public TMP_InputField ObjectIdInput;
        public Button SubmitObjectIdButton;

        private TMP_InputField[] _localeEntries;

        private void Awake()
        {
            OpenButton.onClick.AddListener(() =>
            {
                ObjectInput.SetActive(true);
                RaycastCover.SetActive(true);
            });

            SubmitObjectIdButton.onClick.AddListener(() => { LoadMission(int.Parse(ObjectIdInput.text)); });

            SeekRowButton.onClick.AddListener(() =>
            {
                if (MissionTable == default) MissionTable = FdbEditor.Database.Tables.First(t => t.Name == "Missions");

                FdbEditor.Singleton.SeekRow(MissionTable,
                    MissionTable.Rows.First(m => (int) m.Fields[0].Value == MissionId));
                FdbEditor.Singleton.Activate();
            });
            
            NewButton.onClick.AddListener(() =>
            {
                if (NpcTable == default)
                    NpcTable = FdbEditor.Database.Tables.First(t => t.Name == "MissionNPCComponent");
                if (MissionTable == default) MissionTable = FdbEditor.Database.Tables.First(t => t.Name == "Missions");
                
                var newLot = MissionTable.Rows.Select(r => new Missions(r).id).Max() + 1;

                var row = new Missions(NewRow(MissionTable)) {id = newLot};

                LoadMission(row.id);
            });

            _localeEntries = gameObject.GetComponentsInChildren<TMP_InputField>().Where(
                t => t.name.StartsWith("Locale Entry")
            ).ToArray();

            foreach (var entry in _localeEntries)
            {
                entry.interactable = false;
            }
        }
        
        public void LoadMission(int missionId)
        {
            ApplicationTitle.text = $"Mission Editor - {missionId}";

            MissionId = missionId;

            var texts = (MissionTextType[]) Enum.GetValues(typeof(MissionTextType));

            for (var index = 0; index < _localeEntries.Length; index++)
            {
                var localeEntry = _localeEntries[index];
                var textType = texts[index];
                
                var value = LocaleEditor.GetMissionText(missionId, textType);

                localeEntry.text = value;
                localeEntry.interactable = true;

                foreach (var text in localeEntry.GetComponentsInChildren<TextMeshProUGUI>())
                {
                    switch (text.name)
                    {
                        case "Name":
                            text.text = value;
                            break;
                        case "Id":
                            text.text = textType.ToString();
                            break;
                    }
                }

                localeEntry.onEndEdit.RemoveAllListeners();

                localeEntry.onEndEdit.AddListener(s =>
                {
                    LocaleEditor.SetMissionText(missionId, textType, s);
                    LocaleEditor.SetMissionText(missionId, textType, s, Locale.Germany);
                    LocaleEditor.SetMissionText(missionId, textType, s, Locale.GreatBritain);
                });
            }

            RaycastCover.SetActive(false);
            ObjectInput.SetActive(false);
        }

        private void Update()
        {
            SeekRowButton.interactable = MissionId != -1;
        }
    }
}