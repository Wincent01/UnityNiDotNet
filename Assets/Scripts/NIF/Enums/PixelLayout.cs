namespace NiDotNet.NIF.Enums
{
    public enum PixelLayout : uint
    {
        PxLayPalettized8, //Texture is in 8-bit palettized format.
        PxLayHighColor16, //Texture is in 16-bit high color format.
        PxLayTrueColor32, //Texture is in 32-bit true color format.
        PxLayCompressed, //Texture is compressed.
        PxLayBumpmap, //Texture is a grayscale bump map.
        PxLayPalettized4, //Texture is in 4-bit palettized format.
        PxLayDefault, //Use default setting.
        PxLaySingleColor8, //PX_LAY_SINGLE_COLOR_8
        PxLaySingleColor16, //PX_LAY_SINGLE_COLOR_16
        PxLaySingleColor32, //PX_LAY_SINGLE_COLOR_32
        PxLayDoubleColor32, //PX_LAY_DOUBLE_COLOR_32
        PxLayDoubleColor64, //PX_LAY_DOUBLE_COLOR_64
        PxLayFloatColor32, //PX_LAY_FLOAT_COLOR_32
        PxLayFloatColor64, //PX_LAY_FLOAT_COLOR_64
        PxLayFloatColor128, //PX_LAY_FLOAT_COLOR_128
        PxLaySingleColor4, //PX_LAY_SINGLE_COLOR_4
        PxLayDepth24X8 //PX_LAY_DEPTH_24_X8
    }
}