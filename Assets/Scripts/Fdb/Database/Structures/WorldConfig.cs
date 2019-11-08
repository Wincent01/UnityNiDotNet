using System.Linq;
using NiEditorApplication.Editor;

namespace Fdb.Database
{
	class WorldConfig
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int WorldConfigID
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float pegravityvalue
		{
			get => (float) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float pebroadphaseworldsize
		{
			get => (float) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float pegameobjscalefactor
		{
			get => (float) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float character_rotation_speed
		{
			get => (float) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float character_walk_forward_speed
		{
			get => (float) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float character_walk_backward_speed
		{
			get => (float) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float character_walk_strafe_speed
		{
			get => (float) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float character_walk_strafe_forward_speed
		{
			get => (float) DatabaseRow.Fields[8].Value;
			set
			{
				DatabaseRow.Fields[8].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float character_walk_strafe_backward_speed
		{
			get => (float) DatabaseRow.Fields[9].Value;
			set
			{
				DatabaseRow.Fields[9].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float character_run_backward_speed
		{
			get => (float) DatabaseRow.Fields[10].Value;
			set
			{
				DatabaseRow.Fields[10].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float character_run_strafe_speed
		{
			get => (float) DatabaseRow.Fields[11].Value;
			set
			{
				DatabaseRow.Fields[11].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float character_run_strafe_forward_speed
		{
			get => (float) DatabaseRow.Fields[12].Value;
			set
			{
				DatabaseRow.Fields[12].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float character_run_strafe_backward_speed
		{
			get => (float) DatabaseRow.Fields[13].Value;
			set
			{
				DatabaseRow.Fields[13].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float global_cooldown
		{
			get => (float) DatabaseRow.Fields[14].Value;
			set
			{
				DatabaseRow.Fields[14].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float characterGroundedTime
		{
			get => (float) DatabaseRow.Fields[15].Value;
			set
			{
				DatabaseRow.Fields[15].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float characterGroundedSpeed
		{
			get => (float) DatabaseRow.Fields[16].Value;
			set
			{
				DatabaseRow.Fields[16].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float globalImmunityTime
		{
			get => (float) DatabaseRow.Fields[17].Value;
			set
			{
				DatabaseRow.Fields[17].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float character_max_slope
		{
			get => (float) DatabaseRow.Fields[18].Value;
			set
			{
				DatabaseRow.Fields[18].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float defaultrespawntime
		{
			get => (float) DatabaseRow.Fields[19].Value;
			set
			{
				DatabaseRow.Fields[19].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float mission_tooltip_timeout
		{
			get => (float) DatabaseRow.Fields[20].Value;
			set
			{
				DatabaseRow.Fields[20].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float vendor_buy_multiplier
		{
			get => (float) DatabaseRow.Fields[21].Value;
			set
			{
				DatabaseRow.Fields[21].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float pet_follow_radius
		{
			get => (float) DatabaseRow.Fields[22].Value;
			set
			{
				DatabaseRow.Fields[22].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float character_eye_height
		{
			get => (float) DatabaseRow.Fields[23].Value;
			set
			{
				DatabaseRow.Fields[23].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float flight_vertical_velocity
		{
			get => (float) DatabaseRow.Fields[24].Value;
			set
			{
				DatabaseRow.Fields[24].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float flight_airspeed
		{
			get => (float) DatabaseRow.Fields[25].Value;
			set
			{
				DatabaseRow.Fields[25].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float flight_fuel_ratio
		{
			get => (float) DatabaseRow.Fields[26].Value;
			set
			{
				DatabaseRow.Fields[26].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float flight_max_airspeed
		{
			get => (float) DatabaseRow.Fields[27].Value;
			set
			{
				DatabaseRow.Fields[27].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fReputationPerVote
		{
			get => (float) DatabaseRow.Fields[28].Value;
			set
			{
				DatabaseRow.Fields[28].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int nPropertyCloneLimit
		{
			get => (int) DatabaseRow.Fields[29].Value;
			set
			{
				DatabaseRow.Fields[29].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int defaultHomespaceTemplate
		{
			get => (int) DatabaseRow.Fields[30].Value;
			set
			{
				DatabaseRow.Fields[30].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float coins_lost_on_death_percent
		{
			get => (float) DatabaseRow.Fields[31].Value;
			set
			{
				DatabaseRow.Fields[31].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int coins_lost_on_death_min
		{
			get => (int) DatabaseRow.Fields[32].Value;
			set
			{
				DatabaseRow.Fields[32].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int coins_lost_on_death_max
		{
			get => (int) DatabaseRow.Fields[33].Value;
			set
			{
				DatabaseRow.Fields[33].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int character_votes_per_day
		{
			get => (int) DatabaseRow.Fields[34].Value;
			set
			{
				DatabaseRow.Fields[34].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int property_moderation_request_approval_cost
		{
			get => (int) DatabaseRow.Fields[35].Value;
			set
			{
				DatabaseRow.Fields[35].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int property_moderation_request_review_cost
		{
			get => (int) DatabaseRow.Fields[36].Value;
			set
			{
				DatabaseRow.Fields[36].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int propertyModRequestsAllowedSpike
		{
			get => (int) DatabaseRow.Fields[37].Value;
			set
			{
				DatabaseRow.Fields[37].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int propertyModRequestsAllowedInterval
		{
			get => (int) DatabaseRow.Fields[38].Value;
			set
			{
				DatabaseRow.Fields[38].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int propertyModRequestsAllowedTotal
		{
			get => (int) DatabaseRow.Fields[39].Value;
			set
			{
				DatabaseRow.Fields[39].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int propertyModRequestsSpikeDuration
		{
			get => (int) DatabaseRow.Fields[40].Value;
			set
			{
				DatabaseRow.Fields[40].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int propertyModRequestsIntervalDuration
		{
			get => (int) DatabaseRow.Fields[41].Value;
			set
			{
				DatabaseRow.Fields[41].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool modelModerateOnCreate
		{
			get => (bool) DatabaseRow.Fields[42].Value;
			set
			{
				DatabaseRow.Fields[42].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float defaultPropertyMaxHeight
		{
			get => (float) DatabaseRow.Fields[43].Value;
			set
			{
				DatabaseRow.Fields[43].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float reputationPerVoteCast
		{
			get => (float) DatabaseRow.Fields[44].Value;
			set
			{
				DatabaseRow.Fields[44].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float reputationPerVoteReceived
		{
			get => (float) DatabaseRow.Fields[45].Value;
			set
			{
				DatabaseRow.Fields[45].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int showcaseTopModelConsiderationBattles
		{
			get => (int) DatabaseRow.Fields[46].Value;
			set
			{
				DatabaseRow.Fields[46].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float reputationPerBattlePromotion
		{
			get => (float) DatabaseRow.Fields[47].Value;
			set
			{
				DatabaseRow.Fields[47].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float coins_lost_on_death_min_timeout
		{
			get => (float) DatabaseRow.Fields[48].Value;
			set
			{
				DatabaseRow.Fields[48].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float coins_lost_on_death_max_timeout
		{
			get => (float) DatabaseRow.Fields[49].Value;
			set
			{
				DatabaseRow.Fields[49].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int mail_base_fee
		{
			get => (int) DatabaseRow.Fields[50].Value;
			set
			{
				DatabaseRow.Fields[50].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float mail_percent_attachment_fee
		{
			get => (float) DatabaseRow.Fields[51].Value;
			set
			{
				DatabaseRow.Fields[51].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int propertyReputationDelay
		{
			get => (int) DatabaseRow.Fields[52].Value;
			set
			{
				DatabaseRow.Fields[52].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int LevelCap
		{
			get => (int) DatabaseRow.Fields[53].Value;
			set
			{
				DatabaseRow.Fields[53].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string LevelUpBehaviorEffect
		{
			get => (string) DatabaseRow.Fields[54].Value;
			set
			{
				DatabaseRow.Fields[54].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int CharacterVersion
		{
			get => (int) DatabaseRow.Fields[55].Value;
			set
			{
				DatabaseRow.Fields[55].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int LevelCapCurrencyConversion
		{
			get => (int) DatabaseRow.Fields[56].Value;
			set
			{
				DatabaseRow.Fields[56].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public WorldConfig(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "WorldConfig");
		}
	}
}
