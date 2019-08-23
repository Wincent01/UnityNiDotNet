using System.IO;
#if UNITY_5_4_OR_NEWER
using UnityEngine;
#else
using System.Numerics;
#endif

namespace NiDotNet.NIF.Nodes
{
    public class NiVector3 : NiObject
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public NiVector3(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
            Z = reader.ReadSingle();
        }

        public static implicit operator Vector3(NiVector3 v) => new Vector3(v.X, v.Y, v.Z);
    }
}