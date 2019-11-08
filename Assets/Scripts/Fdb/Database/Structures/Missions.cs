using System.Linq;
using NiEditorApplication.Editor;

namespace Fdb.Database
{
	class Missions
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

		public string defined_type
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string defined_subtype
		{
			get => (string) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int UISortOrder
		{
			get => (int) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int offer_objectID
		{
			get => (int) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int target_objectID
		{
			get => (int) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public long reward_currency
		{
			get => (long) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int LegoScore
		{
			get => (int) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public long reward_reputation
		{
			get => (long) DatabaseRow.Fields[8].Value;
			set
			{
				DatabaseRow.Fields[8].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool isChoiceReward
		{
			get => (bool) DatabaseRow.Fields[9].Value;
			set
			{
				DatabaseRow.Fields[9].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item1
		{
			get => (int) DatabaseRow.Fields[10].Value;
			set
			{
				DatabaseRow.Fields[10].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item1_count
		{
			get => (int) DatabaseRow.Fields[11].Value;
			set
			{
				DatabaseRow.Fields[11].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item2
		{
			get => (int) DatabaseRow.Fields[12].Value;
			set
			{
				DatabaseRow.Fields[12].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item2_count
		{
			get => (int) DatabaseRow.Fields[13].Value;
			set
			{
				DatabaseRow.Fields[13].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item3
		{
			get => (int) DatabaseRow.Fields[14].Value;
			set
			{
				DatabaseRow.Fields[14].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item3_count
		{
			get => (int) DatabaseRow.Fields[15].Value;
			set
			{
				DatabaseRow.Fields[15].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item4
		{
			get => (int) DatabaseRow.Fields[16].Value;
			set
			{
				DatabaseRow.Fields[16].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item4_count
		{
			get => (int) DatabaseRow.Fields[17].Value;
			set
			{
				DatabaseRow.Fields[17].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_emote
		{
			get => (int) DatabaseRow.Fields[18].Value;
			set
			{
				DatabaseRow.Fields[18].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_emote2
		{
			get => (int) DatabaseRow.Fields[19].Value;
			set
			{
				DatabaseRow.Fields[19].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_emote3
		{
			get => (int) DatabaseRow.Fields[20].Value;
			set
			{
				DatabaseRow.Fields[20].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_emote4
		{
			get => (int) DatabaseRow.Fields[21].Value;
			set
			{
				DatabaseRow.Fields[21].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_maximagination
		{
			get => (int) DatabaseRow.Fields[22].Value;
			set
			{
				DatabaseRow.Fields[22].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_maxhealth
		{
			get => (int) DatabaseRow.Fields[23].Value;
			set
			{
				DatabaseRow.Fields[23].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_maxinventory
		{
			get => (int) DatabaseRow.Fields[24].Value;
			set
			{
				DatabaseRow.Fields[24].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_maxmodel
		{
			get => (int) DatabaseRow.Fields[25].Value;
			set
			{
				DatabaseRow.Fields[25].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_maxwidget
		{
			get => (int) DatabaseRow.Fields[26].Value;
			set
			{
				DatabaseRow.Fields[26].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public long reward_maxwallet
		{
			get => (long) DatabaseRow.Fields[27].Value;
			set
			{
				DatabaseRow.Fields[27].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool repeatable
		{
			get => (bool) DatabaseRow.Fields[28].Value;
			set
			{
				DatabaseRow.Fields[28].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public long reward_currency_repeatable
		{
			get => (long) DatabaseRow.Fields[29].Value;
			set
			{
				DatabaseRow.Fields[29].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item1_repeatable
		{
			get => (int) DatabaseRow.Fields[30].Value;
			set
			{
				DatabaseRow.Fields[30].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item1_repeat_count
		{
			get => (int) DatabaseRow.Fields[31].Value;
			set
			{
				DatabaseRow.Fields[31].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item2_repeatable
		{
			get => (int) DatabaseRow.Fields[32].Value;
			set
			{
				DatabaseRow.Fields[32].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item2_repeat_count
		{
			get => (int) DatabaseRow.Fields[33].Value;
			set
			{
				DatabaseRow.Fields[33].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item3_repeatable
		{
			get => (int) DatabaseRow.Fields[34].Value;
			set
			{
				DatabaseRow.Fields[34].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item3_repeat_count
		{
			get => (int) DatabaseRow.Fields[35].Value;
			set
			{
				DatabaseRow.Fields[35].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item4_repeatable
		{
			get => (int) DatabaseRow.Fields[36].Value;
			set
			{
				DatabaseRow.Fields[36].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_item4_repeat_count
		{
			get => (int) DatabaseRow.Fields[37].Value;
			set
			{
				DatabaseRow.Fields[37].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int time_limit
		{
			get => (int) DatabaseRow.Fields[38].Value;
			set
			{
				DatabaseRow.Fields[38].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool isMission
		{
			get => (bool) DatabaseRow.Fields[39].Value;
			set
			{
				DatabaseRow.Fields[39].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int missionIconID
		{
			get => (int) DatabaseRow.Fields[40].Value;
			set
			{
				DatabaseRow.Fields[40].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string prereqMissionID
		{
			get => (string) DatabaseRow.Fields[41].Value;
			set
			{
				DatabaseRow.Fields[41].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool localize
		{
			get => (bool) DatabaseRow.Fields[42].Value;
			set
			{
				DatabaseRow.Fields[42].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool inMOTD
		{
			get => (bool) DatabaseRow.Fields[43].Value;
			set
			{
				DatabaseRow.Fields[43].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public long cooldownTime
		{
			get => (long) DatabaseRow.Fields[44].Value;
			set
			{
				DatabaseRow.Fields[44].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool isRandom
		{
			get => (bool) DatabaseRow.Fields[45].Value;
			set
			{
				DatabaseRow.Fields[45].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string randomPool
		{
			get => (string) DatabaseRow.Fields[46].Value;
			set
			{
				DatabaseRow.Fields[46].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int UIPrereqID
		{
			get => (int) DatabaseRow.Fields[47].Value;
			set
			{
				DatabaseRow.Fields[47].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string gate_version
		{
			get => (string) DatabaseRow.Fields[48].Value;
			set
			{
				DatabaseRow.Fields[48].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string HUDStates
		{
			get => (string) DatabaseRow.Fields[49].Value;
			set
			{
				DatabaseRow.Fields[49].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int locStatus
		{
			get => (int) DatabaseRow.Fields[50].Value;
			set
			{
				DatabaseRow.Fields[50].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int reward_bankinventory
		{
			get => (int) DatabaseRow.Fields[51].Value;
			set
			{
				DatabaseRow.Fields[51].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public Missions(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "Missions");
		}
	}
}
