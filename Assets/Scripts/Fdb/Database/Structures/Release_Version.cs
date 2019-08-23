using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class Release_Version
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public string ReleaseVersion
		{
			get => (string) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public long ReleaseDate
		{
			get => (long) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public Release_Version(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "Release_Version");
		}
	}
}
