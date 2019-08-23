using System;
using System.IO;
using UnityEngine;

namespace NiDotNet.NIF.Nodes
{
    public class NiPixelData : NiPixelFormat
    {
        public NiRef<NiPalette> Pallet { get; set; }
        
        public uint MipMapCount { get; set; }
        
        public uint BytesPerPixel { get; set; }
        
        public NiMipMap[] MipMaps { get; set; }

        public uint PixelCount { get; set; }
        
        public uint FacesCount { get; set; }
        
        public byte[] PixelData { get; set; }

        public NiPixelData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Pallet = new NiRef<NiPalette>(niFile, reader.ReadInt32());

            MipMapCount = reader.ReadUInt32();

            BytesPerPixel = reader.ReadUInt32();
            
            MipMaps = new NiMipMap[MipMapCount];

            for (var i = 0; i < MipMapCount; i++)
            {
                MipMaps[i] = new NiMipMap(reader, niFile);
            }

            PixelCount = reader.ReadUInt32();

            FacesCount = reader.ReadUInt32();
            
            PixelData = new byte[PixelCount];

            for (var i = 0; i < PixelCount; i++)
            {
                PixelData[i] = reader.ReadByte();
            }
        }
    }
}