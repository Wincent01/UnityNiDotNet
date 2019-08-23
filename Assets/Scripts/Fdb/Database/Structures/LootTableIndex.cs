using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class LootTableIndex
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int LootTableIndexField
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public LootTableIndex(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "LootTableIndex");
		}
	}
}
