using System.IO;

namespace Fdb
{
    public class FdbRowHeader : FdbData
    {
        public FdbRowHeader(BinaryReader reader, FdbRowBucket rowBucket)
        {
            RowInfos = new FdbRowInfo[rowBucket.RowCount];

            for (var i = 0; i < rowBucket.RowCount; i++)
                using (var s = new FdbScope(reader, true))
                {
                    if (s) RowInfos[i] = new FdbRowInfo(reader);
                }
        }

        public FdbRowInfo[] RowInfos;

        public override void Write(FdbFile writer)
        {
            writer.WriteObject(this);
            foreach (var rowInfo in RowInfos) writer.WriteObject(rowInfo);

            foreach (var rowInfo in RowInfos) rowInfo?.Write(writer);
        }
    }
}