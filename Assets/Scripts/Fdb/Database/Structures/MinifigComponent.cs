using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class MinifigComponent
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int id
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int head
		{
			get => (int) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int chest
		{
			get => (int) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int legs
		{
			get => (int) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int hairstyle
		{
			get => (int) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int haircolor
		{
			get => (int) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int chestdecal
		{
			get => (int) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int headcolor
		{
			get => (int) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int lefthand
		{
			get => (int) DatabaseRow.Fields[8].Value;
			set
			{
				DatabaseRow.Fields[8].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int righthand
		{
			get => (int) DatabaseRow.Fields[9].Value;
			set
			{
				DatabaseRow.Fields[9].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int eyebrowstyle
		{
			get => (int) DatabaseRow.Fields[10].Value;
			set
			{
				DatabaseRow.Fields[10].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int eyesstyle
		{
			get => (int) DatabaseRow.Fields[11].Value;
			set
			{
				DatabaseRow.Fields[11].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int mouthstyle
		{
			get => (int) DatabaseRow.Fields[12].Value;
			set
			{
				DatabaseRow.Fields[12].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public MinifigComponent(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "MinifigComponent");
		}
	}
}
