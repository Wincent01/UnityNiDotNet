namespace NiDotNet.NIF.Enums
{
    public enum TexType : uint
    {
        BaseMap, // The basic texture used by most meshes.
        DarkMap, // Used to darken the model with false lighting.
        DetailMap, // Combined with base map for added detail. Usually tiled over the mesh many times for close-up view.
        GlossMap, // Allows the specularity (glossyness) of an object to differ across its surface.
        GlowMap, // Creates a glowing effect. Basically an incandescence map.
        BumpMap, // Used to make the object appear to have more detail than it really does.
        NormalMap, // Used to make the object appear to have more detail than it really does.
        ParallaxMap, // Parallax map.
        Decal0Map, // For placing images on the object like stickers.
        Decal1Map, // For placing images on the object like stickers.
        Decal2Map, // For placing images on the object like stickers.
        Decal3Map, // For placing images on the object like stickers.
    }
}