using System.Linq;
using NiEditorApplication.Editor;

namespace Fdb.Database
{
	class LootMatrixIndex
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int LootMatrixIndexField
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool inNpcEditor
		{
			get => (bool) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public LootMatrixIndex(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "LootMatrixIndex");
		}
	}
}
