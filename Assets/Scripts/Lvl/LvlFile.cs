using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Luz;

namespace Lvl
{
    public class LvlFile
    {
        public uint LvlVersion { get; set; }
        
        public Chunk1000[] Chunks1000 { get; set; }
        
        public Chunk2000[] Chunks2000 { get; set; }
        
        public Chunk2001[] Chunks2001 { get; set; }
        
        public LvlFile(string path)
        {
            var reader = new BinaryReader(File.OpenRead(path));

            var magic = new string(reader.ReadBytes(4).Select(s => (char) s).ToArray());

            if (magic != "CHNK") throw new NotImplementedException("Older LVL files not yet supported.");

            var chunks1000 = new List<Chunk1000>();
            var chunks2000 = new List<Chunk2000>();
            var chunks2001 = new List<Chunk2001>();
            
            reader.BaseStream.Position = 0;
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                var startPos = reader.BaseStream.Position;

                magic = new string(reader.ReadBytes(4).Select(s => (char) s).ToArray());
                if (startPos % 16 != 0 || magic != "CHNK") break;

                var chunkType = reader.ReadUInt32();
                
                reader.ReadUInt16();
                reader.ReadUInt16();

                var chunkLength = reader.ReadUInt32();

                reader.BaseStream.Position = reader.ReadUInt32();
                
                if (reader.BaseStream.Position % 16 != 0) break;
                
                switch (chunkType)
                {
                    case 1000:
                        var chunk1000 = new Chunk1000(reader);
                        LvlVersion = chunk1000.LvlVersion;
                        chunks1000.Add(chunk1000);
                        break;
                    case 2000:
                        chunks2000.Add(new Chunk2000(reader));
                        break;
                    case 2001:
                        chunks2001.Add(new Chunk2001(reader, LvlVersion));
                        break;
                    case 2002:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"{chunkType} is not a valid chunk type.");
                }

                reader.BaseStream.Position = startPos + chunkLength;
            }

            Chunks1000 = chunks1000.ToArray();
            Chunks2000 = chunks2000.ToArray();
            Chunks2001 = chunks2001.ToArray();
        }
    }
}