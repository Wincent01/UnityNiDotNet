using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiTimeController : NiObject
    {
        public NiRef<NiTimeController> Next { get; set; }

        public short Flags { get; set; }

        public float Frequency { get; set; }

        public float Phase { get; set; }

        public float StartTime { get; set; }

        public float StopTime { get; set; }

        public NiPtr<NiObjectNet> Target { get; set; }

        public NiTimeController(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Next = new NiRef<NiTimeController>(niFile, reader.ReadInt32());

            Flags = reader.ReadInt16();

            Frequency = reader.ReadSingle();

            Phase = reader.ReadSingle();

            StartTime = reader.ReadSingle();

            StopTime = reader.ReadSingle();

            Target = new NiPtr<NiObjectNet>(niFile, reader.ReadInt32());
        }
    }
}