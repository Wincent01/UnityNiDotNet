using System;
using System.IO;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    [Serializable]
    public class LuzSceneTransitionPoint
    {
        public ulong SceneId { get; set; }
        
        public NiVector3 Point { get; set; }
        
        public LuzSceneTransitionPoint(BinaryReader reader)
        {
            SceneId = reader.ReadUInt64();
            
            Point = new NiVector3(reader, null);
        }
    }
}