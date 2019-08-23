using System;
using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class QuatKey<T> : NiObject where T : NiObject
    {
        public float Time { get; set; }

        public T Value { get; set; }

        public NiTBC TBC { get; set; }

        public QuatKey(BinaryReader reader, NiFile niFile, KeyType type) : base(reader, niFile)
        {
            if (type != (KeyType) 4)
            {
                Time = reader.ReadSingle();
                Value = (T) Activator.CreateInstance(typeof(T), reader, niFile);
            }

            if (type == (KeyType) 3)
                TBC = new NiTBC(reader, niFile);
        }
    }
}