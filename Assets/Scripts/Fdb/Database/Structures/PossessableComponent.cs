using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class PossessableComponent
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

		public int controlSchemeID
		{
			get => (int) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string minifigAttachPoint
		{
			get => (string) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string minifigAttachAnimation
		{
			get => (string) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string minifigDetachAnimation
		{
			get => (string) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string mountAttachAnimation
		{
			get => (string) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string mountDetachAnimation
		{
			get => (string) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float attachOffsetFwd
		{
			get => (float) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float attachOffsetRight
		{
			get => (float) DatabaseRow.Fields[8].Value;
			set
			{
				DatabaseRow.Fields[8].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int possessionType
		{
			get => (int) DatabaseRow.Fields[9].Value;
			set
			{
				DatabaseRow.Fields[9].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool wantBillboard
		{
			get => (bool) DatabaseRow.Fields[10].Value;
			set
			{
				DatabaseRow.Fields[10].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float billboardOffsetUp
		{
			get => (float) DatabaseRow.Fields[11].Value;
			set
			{
				DatabaseRow.Fields[11].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool depossessOnHit
		{
			get => (bool) DatabaseRow.Fields[12].Value;
			set
			{
				DatabaseRow.Fields[12].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float hitStunTime
		{
			get => (float) DatabaseRow.Fields[13].Value;
			set
			{
				DatabaseRow.Fields[13].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int skillSet
		{
			get => (int) DatabaseRow.Fields[14].Value;
			set
			{
				DatabaseRow.Fields[14].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public PossessableComponent(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "PossessableComponent");
		}
	}
}
