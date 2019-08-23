namespace NiDotNet.NIF.Enums
{
    public enum VectorFlags : ushort
    {
        VfUv1 = 0x00000001,
        VfUv2 = 0x00000002,
        VfUv4 = 0x00000004,
        VfUv8 = 0x00000008,
        VfUv16 = 0x00000010,
        VfUv32 = 0x00000020,
        VfUnk64 = 0x00000040,
        VfUnk128 = 0x00000080,
        VfUnk256 = 0x00000100,
        VfUnk512 = 0x00000200,
        VfUnk1024 = 0x00000400,
        VfUnk2048 = 0x00000800,
        VfHasTangents = 0x00001000,
        VfUnk8192 = 0x00002000,
        VfUnk16384 = 0x00004000,
        VfUnk32768 = 0x00008000
    }
}