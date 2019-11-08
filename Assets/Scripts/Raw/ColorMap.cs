using System.IO;
using System.Text;
using UnityEngine;

namespace Raw
{
    public class ColorMap
    {
        public int Width { get; set; }
        
        public int Height { get; set; }
        
        public uint[] Data { get; set; }
        
        public ColorMap(BinaryReader reader)
        {
            Width = Height = reader.ReadInt32();
            
            Data = new uint[Width * Height];

            for (var i = 0; i < Data.Length; i++)
            {
                Data[i] = reader.ReadUInt32();
            }
        }

        public uint GetValue(int x, int y)
        {
            return Data[y * Width + x];
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

        public Texture2D Render()
        {
            var texture = new Texture2D(Width, Height);

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    var reference = Data[y * Width + x];
                    texture.SetPixel(x, y, new Color
                    {
                        a = (float) ((reference >> 24) / 255d),
                        r = (float) ((reference >> 16) / 255d),
                        g = (float) ((reference >> 8) / 255d),
                        b = (float) (reference / 255d)
                    });
                }
            }
            
            texture.Apply();

            return texture;
        }
    }
}