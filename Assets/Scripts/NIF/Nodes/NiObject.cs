using System.IO;

namespace NiDotNet.NIF.Nodes
{
    /// <summary>
    /// Base class for all Nif blocks.
    /// </summary>
    public class NiObject
    {
        public readonly BinaryReader Reader;

        public readonly NiFile File;

        public NiObject(BinaryReader reader, NiFile niFile)
        {
            Reader = reader;
            File = niFile;
        }
    }
}