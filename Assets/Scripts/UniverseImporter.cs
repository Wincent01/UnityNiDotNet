#if UNITY_EDITOR

using System.IO;
using Fdb;
using Fdb.Database;
using UnityEditor;
using UnityEngine;

public class UniverseImporter : EditorWindow
{
    private string GameFolder { get; set; }

    private string NifFile { get; set; }

    private string LuzFile { get; set; }
    
    private bool _checkTransparency { get; set; }

    private FdbDatabase _database { get; set; }
    
    public static string ResDir { get; set; }
    
    public static string NifImportDir { get; set; }
    
    public static string LuzImportDir { get; set; }

    public static FdbDatabase Database { get; set; }
    
    public static bool CheckTransparency;

    [MenuItem("Window/Universe Importer")]
    private static void OnWindowOpen()
    {
        var window = GetWindow<UniverseImporter>();
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Universe Importer", EditorStyles.boldLabel);
        
        GetGameFolder();

        if (string.IsNullOrWhiteSpace(ResDir)) return;
        
        LuzAssembler();

        NifAssembler();
    }

    private void GetGameFolder()
    {
        GUILayout.Space(5);
        
        if (_database != null)
        {
            GUILayout.Label($"Database loaded: {_database.Tables.Length} tables.");
        }
        
        GUILayout.Label("Res Folder");

        GUILayout.BeginHorizontal();
        
        GameFolder = EditorGUILayout.TextField(GameFolder);

        if (GUILayout.Button("Submit"))
        {
            ResDir = GameFolder;

            if (_database == null || _database.Tables.Length == default)
                _database = new FdbDatabase(new FdbFile($"{Path.Combine(ResDir, "./cdclient.fdb")}"));
        }

        if (_database != null)
        {
            Database = _database;
        }
        
        GUILayout.EndHorizontal();
    }

    private void LuzAssembler()
    {
        GUILayout.Space(5);
        
        GUILayout.Label("Luz Assembler");

        GUILayout.BeginHorizontal();

        LuzFile = EditorGUILayout.TextField(LuzFile);

        if (GUILayout.Button("Import"))
        {
            ImportLuz();
        }
        
        GUILayout.EndHorizontal();
    }

    private void NifAssembler()
    {
        GUILayout.Space(5);
        
        GUILayout.Label("Nif Assembler");

        GUILayout.BeginHorizontal();
        
        NifFile = EditorGUILayout.TextField(NifFile);
        
        if (GUILayout.Button("Import"))
        {
            ImportNif();
        }
        
        GUILayout.EndHorizontal();

        NifSettings();
    }

    private void NifSettings()
    {
        GUILayout.BeginHorizontal();
        
        GUILayout.Label("Check Transparency");

        _checkTransparency = EditorGUILayout.Toggle(_checkTransparency);
        
        GUILayout.EndHorizontal();
    }

    public void ImportLuz()
    {
        LuzImportDir = Path.GetDirectoryName(LuzFile);
        
        if (!Directory.Exists($"{Application.dataPath}/Luz Imports"))
            Directory.CreateDirectory($"{Application.dataPath}/Luz Imports");
        
        File.Copy(LuzFile, $"{Application.dataPath}/Luz Imports/{Path.GetFileName(LuzFile)}");
        AssetDatabase.ImportAsset($"Assets/Luz Imports/{Path.GetFileName(LuzFile)}");
    }

    public void ImportNif()
    {
        NifImportDir = Path.GetDirectoryName(NifFile);
        CheckTransparency = _checkTransparency;

        if (!Directory.Exists($"{Application.dataPath}/Nif Imports"))
            Directory.CreateDirectory($"{Application.dataPath}/Nif Imports");
        
        File.Copy(NifFile, $"{Application.dataPath}/Nif Imports/{Path.GetFileName(NifFile)}");
        AssetDatabase.ImportAsset($"Assets/Nif Imports/{Path.GetFileName(NifFile)}");
    }
}

#endif