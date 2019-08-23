using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class PropertyTemplate
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

		public int mapID
		{
			get => (int) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int vendorMapID
		{
			get => (int) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string spawnName
		{
			get => (string) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int type
		{
			get => (int) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int sizecode
		{
			get => (int) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int minimumPrice
		{
			get => (int) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int rentDuration
		{
			get => (int) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string path
		{
			get => (string) DatabaseRow.Fields[8].Value;
			set
			{
				DatabaseRow.Fields[8].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int cloneLimit
		{
			get => (int) DatabaseRow.Fields[9].Value;
			set
			{
				DatabaseRow.Fields[9].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int durationType
		{
			get => (int) DatabaseRow.Fields[10].Value;
			set
			{
				DatabaseRow.Fields[10].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int achievementRequired
		{
			get => (int) DatabaseRow.Fields[11].Value;
			set
			{
				DatabaseRow.Fields[11].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float zoneX
		{
			get => (float) DatabaseRow.Fields[12].Value;
			set
			{
				DatabaseRow.Fields[12].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float zoneY
		{
			get => (float) DatabaseRow.Fields[13].Value;
			set
			{
				DatabaseRow.Fields[13].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float zoneZ
		{
			get => (float) DatabaseRow.Fields[14].Value;
			set
			{
				DatabaseRow.Fields[14].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float maxBuildHeight
		{
			get => (float) DatabaseRow.Fields[15].Value;
			set
			{
				DatabaseRow.Fields[15].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool localize
		{
			get => (bool) DatabaseRow.Fields[16].Value;
			set
			{
				DatabaseRow.Fields[16].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reputationPerMinute
		{
			get => (int) DatabaseRow.Fields[17].Value;
			set
			{
				DatabaseRow.Fields[17].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int locStatus
		{
			get => (int) DatabaseRow.Fields[18].Value;
			set
			{
				DatabaseRow.Fields[18].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string gate_version
		{
			get => (string) DatabaseRow.Fields[19].Value;
			set
			{
				DatabaseRow.Fields[19].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public PropertyTemplate(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "PropertyTemplate");
		}
	}
}
