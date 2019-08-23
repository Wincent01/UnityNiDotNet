using System.IO;

namespace Fdb
{
    public class FdbColumnHeader : FdbData
    {
        public FdbColumnHeader(BinaryReader reader)
        {
            ColumnCount = reader.ReadUInt32();

            TableName = new FdbString(reader);

            using (new FdbScope(reader))
            {
                Data = new FdbColumnData(reader, this);
            }
        }

        public uint ColumnCount { get; set; }

        public FdbString TableName { get; set; }

        public FdbColumnData Data { get; set; }

        public override void Write(FdbFile writer)
        {
            writer.WriteObject(this);
            writer.WriteObject(ColumnCount);
            writer.WriteObject(TableName);
            writer.WriteObject(Data);

            TableName.Write(writer);
            Data.Write(writer);
        }
    }
}