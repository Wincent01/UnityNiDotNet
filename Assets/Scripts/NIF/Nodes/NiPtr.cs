namespace NiDotNet.NIF.Nodes
{
    /// <summary>
    /// Pointer to a object higher in file.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NiPtr<T> where T : class
    {
        public int Key { get; set; }

        public T Object => _file.Blocks[Key] as T;

        private readonly NiFile _file;

        public NiPtr(NiFile file, int key)
        {
            _file = file;
            Key = key;
        }

        public static implicit operator T(NiPtr<T> r) => r.Object;
    }
}