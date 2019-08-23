using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class CelebrationParameters
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

		public string animation
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int backgroundObject
		{
			get => (int) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float duration
		{
			get => (float) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string subText
		{
			get => (string) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string mainText
		{
			get => (string) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int iconID
		{
			get => (int) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float celeLeadIn
		{
			get => (float) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float celeLeadOut
		{
			get => (float) DatabaseRow.Fields[8].Value;
			set
			{
				DatabaseRow.Fields[8].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int cameraPathLOT
		{
			get => (int) DatabaseRow.Fields[9].Value;
			set
			{
				DatabaseRow.Fields[9].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string pathNodeName
		{
			get => (string) DatabaseRow.Fields[10].Value;
			set
			{
				DatabaseRow.Fields[10].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float ambientR
		{
			get => (float) DatabaseRow.Fields[11].Value;
			set
			{
				DatabaseRow.Fields[11].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float ambientG
		{
			get => (float) DatabaseRow.Fields[12].Value;
			set
			{
				DatabaseRow.Fields[12].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float ambientB
		{
			get => (float) DatabaseRow.Fields[13].Value;
			set
			{
				DatabaseRow.Fields[13].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float directionalR
		{
			get => (float) DatabaseRow.Fields[14].Value;
			set
			{
				DatabaseRow.Fields[14].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float directionalG
		{
			get => (float) DatabaseRow.Fields[15].Value;
			set
			{
				DatabaseRow.Fields[15].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float directionalB
		{
			get => (float) DatabaseRow.Fields[16].Value;
			set
			{
				DatabaseRow.Fields[16].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float specularR
		{
			get => (float) DatabaseRow.Fields[17].Value;
			set
			{
				DatabaseRow.Fields[17].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float specularG
		{
			get => (float) DatabaseRow.Fields[18].Value;
			set
			{
				DatabaseRow.Fields[18].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float specularB
		{
			get => (float) DatabaseRow.Fields[19].Value;
			set
			{
				DatabaseRow.Fields[19].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float lightPositionX
		{
			get => (float) DatabaseRow.Fields[20].Value;
			set
			{
				DatabaseRow.Fields[20].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float lightPositionY
		{
			get => (float) DatabaseRow.Fields[21].Value;
			set
			{
				DatabaseRow.Fields[21].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float lightPositionZ
		{
			get => (float) DatabaseRow.Fields[22].Value;
			set
			{
				DatabaseRow.Fields[22].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float blendTime
		{
			get => (float) DatabaseRow.Fields[23].Value;
			set
			{
				DatabaseRow.Fields[23].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fogColorR
		{
			get => (float) DatabaseRow.Fields[24].Value;
			set
			{
				DatabaseRow.Fields[24].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fogColorG
		{
			get => (float) DatabaseRow.Fields[25].Value;
			set
			{
				DatabaseRow.Fields[25].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fogColorB
		{
			get => (float) DatabaseRow.Fields[26].Value;
			set
			{
				DatabaseRow.Fields[26].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string musicCue
		{
			get => (string) DatabaseRow.Fields[27].Value;
			set
			{
				DatabaseRow.Fields[27].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string soundGUID
		{
			get => (string) DatabaseRow.Fields[28].Value;
			set
			{
				DatabaseRow.Fields[28].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string mixerProgram
		{
			get => (string) DatabaseRow.Fields[29].Value;
			set
			{
				DatabaseRow.Fields[29].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public CelebrationParameters(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "CelebrationParameters");
		}
	}
}
