using System.IO;
using NiDotNet.NIF.Data;
using NiDotNet.NIF.Enums;
using NiDotNet.NIF.Nodes;

namespace NiDotNet.NIF
{
    public class NiHeader
    {
        public readonly NiVersion NifVersion;

        public readonly Endian EndianType;

        public readonly string NifVersionString;

        public readonly uint UserVersion;

        public readonly BlockInfo[] BlockInfos;

        public readonly NiString[] ObjectTypes;

        public readonly uint MaxStringLength;

        public readonly NiString[] Strings;

        public readonly uint[] Groups;

        public NiHeader(BinaryReader reader, NiFile niFile)
        {
            var num = 0;
            var position = reader.BaseStream.Position;
            while (reader.ReadByte() != 0xA)
            {
                num++;
            }

            reader.BaseStream.Position = position;

            //
            //    Get NIF file version string
            //
            NifVersionString = new string(reader.ReadChars(num));

            // Skip byte
            reader.ReadByte();

            //
            //    Get NIF file version
            //
            NifVersion = (NiVersion) reader.ReadUInt32();

            //
            //    Get Endian type
            //
            EndianType = (Endian) reader.ReadByte();

            //
            //    Get user version
            //
            UserVersion = reader.ReadUInt32();

            //
            //    Get block count
            //
            BlockInfos = new BlockInfo[reader.ReadUInt32()];

            //
            //    Get number of object types
            //
            ObjectTypes = new NiString[reader.ReadUInt16()];

            //
            //    Read object types
            //
            for (var i = 0; i < ObjectTypes.Length; i++)
            {
                ObjectTypes[i] = new NiString(new string(reader.ReadChars((int) reader.ReadUInt32())));
            }

            //
            //    Get block types
            //
            for (var i = 0; i < BlockInfos.Length; i++)
            {
                BlockInfos[i] = new BlockInfo
                {
                    TypeIndex = reader.ReadUInt16()
                };
            }

            //
            //    Get block size
            //
            foreach (var block in BlockInfos)
            {
                block.Size = reader.ReadUInt32();
            }

            //
            //    Get strings
            //
            Strings = new NiString[reader.ReadUInt32()];

            //
            //    Get string max length
            //
            MaxStringLength = reader.ReadUInt32();

            //
            //    Read strings
            //
            for (var i = 0; i < Strings.Length; i++)
            {
                Strings[i] = new NiString(reader);
            }

            //
            //    Get groups
            //
            Groups = new uint[reader.ReadUInt32()];

            for (var i = 0; i < Groups.Length; i++)
            {
                Groups[i] = reader.ReadUInt32();
            }
        }
    }
}