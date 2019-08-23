using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class TrailEffects
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int trailID
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string textureName
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int blendmode
		{
			get => (int) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float cardlifetime
		{
			get => (float) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float colorlifetime
		{
			get => (float) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float minTailFade
		{
			get => (float) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float tailFade
		{
			get => (float) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int max_particles
		{
			get => (int) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float birthDelay
		{
			get => (float) DatabaseRow.Fields[8].Value;
			set
			{
				DatabaseRow.Fields[8].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float deathDelay
		{
			get => (float) DatabaseRow.Fields[9].Value;
			set
			{
				DatabaseRow.Fields[9].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string bone1
		{
			get => (string) DatabaseRow.Fields[10].Value;
			set
			{
				DatabaseRow.Fields[10].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string bone2
		{
			get => (string) DatabaseRow.Fields[11].Value;
			set
			{
				DatabaseRow.Fields[11].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float texLength
		{
			get => (float) DatabaseRow.Fields[12].Value;
			set
			{
				DatabaseRow.Fields[12].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float texWidth
		{
			get => (float) DatabaseRow.Fields[13].Value;
			set
			{
				DatabaseRow.Fields[13].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float startColorR
		{
			get => (float) DatabaseRow.Fields[14].Value;
			set
			{
				DatabaseRow.Fields[14].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float startColorG
		{
			get => (float) DatabaseRow.Fields[15].Value;
			set
			{
				DatabaseRow.Fields[15].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float startColorB
		{
			get => (float) DatabaseRow.Fields[16].Value;
			set
			{
				DatabaseRow.Fields[16].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float startColorA
		{
			get => (float) DatabaseRow.Fields[17].Value;
			set
			{
				DatabaseRow.Fields[17].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float middleColorR
		{
			get => (float) DatabaseRow.Fields[18].Value;
			set
			{
				DatabaseRow.Fields[18].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float middleColorG
		{
			get => (float) DatabaseRow.Fields[19].Value;
			set
			{
				DatabaseRow.Fields[19].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float middleColorB
		{
			get => (float) DatabaseRow.Fields[20].Value;
			set
			{
				DatabaseRow.Fields[20].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float middleColorA
		{
			get => (float) DatabaseRow.Fields[21].Value;
			set
			{
				DatabaseRow.Fields[21].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float endColorR
		{
			get => (float) DatabaseRow.Fields[22].Value;
			set
			{
				DatabaseRow.Fields[22].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float endColorG
		{
			get => (float) DatabaseRow.Fields[23].Value;
			set
			{
				DatabaseRow.Fields[23].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float endColorB
		{
			get => (float) DatabaseRow.Fields[24].Value;
			set
			{
				DatabaseRow.Fields[24].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float endColorA
		{
			get => (float) DatabaseRow.Fields[25].Value;
			set
			{
				DatabaseRow.Fields[25].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public TrailEffects(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "TrailEffects");
		}
	}
}
