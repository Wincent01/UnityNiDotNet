using System.IO;
using System.Text;

namespace Raw
{
    public class Chunk
    {
        public int ChunkIndex { get; set; }
        
        public HeightMap Heighmap { get; set; }
        
        public ColorMap Colormap0 { get; set; }
        
        public DDS Lightmap { get; set; }
        
        public ColorMap Colormap1 { get; set; }

        public byte UnknownByte { get; set; }
        
        public DDS Blendmap { get; set; }
        
        public WeirdStruct[] WeirdStructs { get; set; }
        
        public byte[] UnknownByteArray { get; set; }
        
        public ShortMap ShortMap { get; set; }
        
        public short[][] UnknownShortArray { get; set; }

        public Chunk(BinaryReader reader)
        {
            ChunkIndex = reader.ReadInt32();

            Heighmap = new HeightMap(reader);
            
            Colormap0 = new ColorMap(reader);
            
            Lightmap = new DDS(reader);
            
            Colormap1 = new ColorMap(reader);

            UnknownByte = reader.ReadByte();
            
            Blendmap = new DDS(reader);

            WeirdStructs = new WeirdStruct[reader.ReadInt32()];

            for (var i = 0; i < WeirdStructs.Length; i++)
            {
                WeirdStructs[i] = new WeirdStruct(reader);
            }

            UnknownByteArray = reader.ReadBytes(Colormap0.Width * Colormap0.Height);
            
            ShortMap = new ShortMap(reader);
            
            if (ShortMap.Data.Length == default) return;

            reader.BaseStream.Position += 32;

            UnknownShortArray = new short[16][];

            for (var i = 0; i < 16; i++)
            {
                var length = reader.ReadInt16();
                UnknownShortArray[i] = new short[length];

                for (var j = 0; j < length; j++)
                {
                    UnknownShortArray[i][j] = reader.ReadInt16();
                }
            }
        }
        
        public override string ToString()
        {
            var str = new StringBuilder();
            foreach (var property in GetType().GetProperties())
            {
                str.AppendLine($"{property.Name} = {property.GetValue(this)}");
            }

            return str.ToString();
        }

    }
}