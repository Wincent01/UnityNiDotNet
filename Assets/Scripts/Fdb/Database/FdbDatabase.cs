namespace Fdb.Database
{
    public class FdbDatabase
    {
        public readonly Table[] Tables;
        
        public FdbDatabase(FdbFile file)
        {
            Tables = new Table[file.TableCount];

            for (var i = 0; i < file.TableCount; i++)
            {
                Tables[i] = new Table(file.TableHeader.ColumnHeaders[i], file.TableHeader.RowTopHeaders[i]);
            }
        }
    }
}