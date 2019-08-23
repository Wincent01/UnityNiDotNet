using Fdb.Enums;

namespace Fdb.Database
{
    public class Field
    {
        public DataType DataType { get; set; }
        
        public object Value { get; set; }
        
        public Field(DataType type, object value)
        {
            DataType = type;
            Value = value;
        }
    }
}