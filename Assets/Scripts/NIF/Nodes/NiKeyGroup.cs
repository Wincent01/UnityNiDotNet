using System.IO;
using NiDotNet.NIF.Enums;
using UnityEngine;

namespace NiDotNet.NIF.Nodes
{
    public class NiKeyGroup<T> : NiObject
    {
        public uint KeyCount { get; set; }

        public KeyType Type { get; set; }

        public NiKey<T>[] Keys { get; set; }

        public NiKeyGroup(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            KeyCount = reader.ReadUInt32();

            if (KeyCount != 0)
                Type = (KeyType) reader.ReadUInt32();

            Keys = new NiKey<T>[KeyCount];
            for (var i = 0; i < KeyCount; i++)
            {
                Keys[i] = new NiKey<T>(reader, niFile, Type);
            }
        }
    }
}