using System.IO;
using System.Text;
using UnityEngine;

namespace Raw
{
    public class WeirdStruct
    {
        public int Type { get; set; }
        
        public Vector3 Position { get; set; }
        
        public Quaternion Rotation { get; set; }
        
        public uint UnknownInt { get; set; }

        public WeirdStruct(BinaryReader reader)
        {
            Type = reader.ReadInt32();
            var rotW = reader.ReadSingle();
            
            Position = new Vector3
            {
                x = reader.ReadSingle(),
                y = reader.ReadSingle(),
                z = reader.ReadSingle()
            };
            
            Rotation = new Quaternion
            {
                x = reader.ReadSingle(),
                y = reader.ReadSingle(),
                z = reader.ReadSingle(),
                w = rotW
            };

            UnknownInt = reader.ReadUInt32();
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