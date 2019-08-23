using System.IO;
using Fdb.Enums;

namespace Fdb
{
    public class FdbColumnData : FdbData
    {
        public FdbColumnData(BinaryReader reader, FdbColumnHeader header)
        {
            Type = new DataType[header.ColumnCount];
            ColumnName = new FdbString[header.ColumnCount];

            for (var i = 0; i < header.ColumnCount; i++)
            {
                Type[i] = (DataType) reader.ReadUInt32();
                ColumnName[i] = new FdbString(reader);
            }
        }

        public DataType[] Type { get; set; }

        public FdbString[] ColumnName { get; set; }

        public override void Write(FdbFile writer)
        {
            writer.WriteObject(this);
            for (var i = 0; i < Type.Length; i++)
            {
                writer.WriteObject((uint) Type[i]);
                writer.WriteObject(ColumnName[i]);
            }

            foreach (var s in ColumnName) s.Write(writer);
        }
    }
}