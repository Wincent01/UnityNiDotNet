using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class ObjectBehaviors
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public long BehaviorID
		{
			get => (long) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string xmldata
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public ObjectBehaviors(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "ObjectBehaviors");
		}
	}
}
