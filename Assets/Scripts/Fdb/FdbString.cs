using System.IO;
using System.Text;

namespace Fdb
{
    public class FdbString : FdbData
    {
        public FdbString(string value)
        {
            Value = value;
        }
        
        public FdbString(BinaryReader reader)
        {
            var builder = new StringBuilder();

            using (new FdbScope(reader))
            {
                while (true)
                {
                    var c = reader.ReadByte();
                    if (c == 0) break;
                    builder.Append((char) c);
                }
            }

            Value = builder.ToString();
        }

        public string Value { get; set; }

        public static implicit operator string(FdbString s)
        {
            return s.Value;
        }

        public override string ToString()
        {
            return Value;
        }

        public override void Write(FdbFile writer)
        {
            writer.WriteObject(this);
            foreach (var c in Value) writer.WriteObject((byte) c);

            writer.WriteObject((byte) 0);
        }
    }
}