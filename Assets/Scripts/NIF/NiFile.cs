using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NiDotNet.NIF.Nodes;

namespace NiDotNet.NIF
{
    /// <summary>
    /// A .NIF block structured file.
    /// </summary>
    public class NiFile : IDisposable
    {
        /// <summary>
        /// The data for this nif file.
        /// </summary>
        private readonly BinaryReader Reader;

        /// <summary>
        /// The nif header file.
        /// </summary>
        public readonly NiHeader Header;

        /// <summary>
        /// All blocks in this nif file.
        /// </summary>
        public readonly List<NiObject> Blocks = new List<NiObject>();

        /// <summary>
        /// All block types in this Assembly.
        /// </summary>
        private readonly Type[] _blockTypes;

        public NiFile(string file) : this(new BinaryReader(File.OpenRead(file)))
        {
        }

        public NiFile(BinaryReader reader)
        {
            //
            //    Collect all NiObjects in this Assembly.
            //
            _blockTypes = (from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.IsClass && t.Namespace == "NiDotNet.NIF.Nodes"
                select t).ToArray();

            Reader = reader;

            //
            //    Read Header.
            //
            Header = new NiHeader(reader, this);

            //
            //    Read all the blocks in this .nif file.
            //
            ReadNiObjects();

            //    The Footer has nothing important for now.
        }

        private void ReadNiObjects()
        {
            for (var index = 0; index < Header.BlockInfos.Length; index++)
            {
                var blockInfo = Header.BlockInfos[index];
                var typeName = Header.ObjectTypes[blockInfo.TypeIndex];

                //
                //    Find type for this block.
                //    Naming nodes and putting them in the correct namespace is important to make sure they are found.
                //
                var type = _blockTypes.FirstOrDefault(t => t.Name == typeName);

                if (type == null)
                {
                    throw new NotImplementedException($"Type NiDotNet.NIF.Nodes.{typeName} is not implemented.");
                }

                //
                //    Read block info binary reader to be handled async.
                //    TODO: Add async, none async is better for debugging.
                //
                var blockReader = new BinaryReader(new MemoryStream(Reader.ReadBytes((int) blockInfo.Size)));

                //Debug.Log($"[{index}/{Header.BlockInfos.Length}] {type}: {blockInfo.Size}/{Reader.BaseStream.Length - Reader.BaseStream.Position}");
                
                //
                //    Create instance of this NiObject and start reading.
                //
                var instance = (NiObject) Activator.CreateInstance(type, blockReader, this);

                //Debug.Log($"[{index}/{Header.BlockInfos.Length}] {type}: {blockReader.BaseStream.Position}/{blockReader.BaseStream.Length}");

                //
                //    Keep track of block as it may be referenced or pointed to by other blocks.
                //
                Blocks.Add(instance);
            }
        }

        /// <summary>
        /// Get Objects from Int Array.
        /// </summary>
        /// <param name="points">Pointers</param>
        /// <returns>Objects that the pointers pointed to.</returns>
        public IEnumerable<NiObject> FromIntArray(int[] points)
        {
            var arr = new NiObject[points.Length];
            for (var i = 0; i < points.Length; i++)
            {
                arr[i] = this[points[i]];
            }

            return arr;
        }

        /// <summary>
        /// Access the blocks directly though this NiFile.
        /// </summary>
        /// <param name="i">Index</param>
        public NiObject this[int i] => Blocks[i];

        public void Dispose()
        {
            Reader.Dispose();
        }
    }
}