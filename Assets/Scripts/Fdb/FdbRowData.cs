using System;
using System.IO;
using Fdb.Enums;

namespace Fdb
{
    public class FdbRowData : FdbData
    {
        public FdbRowData(FdbRowDataHeader header)
        {
            Types = new DataType[header.ColumnCount];
            Data = new object[header.ColumnCount];
        }
        
        public FdbRowData(BinaryReader reader, FdbRowDataHeader header)
        {
            Types = new DataType[header.ColumnCount];
            Data = new object[header.ColumnCount];

            for (var i = 0; i < header.ColumnCount; i++)
            {
                Types[i] = (DataType) reader.ReadUInt32();

                switch (Types[i])
                {
                    case DataType.Nothing:
                        Data[i] = reader.ReadInt32();
                        break;
                    case DataType.Integer:
                        Data[i] = reader.ReadInt32();
                        break;
                    case DataType.Unknown1:
                        Data[i] = reader.ReadInt32();
                        break;
                    case DataType.Float:
                        Data[i] = reader.ReadSingle();
                        break;
                    case DataType.Text:
                        Data[i] = new FdbString(reader);
                        break;
                    case DataType.Boolean:
                        Data[i] = reader.ReadInt32() != 0;
                        break;
                    case DataType.Bigint:
                        Data[i] = new FdbBitInt(reader);
                        break;
                    case DataType.Unknown2:
                        Data[i] = reader.ReadInt32();
                        break;
                    case DataType.Varchar:
                        Data[i] = new FdbString(reader);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public DataType[] Types { get; set; }

        public object[] Data { get; set; }

        public override void Write(FdbFile writer)
        {
            writer.WriteObject(this);

            for (var i = 0; i < Types.Length; i++)
            {
                writer.WriteObject((uint) Types[i]);
                writer.WriteObject(Data[i]);
            }

            foreach (var o in Data)
                if (o is FdbData data)
                    data.Write(writer);
        }
    }
}