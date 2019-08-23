using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiBoolean
    {
        public byte Source { get; set; }

        public bool Value { get; set; }

        public NiBoolean(bool value)
        {
            Source = (byte) (value ? 1 : 0);
            Value = value;
        }

        public NiBoolean(BinaryReader reader)
        {
            Source = reader.ReadByte();
            switch (Source)
            {
                case 0:
                    Value = false;
                    break;
                default:
                    Value = true;
                    break;
                /*
                case 1:
                    Value = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{Source} is not a vaild boolean.");
                    */
            }
        }

        public static implicit operator bool(NiBoolean boolean) => boolean.Value;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}