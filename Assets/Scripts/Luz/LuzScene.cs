using System;
using System.IO;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    [Serializable]
    public class LuzScene
    {
        public NiString FileName { get; set; }
        
        public byte SceneId { get; set; }
        
        public NiBoolean IsAudioScene { get; set; }
        
        public NiString SceneName { get; set; }
        
        public LuzScene(BinaryReader reader)
        {
            FileName = new NiString(reader, false, true);

            SceneId = reader.ReadByte();

            reader.ReadBytes(3);
            
            IsAudioScene = new NiBoolean(reader);
            
            reader.ReadBytes(3);
            
            SceneName = new NiString(reader, false, true);
            
            reader.ReadBytes(3);
        }
    }
}