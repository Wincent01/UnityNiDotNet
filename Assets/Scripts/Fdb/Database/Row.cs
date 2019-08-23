using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Fdb.Database
{
    public class Row
    {
        internal readonly FdbRowInfo Info;
        
        private readonly Field[] _fields;

        public ReadOnlyCollection<Field> Fields => Array.AsReadOnly(_fields);
        
        internal Row(FdbRowInfo info)
        {
            Info = info;
            
            _fields = new Field[info.DataHeader.ColumnCount];

            for (var i = 0; i < info.DataHeader.ColumnCount; i++)
            {
                var data = info.DataHeader.Data;

                _fields[i] = new Field(data.Types[i], data.Data[i]);
            }
        }

        public Row(Field[] fields)
        {
            _fields = fields;
            
            Info = new FdbRowInfo
            {
                Linked = default,
                DataHeader = new FdbRowDataHeader
                {
                    ColumnCount = (uint) fields.Length
                }
            };

            Info.DataHeader.Data = new FdbRowData(Info.DataHeader)
            {
                Data = fields.Select(f => f.Value).ToArray(),
                Types = fields.Select(f => f.DataType).ToArray()
            };
        }
    }
}