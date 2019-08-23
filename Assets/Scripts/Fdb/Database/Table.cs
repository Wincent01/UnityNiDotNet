using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Fdb.Database
{
    public class Table
    {
        private readonly FdbColumnHeader _columnHeader;

        private readonly FdbRowBucket _rowBucket;

        private Row[] _rows;

        public readonly ColumnInfo[] Structure;
        
        public string Name => _columnHeader.TableName.Value;

        public ReadOnlyCollection<Row> Rows => Array.AsReadOnly(_rows);

        internal Table(FdbColumnHeader columnHeader, FdbRowBucket bucket)
        {
            Structure = new ColumnInfo[columnHeader.ColumnCount];

            for (var i = 0; i < columnHeader.ColumnCount; i++)
            {
                Structure[i] = new ColumnInfo
                (
                    columnHeader.Data.Type[i],
                    columnHeader.Data.ColumnName[i]
                );
            }
            
            _columnHeader = columnHeader;
            _rowBucket = bucket;

            var rows = new List<Row>();
            for (var index = 0; index < bucket.RowCount; index++)
            {
                var rowInfo = bucket.RowHeader.RowInfos[index];
                var linked = rowInfo;
                while (linked != default)
                {
                    rows.Add(new Row(linked));
                    linked = linked.Linked;
                }
            }

            _rows = rows.ToArray();
        }

        public void AppendRow(Row row)
        {
            if (_rows.Length + 1 > _rowBucket.RowCount)
            {
                _rowBucket.RowCount *= 2;
                
                Array.Resize(ref _rowBucket.RowHeader.RowInfos, (int) _rowBucket.RowCount);
            }

            var found = false;
            for (var i = 0; i < _rowBucket.RowCount; i++)
            {
                if (_rowBucket.RowHeader.RowInfos[i] != null) continue;
                
                _rowBucket.RowHeader.RowInfos[i] = row.Info;

                var rows = _rows.ToList();
                rows.Add(row);
                _rows = rows.ToArray();

                found = true;
                
                break;
            }
            
            if (!found) throw new Exception("Found no empty row");
        }

        public void DeleteRow(Row row)
        {
            var list = _rows.ToList();
            list.Remove(row);
            _rows = list.ToArray();

            Debug.Log($"Removing {row} -> {row.Info}");
            
            var realList = _rowBucket.RowHeader.RowInfos.ToList();
            realList.Remove(row.Info);
            _rowBucket.RowHeader.RowInfos = realList.ToArray();
        }

        public void UpdateRow(Row row)
        {
            var realRow = _rowBucket.RowHeader.RowInfos.FirstOrDefault(i => i == row.Info);
            if (realRow == default)
            {
                AppendRow(row);
                realRow = _rowBucket.RowHeader.RowInfos.First(i => i == row.Info);
            }

            realRow.DataHeader.Data.Data = row.Fields.Select(f => f.Value).ToArray();
            realRow.DataHeader.Data.Types = row.Fields.Select(f => f.DataType).ToArray();
        }
    }
}