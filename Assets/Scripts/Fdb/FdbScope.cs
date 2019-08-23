using System;
using System.IO;

namespace Fdb
{
    public class FdbScope : IDisposable
    {
        private readonly long _current;
        private readonly int _pointer;
        private readonly BinaryReader _reader;

        public FdbScope(BinaryReader reader, bool signed = false)
        {
            _current = reader.BaseStream.Position + 4;
            _pointer = signed ? reader.ReadInt32() : (int) reader.ReadUInt32();
            if (_pointer != -1) reader.BaseStream.Position = _pointer;
            _reader = reader;
        }

        public void Dispose()
        {
            _reader.BaseStream.Position = _current;
        }

        public static implicit operator bool(FdbScope s)
        {
            return s._pointer != -1;
        }
    }
}