namespace NiDotNet.NIF.Enums
{
    public enum KeyType : uint
    {
        None = 0,
        LinearKey = 1, // Use linear interpolation.
        QuadraticKey, // Use quadratic interpolation. Forward and back tangents will be stored.
        TbcKey, // Use Tension Bias Continuity interpolation. Tension, bias, and continuity will be stored.
        XyzRotationKey, // For use only with rotation data. Separate X, Y, and Z keys will be stored instead of using quaternions.
        ConstKey // Step function. Used for visibility keys in NiBoolData.
    }
}