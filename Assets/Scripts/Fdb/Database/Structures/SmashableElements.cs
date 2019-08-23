using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class SmashableElements
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int elementID
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int dropWeight
		{
			get => (int) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public SmashableElements(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "SmashableElements");
		}
	}
}
