using System.Linq;
using NiEditorApplication.Editor;

namespace Fdb.Database
{
	class BehaviorEffect
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int effectID
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string effectType
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string effectName
		{
			get => (string) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int trailID
		{
			get => (int) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float pcreateDuration
		{
			get => (float) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string animationName
		{
			get => (string) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool attachToObject
		{
			get => (bool) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string boneName
		{
			get => (string) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool useSecondary
		{
			get => (bool) DatabaseRow.Fields[8].Value;
			set
			{
				DatabaseRow.Fields[8].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int cameraEffectType
		{
			get => (int) DatabaseRow.Fields[9].Value;
			set
			{
				DatabaseRow.Fields[9].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float cameraDuration
		{
			get => (float) DatabaseRow.Fields[10].Value;
			set
			{
				DatabaseRow.Fields[10].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float cameraFrequency
		{
			get => (float) DatabaseRow.Fields[11].Value;
			set
			{
				DatabaseRow.Fields[11].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float cameraXAmp
		{
			get => (float) DatabaseRow.Fields[12].Value;
			set
			{
				DatabaseRow.Fields[12].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float cameraYAmp
		{
			get => (float) DatabaseRow.Fields[13].Value;
			set
			{
				DatabaseRow.Fields[13].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float cameraZAmp
		{
			get => (float) DatabaseRow.Fields[14].Value;
			set
			{
				DatabaseRow.Fields[14].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float cameraRotFrequency
		{
			get => (float) DatabaseRow.Fields[15].Value;
			set
			{
				DatabaseRow.Fields[15].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float cameraRoll
		{
			get => (float) DatabaseRow.Fields[16].Value;
			set
			{
				DatabaseRow.Fields[16].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float cameraPitch
		{
			get => (float) DatabaseRow.Fields[17].Value;
			set
			{
				DatabaseRow.Fields[17].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float cameraYaw
		{
			get => (float) DatabaseRow.Fields[18].Value;
			set
			{
				DatabaseRow.Fields[18].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventGUID
		{
			get => (string) DatabaseRow.Fields[19].Value;
			set
			{
				DatabaseRow.Fields[19].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int renderEffectType
		{
			get => (int) DatabaseRow.Fields[20].Value;
			set
			{
				DatabaseRow.Fields[20].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float renderEffectTime
		{
			get => (float) DatabaseRow.Fields[21].Value;
			set
			{
				DatabaseRow.Fields[21].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float renderStartVal
		{
			get => (float) DatabaseRow.Fields[22].Value;
			set
			{
				DatabaseRow.Fields[22].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float renderEndVal
		{
			get => (float) DatabaseRow.Fields[23].Value;
			set
			{
				DatabaseRow.Fields[23].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float renderDelayVal
		{
			get => (float) DatabaseRow.Fields[24].Value;
			set
			{
				DatabaseRow.Fields[24].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float renderValue1
		{
			get => (float) DatabaseRow.Fields[25].Value;
			set
			{
				DatabaseRow.Fields[25].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float renderValue2
		{
			get => (float) DatabaseRow.Fields[26].Value;
			set
			{
				DatabaseRow.Fields[26].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float renderValue3
		{
			get => (float) DatabaseRow.Fields[27].Value;
			set
			{
				DatabaseRow.Fields[27].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string renderRGBA
		{
			get => (string) DatabaseRow.Fields[28].Value;
			set
			{
				DatabaseRow.Fields[28].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int renderShaderVal
		{
			get => (int) DatabaseRow.Fields[29].Value;
			set
			{
				DatabaseRow.Fields[29].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int motionID
		{
			get => (int) DatabaseRow.Fields[30].Value;
			set
			{
				DatabaseRow.Fields[30].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int meshID
		{
			get => (int) DatabaseRow.Fields[31].Value;
			set
			{
				DatabaseRow.Fields[31].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float meshDuration
		{
			get => (float) DatabaseRow.Fields[32].Value;
			set
			{
				DatabaseRow.Fields[32].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string meshLockedNode
		{
			get => (string) DatabaseRow.Fields[33].Value;
			set
			{
				DatabaseRow.Fields[33].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public BehaviorEffect(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "BehaviorEffect");
		}
	}
}
