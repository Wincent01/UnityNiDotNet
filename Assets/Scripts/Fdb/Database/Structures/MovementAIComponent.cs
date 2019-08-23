using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class MovementAIComponent
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

		public string MovementType
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float WanderChance
		{
			get => (float) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float WanderDelayMin
		{
			get => (float) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float WanderDelayMax
		{
			get => (float) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float WanderSpeed
		{
			get => (float) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float WanderRadius
		{
			get => (float) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string attachedPath
		{
			get => (string) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public MovementAIComponent(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "MovementAIComponent");
		}
	}
}
