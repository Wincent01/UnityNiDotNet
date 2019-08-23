using System.IO;
#if UNITY_5_4_OR_NEWER
using UnityEngine;
#else
using System.Numerics;
#endif


namespace NiDotNet.NIF.Nodes
{
    public class NiQuaternion : NiObject
    {
        public float W { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public NiQuaternion(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            W = reader.ReadSingle();
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
            Z = reader.ReadSingle();
        }

        public static implicit operator Quaternion(NiQuaternion q) => new Quaternion(q.X, q.Y, q.Z, q.W);
    }
}