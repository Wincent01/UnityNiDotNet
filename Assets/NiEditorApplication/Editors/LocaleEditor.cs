using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using UnityEngine;

namespace NiEditorApplication.Editor
{
    public static class LocaleEditor
    {
        private static string _localeFilePath;

        private static XmlDocument _document;

        private static readonly List<XmlNode> _phrases = new List<XmlNode>();

        public static XmlDocument LocaleDocument
        {
            get
            {
                if (_document != default) return _document;
                _localeFilePath = $"{Path.Combine(FdbEditor.RecurseFolder, "../locale/locale.xml")}";

                Debug.Log(_localeFilePath);

                _document = new XmlDocument();
                
                _document.LoadXml(File.ReadAllText(_localeFilePath));

                foreach (XmlNode node in _document.GetElementsByTagName("phrase"))
                {
                    _phrases.Add(node);
                }
                
                return _document;
            }
        }

        private static void Ensure()
        {
            if (_document != default) return;
            
            _localeFilePath = $"{Path.Combine(FdbEditor.RecurseFolder, "../locale/locale.xml")}";

            Debug.Log(_localeFilePath);

            _document = new XmlDocument();
                
            _document.LoadXml(File.ReadAllText(_localeFilePath));

            foreach (XmlNode node in _document.GetElementsByTagName("phrase"))
            {
                _phrases.Add(node);
            }
        }

        public static void Save()
        {
            LocaleDocument.Save(_localeFilePath);
        }

        public static string GetObjectName(int objectId, Locale locale = Locale.UnitedStates)
        {
            Ensure();

            var names = _phrases.FirstOrDefault(p =>
                p.Attributes != null && p.Attributes["id"].Value == $"Objects_{objectId}_name");
            
            if (names == default)
            {
                AddPhrase($"Objects_{objectId}_name");
                return "";
            };

            Debug.Log(names.ChildNodes.Count);
            
            for (var i = 0; i < names.ChildNodes.Count; i++)
            {
                var child = names.ChildNodes[i];
                
                if (child.Attributes == default) continue;

                Debug.Log(child.Attributes[0].Value);

                if (child.Attributes["locale"].Value == locale.Code())
                {
                    return child.InnerText;
                }
            }

            return default;
        }

        public static void AddPhrase(string id)
        {
            var phrases = LocaleDocument.GetElementsByTagName("phrases")[0];

            if (phrases.Attributes != null)
                phrases.Attributes[0].Value = (_phrases.Count + 1).ToString();

            var newPhrase = LocaleDocument.CreateElement("phrase");

            var attribute = LocaleDocument.CreateAttribute("id");
            attribute.Value = id;

            newPhrase.Attributes.Append(attribute);

            var enUs = LocaleDocument.CreateElement("translation");
            var deDe = LocaleDocument.CreateElement("translation");
            var enGb = LocaleDocument.CreateElement("translation");
            
            var attributeEnUs = LocaleDocument.CreateAttribute("locale");
            var attributeDeDe = LocaleDocument.CreateAttribute("locale");
            var attributeEnGb = LocaleDocument.CreateAttribute("locale");

            attributeEnUs.Value = "en_US";
            attributeDeDe.Value = "de_DE";
            attributeEnGb.Value = "en_GB";

            enUs.Attributes.Append(attributeEnUs);
            deDe.Attributes.Append(attributeDeDe);
            enGb.Attributes.Append(attributeEnGb);
            
            newPhrase.AppendChild(enUs);
            newPhrase.AppendChild(deDe);
            newPhrase.AppendChild(enGb);

            phrases.AppendChild(newPhrase);

            _phrases.Add(newPhrase);
            
            Save();
        }

        public static string GetMissionText(int missionId, MissionTextType type, Locale locale = Locale.UnitedStates)
        {
            Ensure();
            
            var names = _phrases.FirstOrDefault(p => p.Attributes != null && p.Attributes["id"].Value ==
                                                     $"MissionText_{missionId}_{type.Code()}");
            
            if (names == default) return default;
            
            for (var i = 0; i < names.ChildNodes.Count; i++)
            {
                var child = names.ChildNodes[i];
                
                if (child.Attributes == default) continue;

                if (child.Attributes["locale"].Value == locale.Code())
                {
                    return child.InnerText;
                }
            }

            return default;
        }

        public static string GetMissionTaskDescription(int taskId, Locale locale = Locale.UnitedStates)
        {
            Ensure();
            
            var names = _phrases.FirstOrDefault(p => p.Attributes != null && p.Attributes["id"].Value == 
                                                     $"MissionTasks_{taskId}_discription");
            
            if (names == default) return default;
            
            for (var i = 0; i < names.ChildNodes.Count; i++)
            {
                var child = names.ChildNodes[i];
                
                if (child.Attributes == default) continue;

                if (child.Attributes["locale"].Value == locale.Code())
                {
                    return child.InnerText;
                }
            }

            return default;
        }

        public static void SetObjectName(int objectId, string name, Locale locale = Locale.UnitedStates)
        {
            Ensure();

            var names = _phrases.FirstOrDefault(p =>
                p.Attributes != null && p.Attributes["id"].Value == $"Objects_{objectId}_name");

            if (names == default) return;
            
            for (var i = 0; i < names.ChildNodes.Count; i++)
            {
                var child = names.ChildNodes[i];
                
                if (child.Attributes == default) continue;

                if (child.Attributes["locale"].Value == locale.Code())
                {
                    child.InnerText = name;
                }
            }
            
            Save();
        }
        
        public static void SetMissionText(int missionId, MissionTextType type, string text, Locale locale = Locale.UnitedStates)
        {
            Ensure();

            var names = _phrases.FirstOrDefault(p => p.Attributes != null && p.Attributes["id"].Value ==
                                                     $"MissionText_{missionId}_{type.Code()}");

            if (names == default)
            {
                AddPhrase($"MissionText_{missionId}_{type.Code()}");
                
                SetMissionText(missionId, type, text, locale);
                
                return;
            }
            
            for (var i = 0; i < names.ChildNodes.Count; i++)
            {
                var child = names.ChildNodes[i];
                
                if (child.Attributes == default) continue;

                if (child.Attributes["locale"].Value == locale.Code())
                {
                    child.InnerText = text;
                }
            }
            
            Save();
        }
        
        public static void SetMissionTaskDescription(int taskId, string text, Locale locale = Locale.UnitedStates)
        {
            Ensure();

            var names = _phrases.FirstOrDefault(p => p.Attributes != null && p.Attributes["id"].Value == 
                                                     $"MissionTasks_{taskId}_discription");

            if (names == default) return;
            
            for (var i = 0; i < names.ChildNodes.Count; i++)
            {
                var child = names.ChildNodes[i];
                
                if (child.Attributes == default) continue;

                if (child.Attributes["locale"].Value == locale.Code())
                {
                    child.InnerText = text;
                }
            }
            
            Save();
        }
    }
}