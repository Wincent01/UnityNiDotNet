#if UNITY_EDITOR

using UnityEditor;
using System.Diagnostics;

namespace NiEditorApplication
{
    public class ScriptBatch 
    {
        [MenuItem("Build/Linux 64")]
        public static void BuildGame ()
        {
            // Get filename.
            var path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
            
            var sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;     
            var levels = new string[sceneCount];
            for( var i = 0; i < sceneCount; i++ )
            {
                levels[i] = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
            }
            
            // Build player.
            BuildPipeline.BuildPlayer(levels, path + "/NiDotNet.exe", BuildTarget.StandaloneLinux64, BuildOptions.None);

            // Run the game (Process class from System.Diagnostics).
            var proc = new Process {StartInfo = {FileName = path + "/NiDotNet.exe"}};
            proc.Start();
        }
    }
}
#endif