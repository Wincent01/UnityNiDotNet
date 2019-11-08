using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Raw
{
    public class HeightMap
    {
        public int Width { get; set; }
        
        public int Height { get; set; }
        
        public float UnknownFloat0 { get; set; }
        public float UnknownFloat1 { get; set; }
        public float UnknownFloat2 { get; set; }
        
        public int[] UnknownIntArray { get; set; }
        
        public float[] Data { get; set; }

        public HeightMap(BinaryReader reader)
        {
            Width = reader.ReadInt32();
            Height = reader.ReadInt32();

            UnknownFloat0 = reader.ReadSingle();
            UnknownFloat1 = reader.ReadSingle();
            
            UnknownIntArray = new int[4];

            for (var i = 0; i < 4; i++)
            {
                UnknownIntArray[i] = reader.ReadInt32();
            }
            
            UnknownFloat2 = reader.ReadSingle();

            Data = new float[Width * Height];

            for (var i = 0; i < Data.Length; i++)
            {
                Data[i] = reader.ReadSingle();
            }
        }

        public float GetValue(int x, int y)
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

            var min = Data.Min();
            var max = Data.Max();

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    var value = Data[y * Width + x];

                    var number = (float) (byte.MaxValue * Mathf.InverseLerp(min, max, value) / 255d);
                    
                    texture.SetPixel(x, y, new Color
                    {
                        r = number,
                        g = number,
                        b = number
                    });
                }
            }

            texture.Apply();
            
            return texture;
        }
    }
}