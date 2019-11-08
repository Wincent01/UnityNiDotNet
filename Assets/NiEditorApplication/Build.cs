#if UNITY_EDITOR

using UnityEditor;
using System.Diagnostics;

namespace NiEditorApplication.Editor
{
    public class ScriptBatch 
    {
        private static void BuildGame(BuildTarget target)
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
            BuildPipeline.BuildPlayer(levels, path + "/NiDotNet.exe", target, BuildOptions.None);
            
            // Run the game (Process class from System.Diagnostics).
            var proc = new Process {StartInfo = {FileName = path + "/NiDotNet.exe"}};
            proc.Start();
        }

        [MenuItem("Build/Linux 64")]
        public static void BuildLinux()
        {
            BuildGame(BuildTarget.StandaloneLinux64);
        }
        
        [MenuItem("Build/Windows 64")]
        public static void BuildWindows()
        {
            BuildGame(BuildTarget.StandaloneWindows64);
        }
        
        [MenuItem("Build/MacOS 64")]
        public static void BuildMacOs()
        {
            BuildGame(BuildTarget.StandaloneOSX);
        }
    }
}
#endif