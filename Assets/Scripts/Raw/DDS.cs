using System.IO;

namespace Raw
{
    public class DDS
    {
        public byte[] Data { get; set; }

        public DDS(BinaryReader reader)
        {
            Data = reader.ReadBytes(reader.ReadInt32());
        }

        public override string ToString()
        {
            return $"DDS: {Data.Length}";
        }
    }
}