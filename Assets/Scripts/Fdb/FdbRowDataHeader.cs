using System.IO;

namespace Fdb
{
    public class FdbRowDataHeader : FdbData
    {
        public FdbRowDataHeader()
        {
            
        }
        
        public FdbRowDataHeader(BinaryReader reader)
        {
            ColumnCount = reader.ReadUInt32();

            using (var s = new FdbScope(reader, true))
            {
                if (s) Data = new FdbRowData(reader, this);
            }
        }

        public uint ColumnCount { get; set; }

        public FdbRowData Data { get; set; }

        public override void Write(FdbFile writer)
        {
            writer.WriteObject(this);
            writer.WriteObject(ColumnCount);
            writer.WriteObject(Data);

            Data?.Write(writer);
        }
    }
}