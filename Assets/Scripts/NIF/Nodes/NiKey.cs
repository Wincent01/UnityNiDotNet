using System;
using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class NiKey<T> : NiObject
    {
        public float Time { get; set; }

        public T Value { get; set; }

        public T Forward { get; set; }

        public T Backwards { get; set; }

        public NiTBC TBC { get; set; }

        public NiKey(BinaryReader reader, NiFile niFile, KeyType type) : base(reader, niFile)
        {
            Time = reader.ReadSingle();

            Value = (T) Activator.CreateInstance(typeof(T), reader, niFile);

            if (type == (KeyType) 2)
            {
                Forward = (T) Activator.CreateInstance(typeof(T), reader, niFile);
                Backwards = (T) Activator.CreateInstance(typeof(T), reader, niFile);
            }

            if (type == (KeyType) 3)
                TBC = new NiTBC(reader, niFile);
        }
    }
}