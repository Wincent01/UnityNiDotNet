using System.IO;

namespace Fdb
{
    public class FdbBitInt : FdbData
    {
        public FdbBitInt(long value)
        {
            Value = value;
        }
        
        public FdbBitInt(BinaryReader reader)
        {
            using (var s = new FdbScope(reader, true))
            {
                if (s) Value = reader.ReadInt64();
            }
        }

        public long Value { get; set; }

        public override void Write(FdbFile writer)
        {
            writer.WriteObject(this);
            writer.WriteObject(Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}