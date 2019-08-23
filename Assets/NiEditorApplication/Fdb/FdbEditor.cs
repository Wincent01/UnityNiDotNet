using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fdb;
using Fdb.Database;
using Fdb.Enums;
using SFB;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NiEditorApplication.Fdb
{
    public class FdbEditor : NiEditor
    {
        public static FdbDatabase Database;

        public static FdbEditor Singleton;

        [Header("Loading Bar")] 
        public TextMeshProUGUI LoadingTitle;
        public GameObject DatabaseLoading;
        public Image DatabaseLoadingBar;
        public TextMeshProUGUI LoadingText;
        
        [Header("Header Buttons")]
        public Button OpenButton;
        public Button SaveButton;

        [Space(5)]
        
        [Header("Tables")]
        public TextMeshProUGUI TablesTitle;

        [Header("Table Prefabs")]
        public GameObject TablePrefab;
        public RectTransform TableParent;

        [Header("Rows")]
        public RectTransform RowsContent;
        public RectTransform RowsHead;
        public TextMeshProUGUI RowsTitle;
        public TextMeshProUGUI RowsNavigationTitle;
        
        [Header("Nav")]
        public Button RowsNavUp;
        public Button RowsNavDown;
        public Button RowsAddButton;

        [Header("Row structure")]
        public RectTransform RowStructure;
        public GameObject RowStructureColumn;
        
        private readonly Dictionary<DataType, int> _dropDown = new Dictionary<DataType, int>
        {
            {DataType.Integer, 0},
            {DataType.Bigint, 1},
            {DataType.Float, 2},
            {DataType.Boolean, 3},
            {DataType.Text, 4},
            {DataType.Varchar, 5},
            {DataType.Nothing, 6}
        };
        
        public readonly Dictionary<DataType, string> _cSharpType = new Dictionary<DataType, string>
        {
            {DataType.Integer, "int"},
            {DataType.Bigint, "long"},
            {DataType.Float, "float"},
            {DataType.Boolean, "bool"},
            {DataType.Text, "string"},
            {DataType.Varchar, "string"},
            {DataType.Unknown1, "int"},
            {DataType.Unknown2, "int"},
            {DataType.Nothing, "int"},
        };
        
        private uint _tableCount;

        private uint _currentCount;

        private string _file;

        private Thread _loadingThread;

        private FdbFile _fdbFile;
        
        private Table _activeTable;

        private bool _saving;
        
        private int _seekIndex;

        private float _originalEditorHeight;
        
        private readonly List<GameObject> _deleteOnReloadRows = new List<GameObject>();

        private Vector3 _pullPosition;
        
        private void Awake()
        {
            Singleton = this;
            
            OpenButton.onClick.AddListener(OpenDatabase);
            
            RowsNavUp.onClick.AddListener(() =>
            {
                _seekIndex += 50;
                if (_seekIndex > _activeTable.Rows.Count)
                    _seekIndex = _activeTable.Rows.Count - Math.Min(_activeTable.Rows.Count, 50);
                SetupRows();
            });

            RowsNavUp.interactable = false;
            
            RowsNavDown.onClick.AddListener(() =>
            {
                _seekIndex -= 50;
                if (_seekIndex < 0) _seekIndex = default;
                SetupRows();
            });

            RowsNavDown.interactable = false;
            
            SaveButton.onClick.AddListener(SaveDatabase);

            RowsAddButton.onClick.AddListener(AddRow);
        }

        private void SaveDatabase()
        {
            /*
            if (!Directory.Exists("./Structures")) Directory.CreateDirectory("./Structures");

            foreach (var table in Database.Tables)
            {
                var fileName = table.Name.Replace(" ", "");

                if (!File.Exists($"./Structures/{fileName}.cs")) File.Create($"./Structures/{fileName}.cs").Dispose();
                
                var strBuild = new StringBuilder();

                strBuild.AppendLine("using NiEditorApplication.Fdb;");
                strBuild.AppendLine("using System.Linq;");
                strBuild.AppendLine();
                strBuild.AppendLine("namespace Fdb.Database");
                strBuild.AppendLine("{");
                strBuild.AppendLine($"\tclass {fileName}");
                strBuild.AppendLine("\t{");
                strBuild.AppendLine("\t\tpublic Row DatabaseRow { get; set; }");
                strBuild.AppendLine("\t\tpublic Table DatabaseTable { get; set; }");
                strBuild.AppendLine();
                
                for (var index = 0; index < table.Structure.Length; index++)
                {
                    var info = table.Structure[index];
                    var structName = info.Name.Replace(" ", "");
                    if (structName == fileName) structName = $"{structName}Field";
                    strBuild.AppendLine($"\t\tpublic {_cSharpType[info.Type]} {structName}");
                    strBuild.AppendLine("\t\t{");
                    strBuild.AppendLine($"\t\t\tget => ({_cSharpType[info.Type]}) DatabaseRow.Fields[{index}].Value;");
                    strBuild.AppendLine("\t\t\tset");
                    strBuild.AppendLine("\t\t\t{");
                    strBuild.AppendLine($"\t\t\t\tDatabaseRow.Fields[{index}].Value = value;");
                    strBuild.AppendLine($"\t\t\t\tDatabaseTable.UpdateRow(DatabaseRow);");
                    strBuild.AppendLine("\t\t\t}");
                    strBuild.AppendLine("\t\t}");
                    strBuild.AppendLine();
                }

                strBuild.AppendLine($"\t\tpublic {fileName}(Row databaseRow)");
                strBuild.AppendLine("\t\t{");
                strBuild.AppendLine("\t\t\tDatabaseRow = databaseRow;");
                strBuild.AppendLine($"\t\t\tDatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == \"{table.Name}\");");
                strBuild.AppendLine("\t\t}");
                strBuild.AppendLine("\t}");
                strBuild.AppendLine("}");

                File.WriteAllText($"./Structures/{fileName}.cs", strBuild.ToString());
            }

            return;
            */
            
            LoadingTitle.text = "Writing Database";
            LoadingText.text = "";
            RaycastCover.SetActive(true);
            DatabaseLoading.SetActive(true);

            _saving = true;
            
            Task.Run(() =>
            {
                var threadStart = new ThreadStart(WriteDatabase);
                var thread = new Thread(threadStart);
                _loadingThread = thread;
                thread.Start();
            });
        }

        private void OpenDatabase()
        {
            RaycastCover.SetActive(true);
            
            string file;

            try
            {
                file = StandaloneFileBrowser.OpenFilePanel("Open Database", "~/", "", false)[0];
            }
            catch
            {
                RaycastCover.SetActive(false);
                return;
            }

            if (string.IsNullOrWhiteSpace(file))
            {
                RaycastCover.SetActive(false);
                return;
            }

            _file = file;

            DatabaseLoading.SetActive(true);

            LoadingTitle.text = "Loading Database";
            var threadStart = new ThreadStart(LoadDatabase);
            var thread = new Thread(threadStart);
            _loadingThread = thread;
            thread.Start();
        }

        private void WriteDatabase()
        {
            Task.Run(() =>
            {
                _fdbFile.Structure = new List<object>();

                _fdbFile.Write(_fdbFile);

                _tableCount = (uint) _fdbFile.Structure.Count;

                _currentCount = default;
                
                var bytes = _fdbFile.Complete(i =>
                {
                    _currentCount = (uint) i;
                });
                
                File.WriteAllBytes(_file, bytes);

                _saving = false;
            });
        }

        private void LoadDatabase()
        {
            _fdbFile = new FdbFile(_file, i => _currentCount = i, out _tableCount);

            Database = new FdbDatabase(_fdbFile);
        }

        private void Update()
        {
            SaveButton.interactable = Database != default;
            OpenButton.interactable = Database == default;

            RowsAddButton.interactable = _activeTable != default;
            
            DatabaseLoadingBar.fillAmount = (float) (_currentCount / (double) _tableCount);

            LoadingText.text = !_saving
                ? $"{_currentCount} / {_tableCount} tables..."
                : $"Writing struct {_currentCount} / {_tableCount}";
            
            if (_currentCount < _tableCount - 1) return;

            _tableCount = 0;
            
            RaycastCover.SetActive(false);

            DatabaseLoading.SetActive(false);

            var path = Path.GetDirectoryName(_file)?.Replace("\\", "/").Split('/');

            ApplicationTitle.text = $"Database Editor - {(path != default ? path[path.Length - 1] : "")}/{Path.GetFileName(_file)}";

            _loadingThread.Join();
            _loadingThread.Abort();
            
            if (!_saving) SetupTables();
        }

        public void SeekRow(Table table, Row row)
        {
            _activeTable = table;
            _seekIndex = table.Rows.IndexOf(row);
            SetupRows();
        }
        
        private void SetupTables()
        {
            _originalEditorHeight = RowsContent.sizeDelta.y;
            
            TablesTitle.text = $"{Database.Tables.Length} Table" + (Database.Tables.Length > 1 ? "s" : "");
            
            Debug.Log(TableParent.sizeDelta);
            TableParent.sizeDelta = new Vector2(0, 20 * Database.Tables.Length + (float) (TableParent.sizeDelta.y / 4d));
            Debug.Log(TableParent.sizeDelta);
            
            for (var index = 0; index < Database.Tables.Length; index++)
            {
                var table = Database.Tables[index];

                var instance = Instantiate(TablePrefab, TableParent, true);

                instance.SetActive(true);

                instance.name = table.Name;
                
                instance.transform.position -= new Vector3(0, 20, 0) * index;

                instance.GetComponentInChildren<TextMeshProUGUI>().text = table.Name;

                var scopeIndex = index;
                instance.GetComponent<Button>().onClick.AddListener(() =>
                {
                    _activeTable = Database.Tables[scopeIndex];
                    _seekIndex = default;
                    SetupRows();
                });
            }
        }

        private void SetupRows()
        {
            RowsTitle.text = _activeTable.Rows.Count > 0
                ? $"{_activeTable.Name}: {_activeTable.Rows.Count} Row" + (_activeTable.Rows.Count > 1 ? "s" : "")
                : $"{_activeTable.Name}: Empty Table";
            
            RowsNavUp.interactable = _activeTable.Rows.Count > 0;
            RowsNavDown.interactable = _activeTable.Rows.Count > 0;
            
            RowsContent.sizeDelta = new Vector2(RowsContent.sizeDelta.x, _originalEditorHeight);
            
            foreach (var reloadRow in _deleteOnReloadRows)
            {
                Destroy(reloadRow);
            }

            int visualIndex = default;

            GetStructure();
            
            for (var i = _seekIndex; i < _seekIndex + 50; i++)
            {
                Row row;
                try
                {
                    row = _activeTable.Rows[i];
                }
                catch
                {
                    break;
                }
                
                if (row == default) continue;

                var instance = GetStructure(row);
                
                if (visualIndex > 33) RowsContent.sizeDelta += new Vector2(default, 30);

                visualIndex++;

                instance.transform.Translate(new Vector2(default, visualIndex * -30));
            }
        }

        private void AddRow()
        {
            var fields = new Field[_activeTable.Structure.Length];

            for (var index = 0; index < fields.Length; index++)
            {
                var field = _activeTable.Structure[index];

                fields[index] = new Field(field.Type, 0);

                switch (field.Type)
                {
                    case DataType.Nothing:
                        fields[index].Value = 0;
                        break;
                    case DataType.Integer:
                        fields[index].Value = 0;
                        break;
                    case DataType.Unknown1:
                        fields[index].Value = 0;
                        break;
                    case DataType.Float:
                        fields[index].Value = 0;
                        break;
                    case DataType.Text:
                        fields[index].Value = "";
                        break;
                    case DataType.Boolean:
                        fields[index].Value = false;
                        break;
                    case DataType.Bigint:
                        fields[index].Value = 0;
                        break;
                    case DataType.Unknown2:
                        fields[index].Value = 0;
                        break;
                    case DataType.Varchar:
                        fields[index].Value = "";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var row = new Row(fields);
            _activeTable.AppendRow(row);

            _seekIndex = _activeTable.Rows.Count - Math.Min(_activeTable.Rows.Count, 50);
            SetupRows();
        }

        private GameObject GetStructure(Row row = default)
        {
            RowsContent.sizeDelta = new Vector2(_activeTable.Structure.Length * 200 + 30, RowsContent.sizeDelta.y);

            var rowInstance = Instantiate(RowStructure.gameObject, RowsHead, true);
            
            var delete = rowInstance.GetComponentsInChildren<Transform>(true)
                .First(b => b.gameObject.name == "Delete Button").GetComponent<Button>();

            delete.interactable = row != default;
                
            delete.onClick.AddListener(() => { _activeTable.DeleteRow(row); SetupRows(); });
            
            for (var index = 0; index < _activeTable.Structure.Length; index++)
            {
                var savedIndex = index;
                
                var info = _activeTable.Structure[index];
                
                var instance = Instantiate(RowStructureColumn, rowInstance.transform, true);

                instance.name = info.Name;
                
                instance.SetActive(true);

                var texts = instance.GetComponentsInChildren<TextMeshProUGUI>();

                foreach (var text in texts.Where(t => t.name == "Name"))
                {
                    text.text = row == default
                        ? info.Name
                        : row.Fields[index].Value.ToString();
                }

                var input = instance.GetComponentInChildren<TMP_InputField>();
                
                input.text = row == default
                    ? info.Name
                    : row.Fields[index].Value.ToString();

                input.interactable = row != default;

                if (row != default)
                {
                    switch (row.Fields[savedIndex].DataType)
                    {
                        case DataType.Nothing:
                            input.contentType = TMP_InputField.ContentType.IntegerNumber;
                            break;
                        case DataType.Integer:
                            input.contentType = TMP_InputField.ContentType.IntegerNumber;
                            break;
                        case DataType.Unknown1:
                            input.contentType = TMP_InputField.ContentType.IntegerNumber;
                            break;
                        case DataType.Float:
                            input.contentType = TMP_InputField.ContentType.DecimalNumber;
                            break;
                        case DataType.Text:
                            input.contentType = TMP_InputField.ContentType.Alphanumeric;
                            input.gameObject.AddComponent<MiddleClickToBrowse>();
                            break;
                        case DataType.Boolean:
                            input.contentType = TMP_InputField.ContentType.Alphanumeric;
                            break;
                        case DataType.Bigint:
                            input.contentType = TMP_InputField.ContentType.IntegerNumber;
                            break;
                        case DataType.Unknown2:
                            input.contentType = TMP_InputField.ContentType.IntegerNumber;
                            break;
                        case DataType.Varchar:
                            input.contentType = TMP_InputField.ContentType.Alphanumeric;
                            input.gameObject.AddComponent<MiddleClickToBrowse>();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                input.onEndEdit.AddListener(s =>
                {
                    if (row == default) return;

                    var field = row.Fields[savedIndex];
                    try
                    {
                        switch (row.Fields[savedIndex].DataType)
                        {
                            case DataType.Nothing:
                                field.Value = 0;
                                break;
                            case DataType.Integer:
                                field.Value = int.Parse(s);
                                break;
                            case DataType.Unknown1:
                                field.Value = 0;
                                break;
                            case DataType.Float:
                                field.Value = float.Parse(s.Replace('.', ','));
                                break;
                            case DataType.Text:
                                field.Value = s;
                                break;
                            case DataType.Boolean:
                                field.Value = bool.Parse(s);
                                break;
                            case DataType.Bigint:
                                field.Value = long.Parse(s);
                                break;
                            case DataType.Unknown2:
                                field.Value = 0;
                                break;
                            case DataType.Varchar:
                                field.Value = s;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    catch
                    {
                        switch (row.Fields[savedIndex].DataType)
                        {
                            case DataType.Nothing:
                                input.text = "0";
                                break;
                            case DataType.Integer:
                                input.text = "0";
                                break;
                            case DataType.Unknown1:
                                input.text = "0";
                                break;
                            case DataType.Float:
                                input.text = "0";
                                break;
                            case DataType.Text:
                                input.text = "";
                                break;
                            case DataType.Boolean:
                                input.text = "False";
                                break;
                            case DataType.Bigint:
                                input.text = "0";
                                break;
                            case DataType.Unknown2:
                                input.text = "0";
                                break;
                            case DataType.Varchar:
                                input.text = "";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        s = input.text;
                        switch (row.Fields[savedIndex].DataType)
                        {
                            case DataType.Nothing:
                                field.Value = 0;
                                break;
                            case DataType.Integer:
                                field.Value = int.Parse(s);
                                break;
                            case DataType.Unknown1:
                                field.Value = 0;
                                break;
                            case DataType.Float:
                                field.Value = float.Parse(s.Replace('.', ','));
                                break;
                            case DataType.Text:
                                field.Value = s;
                                break;
                            case DataType.Boolean:
                                field.Value = bool.Parse(s);
                                break;
                            case DataType.Bigint:
                                field.Value = long.Parse(s);
                                break;
                            case DataType.Unknown2:
                                field.Value = 0;
                                break;
                            case DataType.Varchar:
                                field.Value = s;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                    _activeTable.UpdateRow(row);
                });
                
                instance.transform.position += new Vector3(index * 200 + 30, 0, 0);

                var typeText = texts.First(t => t.name == "Type");

                var typeOptions = instance.GetComponentInChildren<TMP_Dropdown>();
                typeOptions.value = _dropDown[row?.Fields[index].DataType ?? info.Type];

                typeOptions.interactable = row != default;
                
                typeOptions.onValueChanged.AddListener(i =>
                {
                    if (row == default) return;
                    
                    row.Fields[savedIndex].DataType = _dropDown.First(k => k.Value == i).Key;
                    
                    var comp = input.gameObject.GetComponent<MiddleClickToBrowse>();

                    if (comp == default && (row.Fields[savedIndex].DataType == DataType.Varchar ||
                                            row.Fields[savedIndex].DataType == DataType.Text))
                    {
                        input.gameObject.AddComponent<MiddleClickToBrowse>();
                    }
                    else if (comp != default && (row.Fields[savedIndex].DataType == DataType.Varchar ||
                                                 row.Fields[savedIndex].DataType == DataType.Text))
                    {
                        
                    }
                    else if (comp != default)
                    {
                        Destroy(comp);
                    }
                });

                switch (row?.Fields[index].DataType ?? info.Type)
                {
                    case DataType.Nothing:
                        typeText.text = "NULL";
                        break;
                    case DataType.Integer:
                        typeText.text = "INT32";
                        break;
                    case DataType.Unknown1:
                        typeText.text = "?";
                        break;
                    case DataType.Float:
                        typeText.text = "REAL";
                        break;
                    case DataType.Text:
                        typeText.text = "TEXT";
                        break;
                    case DataType.Boolean:
                        typeText.text = "BOOL";
                        break;
                    case DataType.Bigint:
                        typeText.text = "INT64";
                        break;
                    case DataType.Unknown2:
                        typeText.text = "?";
                        break;
                    case DataType.Varchar:
                        typeText.text = "VCHR";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            rowInstance.SetActive(true);

            _deleteOnReloadRows.Add(rowInstance);

            return rowInstance;
        }
    }
}
