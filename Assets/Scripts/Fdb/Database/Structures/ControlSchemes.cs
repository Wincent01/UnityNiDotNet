using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class ControlSchemes
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int control_scheme
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string scheme_name
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float rotation_speed
		{
			get => (float) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float walk_forward_speed
		{
			get => (float) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float walk_backward_speed
		{
			get => (float) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float walk_strafe_speed
		{
			get => (float) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float walk_strafe_forward_speed
		{
			get => (float) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float walk_strafe_backward_speed
		{
			get => (float) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float run_backward_speed
		{
			get => (float) DatabaseRow.Fields[8].Value;
			set
			{
				DatabaseRow.Fields[8].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float run_strafe_speed
		{
			get => (float) DatabaseRow.Fields[9].Value;
			set
			{
				DatabaseRow.Fields[9].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float run_strafe_forward_speed
		{
			get => (float) DatabaseRow.Fields[10].Value;
			set
			{
				DatabaseRow.Fields[10].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float run_strafe_backward_speed
		{
			get => (float) DatabaseRow.Fields[11].Value;
			set
			{
				DatabaseRow.Fields[11].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float keyboard_zoom_sensitivity
		{
			get => (float) DatabaseRow.Fields[12].Value;
			set
			{
				DatabaseRow.Fields[12].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float keyboard_pitch_sensitivity
		{
			get => (float) DatabaseRow.Fields[13].Value;
			set
			{
				DatabaseRow.Fields[13].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float keyboard_yaw_sensitivity
		{
			get => (float) DatabaseRow.Fields[14].Value;
			set
			{
				DatabaseRow.Fields[14].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float mouse_zoom_wheel_sensitivity
		{
			get => (float) DatabaseRow.Fields[15].Value;
			set
			{
				DatabaseRow.Fields[15].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float x_mouse_move_sensitivity_modifier
		{
			get => (float) DatabaseRow.Fields[16].Value;
			set
			{
				DatabaseRow.Fields[16].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float y_mouse_move_sensitivity_modifier
		{
			get => (float) DatabaseRow.Fields[17].Value;
			set
			{
				DatabaseRow.Fields[17].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float freecam_speed_modifier
		{
			get => (float) DatabaseRow.Fields[18].Value;
			set
			{
				DatabaseRow.Fields[18].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float freecam_slow_speed_multiplier
		{
			get => (float) DatabaseRow.Fields[19].Value;
			set
			{
				DatabaseRow.Fields[19].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float freecam_fast_speed_multiplier
		{
			get => (float) DatabaseRow.Fields[20].Value;
			set
			{
				DatabaseRow.Fields[20].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float freecam_mouse_modifier
		{
			get => (float) DatabaseRow.Fields[21].Value;
			set
			{
				DatabaseRow.Fields[21].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float gamepad_pitch_rot_sensitivity
		{
			get => (float) DatabaseRow.Fields[22].Value;
			set
			{
				DatabaseRow.Fields[22].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float gamepad_yaw_rot_sensitivity
		{
			get => (float) DatabaseRow.Fields[23].Value;
			set
			{
				DatabaseRow.Fields[23].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float gamepad_trigger_sensitivity
		{
			get => (float) DatabaseRow.Fields[24].Value;
			set
			{
				DatabaseRow.Fields[24].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public ControlSchemes(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "ControlSchemes");
		}
	}
}
