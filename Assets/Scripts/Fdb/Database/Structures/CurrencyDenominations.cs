using System.Linq;
using NiEditorApplication.Editor;

namespace Fdb.Database
{
	class CurrencyDenominations
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int value
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int objectid
		{
			get => (int) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public CurrencyDenominations(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "CurrencyDenominations");
		}
	}
}
