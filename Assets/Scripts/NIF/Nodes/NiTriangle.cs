using System.IO;
#if UNITY_5_4_OR_NEWER
using UnityEngine;
#else
using System.Numerics;
#endif

namespace NiDotNet.NIF.Nodes
{
    public class NiTriangle : NiObject
    {
        public ushort V1 { get; set; }

        public ushort V2 { get; set; }

        public ushort V3 { get; set; }

        public NiTriangle(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            V1 = reader.ReadUInt16();
            V2 = reader.ReadUInt16();
            V3 = reader.ReadUInt16();
        }

        public static implicit operator Vector3(NiTriangle triangle) =>
            new Vector3(triangle.V1, triangle.V2, triangle.V3);

        public static implicit operator ushort[](NiTriangle triangle) => new[] {triangle.V1, triangle.V2, triangle.V3};

        public static implicit operator int[](NiTriangle triangle) => new int[] {triangle.V1, triangle.V2, triangle.V3};
    }
}