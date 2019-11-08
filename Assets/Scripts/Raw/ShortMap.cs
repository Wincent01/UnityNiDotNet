using System.IO;

namespace Raw
{
    public class ShortMap
    {
        public short[] Data { get; set; }

        public ShortMap(BinaryReader reader)
        {
            Data = new short[reader.ReadInt32()];

            for (var i = 0; i < Data.Length; i++)
            {
                Data[i] = reader.ReadInt16();
            }
        }

        public override string ToString()
        {
            return $"ShortMap: {Data.Length}";
        }
    }
}