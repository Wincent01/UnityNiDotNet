using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiCamera : NiAVObject
    {
        public ushort CameraFlags { get; set; }

        public float FrustumLeft { get; set; }

        public float FrustumRight { get; set; }

        public float FrustumTop { get; set; }

        public float FrustumBottom { get; set; }

        public float FrustumNear { get; set; }

        public float FrustumFar { get; set; }

        public NiBoolean UseOrthographicProjection { get; set; }

        public float ViewportLeft { get; set; }

        public float ViewportRight { get; set; }

        public float ViewportTop { get; set; }

        public float ViewportBottom { get; set; }

        public float LODAdjust { get; set; }

        public NiRef<NiAVObject> Scene { get; set; }

        public uint ScreenPolygonsCount { get; set; }

        public uint ScreenTexturesCount { get; set; }

        public NiCamera(BinaryReader reader, NiFile file) : base(reader, file)
        {
            CameraFlags = reader.ReadUInt16();

            FrustumLeft = reader.ReadSingle();

            FrustumRight = reader.ReadSingle();

            FrustumTop = reader.ReadSingle();

            FrustumBottom = reader.ReadSingle();

            FrustumNear = reader.ReadSingle();

            FrustumFar = reader.ReadSingle();

            UseOrthographicProjection = new NiBoolean(reader);

            ViewportLeft = reader.ReadSingle();

            ViewportRight = reader.ReadSingle();

            ViewportTop = reader.ReadSingle();

            ViewportBottom = reader.ReadSingle();

            LODAdjust = reader.ReadSingle();

            Scene = new NiRef<NiAVObject>(file, reader.ReadInt32());

            ScreenPolygonsCount = reader.ReadUInt32();

            ScreenTexturesCount = reader.ReadUInt32();
        }
    }
}