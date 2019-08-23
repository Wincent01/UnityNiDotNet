using System.IO;
using System.Linq;

namespace NiDotNet.NIF.Nodes
{
    public class NiAVObject : NiObjectNet
    {
        public short Flags { get; set; }

        public NiVector3 Position { get; set; }

        public NiMatrix3X3 Rotation { get; set; }

        public float UniformScale { get; set; }

        public int[] Properties { get; set; }

        public uint CollitionObject { get; set; }

        public NiAVObject(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Flags = reader.ReadInt16();

            //
            //    Get position
            //
            Position = new NiVector3(reader, file);

            //
            //    Get rotation
            //
            Rotation = new NiMatrix3X3(reader, file);

            //
            //    Get scale
            //
            UniformScale = reader.ReadSingle();

            //
            //    Get properties
            //
            Properties = new int[reader.ReadInt32()];
            for (var i = 0; i < Properties.Length; i++)
            {
                Properties[i] = reader.ReadInt32();
            }

            //
            //    Get collition object
            //
            CollitionObject = reader.ReadUInt32();
        }

        public T GetProperty<T>()
        {
            return File.FromIntArray(Properties).OfType<T>().FirstOrDefault();
        }

        public T[] GetProperties<T>()
        {
            return File.FromIntArray(Properties).OfType<T>().ToArray();
        }
    }
}