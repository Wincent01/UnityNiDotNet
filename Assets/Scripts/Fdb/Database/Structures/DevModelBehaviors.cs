using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class DevModelBehaviors
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int ModelID
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int BehaviorID
		{
			get => (int) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public DevModelBehaviors(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "DevModelBehaviors");
		}
	}
}
