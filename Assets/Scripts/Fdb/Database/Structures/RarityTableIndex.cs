using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class RarityTableIndex
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int RarityTableIndexField
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public RarityTableIndex(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "RarityTableIndex");
		}
	}
}
