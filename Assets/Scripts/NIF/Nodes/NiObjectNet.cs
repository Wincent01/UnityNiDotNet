using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiObjectNet : NiObject
    {
        public string Name { get; set; }

        public int[] ExtraData { get; set; }

        public int Controller { get; set; }

        public NiObjectNet(BinaryReader reader, NiFile file) : base(reader, file)
        {
            //
            //    Get name
            //
            var index = reader.ReadUInt32();
            if ((int) index != -1)
            {
                Name = file.Header.Strings[index];
            }

            //
            //    Get children
            //
            ExtraData = new int[reader.ReadInt32()];

            for (var i = 0; i < ExtraData.Length; i++)
            {
                ExtraData[i] = reader.ReadInt32();
            }

            //
            //    Get Controller
            //
            Controller = reader.ReadInt32();
        }
    }
}