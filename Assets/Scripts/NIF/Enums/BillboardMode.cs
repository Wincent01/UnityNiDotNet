namespace NiDotNet.NIF.Enums
{
    public enum BillboardMode : ushort
    {
        AlwaysFaceCamera, //Align billboard and camera forward vector. Minimized rotation.
        RotateAboutUp, //Align billboard and camera forward vector while allowing rotation around the up axis.
        RigidFaceCamera, //Align billboard and camera forward vector. Non-minimized rotation.
        AlwaysFaceCenter, //Billboard forward vector always faces camera ceneter. Minimized rotation.
        RigidFaceCenter, //Billboard forward vector always faces camera ceneter. Non-minimized rotation.
        BsrotateAboutUp, //The billboard will only rotate around its local Z axis (it always stays in its local X-Y plane).
        RotateAboutUp2 = 9, //The billboard will only rotate around the up axis (same as ROTATE_ABOUT_UP?).
    }
}