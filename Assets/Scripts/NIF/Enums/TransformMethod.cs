namespace NiDotNet.NIF.Enums
{
    public enum TransformMethod
    {
        TmMayaDeprecated, //Center * Rotation * Back * Translate * Scale
        TmMax, // Center * Scale * Rotation * Translate * Back
        TmMaya // Center * Rotation * Back * FromMaya * Translate * Scale
    }
}