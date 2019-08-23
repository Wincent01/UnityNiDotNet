using System.Linq;
using SFB;
using TMPro;

namespace NiEditorApplication
{
    public class MiddleClickToBrowse : ExtendedButton
    {
        private TMP_InputField _comp;

        private string _selectedFile;

        private bool _hasSelected;
        
        private void Start()
        {
            _comp = GetComponent<TMP_InputField>();

            MiddleClick += SelectThread;
        }

        private void SelectThread()
        {
            string file;

            try
            {
                file = StandaloneFileBrowser.OpenFilePanel("Select File", "~/", "", false)[0];
            }
            catch
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(file))
            {
                return;
            }

            var array = file.Replace("\\", "/").Split('/').Reverse().ToArray();

            file = $"{array[0]}";

            for (var i = 1; i < array.Length; i++)
            {
                var part = array[i];

                if (part == "res")
                {
                    break;
                }

                file = $"{part}/{file}";
            }

            file = file.Replace("/", @"\\");

            _hasSelected = true;
            _selectedFile = file;
        }

        private void Update()
        {
            if (!_hasSelected) return;
            
            _comp.text = _selectedFile;

            _comp.onEndEdit?.Invoke(_selectedFile);

            _hasSelected = false;
        }
    }
}