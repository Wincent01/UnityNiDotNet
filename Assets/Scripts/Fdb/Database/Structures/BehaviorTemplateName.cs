using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class BehaviorTemplateName
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int templateID
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string name
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public BehaviorTemplateName(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "BehaviorTemplateName");
		}
	}
}
