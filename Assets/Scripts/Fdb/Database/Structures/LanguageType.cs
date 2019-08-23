using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class LanguageType
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int LanguageID
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string LanguageDescription
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public LanguageType(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "LanguageType");
		}
	}
}
