using System.Linq;
using NiEditorApplication.Editor;

namespace Fdb.Database
{
	class DBExclude
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public string table
		{
			get => (string) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string column
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public DBExclude(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "DBExclude");
		}
	}
}
