namespace NiDotNet.NIF.Nodes
{
    /// <summary>
    /// Reference to a object lower in the file.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NiRef<T> where T : class
    {
        public int Key { get; set; }

        public T Object => _file.Blocks[Key] as T;

        private readonly NiFile _file;

        public NiRef(NiFile file, int key)
        {
            _file = file;
            Key = key;
        }

        public static implicit operator T(NiRef<T> r) => r.Object;
    }
}