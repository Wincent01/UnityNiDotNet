using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiNode : NiAVObject
    {
        public int[] Children { get; set; }

        public int[] Effects { get; set; }

        public NiNode(BinaryReader reader, NiFile file) : base(reader, file)
        {
            //
            //    Get children
            //
            Children = new int[reader.ReadUInt32()];
            for (var i = 0; i < Children.Length; i++)
            {
                Children[i] = reader.ReadInt32();
            }

            //
            //    Get effects
            //
            Effects = new int[reader.ReadUInt32()];
            for (var i = 0; i < Effects.Length; i++)
            {
                Effects[i] = reader.ReadInt32();
            }
        }
    }
}