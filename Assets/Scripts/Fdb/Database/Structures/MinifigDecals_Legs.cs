using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class MinifigDecals_Legs
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int ID
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string High_path
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public MinifigDecals_Legs(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "MinifigDecals_Legs");
		}
	}
}
