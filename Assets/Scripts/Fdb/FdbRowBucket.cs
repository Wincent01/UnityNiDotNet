using System.IO;

namespace Fdb
{
    public class FdbRowBucket : FdbData
    {
        public FdbRowBucket(BinaryReader reader)
        {
            RowCount = reader.ReadUInt32();

            using (var s = new FdbScope(reader, true))
            {
                if (s) RowHeader = new FdbRowHeader(reader, this);
            }
        }

        public uint RowCount;

        public FdbRowHeader RowHeader { get; set; }

        public override void Write(FdbFile writer)
        {
            writer.WriteObject(this);
            writer.WriteObject(RowCount);
            writer.WriteObject(RowHeader);

            RowHeader?.Write(writer);
        }
    }
}