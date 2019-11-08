#if UNITY_EDITOR

using System;
using System.IO;
using System.Linq;
using Luz;
using UnityEditor;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

[ScriptedImporter(1, "luz")]
public class LuzImporter : ScriptedImporter
{
    private LuzFile _luzFile;
    
    public override void OnImportAsset(AssetImportContext ctx)
    {
        _luzFile = new LuzFile($"{UniverseImporter.LuzImportDir}/{Path.GetFileName(ctx.assetPath)}");

        var luzAssetPath = $"{Path.GetDirectoryName(ctx.assetPath)}/{Path.GetFileNameWithoutExtension(ctx.assetPath)}";
        
        Directory.CreateDirectory(luzAssetPath);
        
        var objects = UniverseImporter.Database.Tables.First(s => s.Name.ToLower() == "componentsregistry");
        var renderComps = UniverseImporter.Database.Tables.First(s => s.Name.ToLower() == "rendercomponent");
        
        var spawnPoint = new GameObject("Spawn Point");
        spawnPoint.transform.position = _luzFile.SpawnPoint;
        spawnPoint.transform.rotation = _luzFile.SpawnRotation;

        ctx.AddObjectToAsset("Spawn Point", spawnPoint);
        
        foreach (var lvlFile in _luzFile.LvlFiles)
        {
            foreach (var template in lvlFile.Chunks2001.SelectMany(c => c.Objects))
            {
                if (template.Ldf.TryGetValue("spawntemplate", out var realId))
                {
                    Debug.Log($"{template.Lot} is spawner");
                    template.Lot = (int) realId;
                    Debug.Log($"{template.Lot} came from spawner.");
                }
                /*
                else if (template.Ldf.TryGetValue("loadSrvrOnly", out var serverOnly) && (bool) serverOnly ||
                        template.Ldf.TryGetValue("carver_only", out var carverOnly) && (bool) carverOnly ||
                        template.Ldf.TryGetValue("renderDisabled", out var disabled) && (bool) disabled)
                {
                    continue;
                }
                */

                var comps = objects.Rows?.Where(r => r?.Fields[0]?.Value.ToString() == template.Lot.ToString()).ToArray();
                var render = comps?.FirstOrDefault(r => r.Fields[1].Value.ToString() == "2");
                if (render == null) continue;
                var renderId = render.Fields[2].Value.ToString();
                
                var row = renderComps.Rows.First(s => s.Fields[0].Value.ToString() == renderId);

                var final = $"{Path.Combine(UniverseImporter.ResDir, row.Fields[1].Value.ToString())}";

                final = final.Replace(@"\\", "/").Replace("\\", "/");
                Debug.Log(final);
                try
                {
                    var nifPath = $"{luzAssetPath}/{Path.GetFileName(final)}";

                    if (!File.Exists(nifPath))
                    {
                        File.Copy(final, nifPath);
                        
                        AssetDatabase.ImportAsset(nifPath);
                    }

                    var obj = (GameObject) PrefabUtility.InstantiatePrefab(
                        AssetDatabase.LoadAssetAtPath(nifPath, typeof(GameObject)));
                    obj.transform.localPosition = template.Position;
                    obj.transform.localRotation = template.Rotation;
                    obj.transform.localScale = Vector3.one * template.Scale;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
                Debug.Log(final);
            }
        }
    }
}

#endif