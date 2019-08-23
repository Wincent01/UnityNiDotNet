using System;
using System.IO;
using Luz.Enums;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    [Serializable]
    public class LuzPathData
    {
        public uint Version { get; set; }
        
        public NiString PathName { get; set; }
        
        public PathType Type { get; set; }
        
        public PathBehavior Behavior { get; set; }
        
        public LuzPathWaypoint[] Waypoints { get; set; }
        
        public LuzPathData(BinaryReader reader, uint version, NiString pathName, PathType type)
        {
            Version = version;

            PathName = pathName;

            Type = type;

            Behavior = (PathBehavior) reader.ReadUInt32();
        }
    }
}