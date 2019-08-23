using System;
using System.IO;

namespace NiDotNet.NIF.Nodes
{
    [Serializable]
    public class NiString
    {
        public readonly string String;

        public readonly bool Wide;

        public readonly bool Small;

        public NiString(BinaryReader reader, bool wide = false, bool small = false)
        {
            Wide = wide;
            Small = small;

            var len = small ? reader.ReadByte() : reader.ReadUInt32();
            var str = new char[len];

            for (var i = 0; i < len; i++)
            {
                str[i] = (char) (wide ? reader.ReadUInt16() : reader.ReadByte());
            }

            String = new string(str);
        }

        public NiString(string str, bool wide = false, bool small = false)
        {
            String = str;
            Wide = wide;
            Small = small;
        }

        public static implicit operator string(NiString niString) => niString.String;

        public override string ToString()
        {
            return String;
        }
    }
}