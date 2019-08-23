namespace NiDotNet.NIF.Enums
{
    public enum AlphaFormat : uint
    {
        AlphaNone, // No alpha.
        AlphaBinary, // 1-bit alpha.
        AlphaSmooth, // Interpolated 4- or 8-bit alpha.
        AlphaDefault // Use default setting.
    }
}