using Fdb.Enums;

namespace Fdb.Database
{
    public struct ColumnInfo
    {
        public readonly DataType Type;

        public readonly string Name;

        internal ColumnInfo(DataType type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}