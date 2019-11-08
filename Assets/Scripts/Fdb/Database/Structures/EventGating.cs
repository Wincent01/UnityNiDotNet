using System.Linq;
using NiEditorApplication.Editor;

namespace Fdb.Database
{
	class EventGating
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public string eventName
		{
			get => (string) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public long date_start
		{
			get => (long) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public long date_end
		{
			get => (long) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public EventGating(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "EventGating");
		}
	}
}
