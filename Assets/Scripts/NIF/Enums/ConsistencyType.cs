namespace NiDotNet.NIF.Enums
{
    public enum ConsistencyType : ushort
    {
        CtMutable = 0x0000, // Mutable Mesh
        CtStatic = 0x4000, // Static Mesh
        CtVolatile = 0x8000 // Volatile Mesh
    }
}