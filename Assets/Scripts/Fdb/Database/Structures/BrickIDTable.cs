using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class BrickIDTable
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int NDObjectID
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int LEGOBrickID
		{
			get => (int) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public BrickIDTable(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "BrickIDTable");
		}
	}
}
