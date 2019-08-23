namespace NiDotNet.NIF.Enums
{
    public enum PixelFormat : uint
    {
        PxFmtRgb, 	        // 24-bit RGB. 8 bits per red, blue, and green component.
        PxFmtRgba, 	        // 32-bit RGB with alpha. 8 bits per red, blue, green, and alpha component.
        PxFmtPal, 	        // 8-bit palette index.
        PxFmtPala, 	        // 8-bit palette index with alpha.
        PxFmtDxt1, 	        // DXT1 compressed texture.
        PxFmtDxt3, 	        // DXT3 compressed texture.
        PxFmtDxt5, 	        // DXT5 compressed texture.
        PxFmtRgb24Nonint, 	// (Deprecated) 24-bit noninterleaved texture, an old PS2 format.
        PxFmtBump, 	        // Uncompressed dU/dV gradient bump map.
        PxFmtBumpluma, 	    // Uncompressed dU/dV gradient bump map with luma channel representing shininess.
        PxFmtRenderspec, 	    // Generic descriptor for any renderer-specific format not described by other formats.
        PxFmt1Ch, 	        // Generic descriptor for formats with 1 component.
        PxFmt2Ch, 	        // Generic descriptor for formats with 2 components.
        PxFmt3Ch, 	        // Generic descriptor for formats with 3 components.
        PxFmt4Ch, 	        // Generic descriptor for formats with 4 components.
        PxFmtDepthStencil, 	// Indicates the NiPixelFormat is meant to be used on a depth/stencil surface.
        PxFmtUnknown, 	    // PX_FMT_UNKNOWN
    }
}