using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class LUPZoneIDs
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int zoneID
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public LUPZoneIDs(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "LUPZoneIDs");
		}
	}
}
