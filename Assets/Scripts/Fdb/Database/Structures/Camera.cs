using System.Linq;
using NiEditorApplication.Editor;

namespace Fdb.Database
{
	class Camera
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public string camera_name
		{
			get => (string) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float pitch_angle_tolerance
		{
			get => (float) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float starting_zoom
		{
			get => (float) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float zoom_return_modifier
		{
			get => (float) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float pitch_return_modifier
		{
			get => (float) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float tether_out_return_modifier
		{
			get => (float) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float tether_in_return_multiplier
		{
			get => (float) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float verticle_movement_dampening_modifier
		{
			get => (float) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float return_from_incline_modifier
		{
			get => (float) DatabaseRow.Fields[8].Value;
			set
			{
				DatabaseRow.Fields[8].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float horizontal_return_modifier
		{
			get => (float) DatabaseRow.Fields[9].Value;
			set
			{
				DatabaseRow.Fields[9].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float yaw_behavior_speed_multiplier
		{
			get => (float) DatabaseRow.Fields[10].Value;
			set
			{
				DatabaseRow.Fields[10].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float camera_collision_padding
		{
			get => (float) DatabaseRow.Fields[11].Value;
			set
			{
				DatabaseRow.Fields[11].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float glide_speed
		{
			get => (float) DatabaseRow.Fields[12].Value;
			set
			{
				DatabaseRow.Fields[12].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fade_player_min_range
		{
			get => (float) DatabaseRow.Fields[13].Value;
			set
			{
				DatabaseRow.Fields[13].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float min_movement_delta_tolerance
		{
			get => (float) DatabaseRow.Fields[14].Value;
			set
			{
				DatabaseRow.Fields[14].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float min_glide_distance_tolerance
		{
			get => (float) DatabaseRow.Fields[15].Value;
			set
			{
				DatabaseRow.Fields[15].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float look_forward_offset
		{
			get => (float) DatabaseRow.Fields[16].Value;
			set
			{
				DatabaseRow.Fields[16].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float look_up_offset
		{
			get => (float) DatabaseRow.Fields[17].Value;
			set
			{
				DatabaseRow.Fields[17].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float minimum_vertical_dampening_distance
		{
			get => (float) DatabaseRow.Fields[18].Value;
			set
			{
				DatabaseRow.Fields[18].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float maximum_vertical_dampening_distance
		{
			get => (float) DatabaseRow.Fields[19].Value;
			set
			{
				DatabaseRow.Fields[19].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float minimum_ignore_jump_distance
		{
			get => (float) DatabaseRow.Fields[20].Value;
			set
			{
				DatabaseRow.Fields[20].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float maximum_ignore_jump_distance
		{
			get => (float) DatabaseRow.Fields[21].Value;
			set
			{
				DatabaseRow.Fields[21].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float maximum_auto_glide_angle
		{
			get => (float) DatabaseRow.Fields[22].Value;
			set
			{
				DatabaseRow.Fields[22].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float minimum_tether_glide_distance
		{
			get => (float) DatabaseRow.Fields[23].Value;
			set
			{
				DatabaseRow.Fields[23].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float yaw_sign_correction
		{
			get => (float) DatabaseRow.Fields[24].Value;
			set
			{
				DatabaseRow.Fields[24].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_1_look_forward_offset
		{
			get => (float) DatabaseRow.Fields[25].Value;
			set
			{
				DatabaseRow.Fields[25].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_1_look_up_offset
		{
			get => (float) DatabaseRow.Fields[26].Value;
			set
			{
				DatabaseRow.Fields[26].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_2_look_forward_offset
		{
			get => (float) DatabaseRow.Fields[27].Value;
			set
			{
				DatabaseRow.Fields[27].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_2_look_up_offset
		{
			get => (float) DatabaseRow.Fields[28].Value;
			set
			{
				DatabaseRow.Fields[28].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_0_speed_influence_on_dir
		{
			get => (float) DatabaseRow.Fields[29].Value;
			set
			{
				DatabaseRow.Fields[29].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_1_speed_influence_on_dir
		{
			get => (float) DatabaseRow.Fields[30].Value;
			set
			{
				DatabaseRow.Fields[30].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_2_speed_influence_on_dir
		{
			get => (float) DatabaseRow.Fields[31].Value;
			set
			{
				DatabaseRow.Fields[31].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_0_angular_relaxation
		{
			get => (float) DatabaseRow.Fields[32].Value;
			set
			{
				DatabaseRow.Fields[32].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_1_angular_relaxation
		{
			get => (float) DatabaseRow.Fields[33].Value;
			set
			{
				DatabaseRow.Fields[33].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_2_angular_relaxation
		{
			get => (float) DatabaseRow.Fields[34].Value;
			set
			{
				DatabaseRow.Fields[34].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_0_position_up_offset
		{
			get => (float) DatabaseRow.Fields[35].Value;
			set
			{
				DatabaseRow.Fields[35].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_1_position_up_offset
		{
			get => (float) DatabaseRow.Fields[36].Value;
			set
			{
				DatabaseRow.Fields[36].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_2_position_up_offset
		{
			get => (float) DatabaseRow.Fields[37].Value;
			set
			{
				DatabaseRow.Fields[37].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_0_position_forward_offset
		{
			get => (float) DatabaseRow.Fields[38].Value;
			set
			{
				DatabaseRow.Fields[38].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_1_position_forward_offset
		{
			get => (float) DatabaseRow.Fields[39].Value;
			set
			{
				DatabaseRow.Fields[39].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_2_position_forward_offset
		{
			get => (float) DatabaseRow.Fields[40].Value;
			set
			{
				DatabaseRow.Fields[40].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_0_FOV
		{
			get => (float) DatabaseRow.Fields[41].Value;
			set
			{
				DatabaseRow.Fields[41].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_1_FOV
		{
			get => (float) DatabaseRow.Fields[42].Value;
			set
			{
				DatabaseRow.Fields[42].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_2_FOV
		{
			get => (float) DatabaseRow.Fields[43].Value;
			set
			{
				DatabaseRow.Fields[43].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_0_max_yaw_angle
		{
			get => (float) DatabaseRow.Fields[44].Value;
			set
			{
				DatabaseRow.Fields[44].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_1_max_yaw_angle
		{
			get => (float) DatabaseRow.Fields[45].Value;
			set
			{
				DatabaseRow.Fields[45].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float set_2_max_yaw_angle
		{
			get => (float) DatabaseRow.Fields[46].Value;
			set
			{
				DatabaseRow.Fields[46].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int set_1_fade_in_camera_set_change
		{
			get => (int) DatabaseRow.Fields[47].Value;
			set
			{
				DatabaseRow.Fields[47].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int set_1_fade_out_camera_set_change
		{
			get => (int) DatabaseRow.Fields[48].Value;
			set
			{
				DatabaseRow.Fields[48].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int set_2_fade_in_camera_set_change
		{
			get => (int) DatabaseRow.Fields[49].Value;
			set
			{
				DatabaseRow.Fields[49].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int set_2_fade_out_camera_set_change
		{
			get => (int) DatabaseRow.Fields[50].Value;
			set
			{
				DatabaseRow.Fields[50].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float input_movement_scalar
		{
			get => (float) DatabaseRow.Fields[51].Value;
			set
			{
				DatabaseRow.Fields[51].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float input_rotation_scalar
		{
			get => (float) DatabaseRow.Fields[52].Value;
			set
			{
				DatabaseRow.Fields[52].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float input_zoom_scalar
		{
			get => (float) DatabaseRow.Fields[53].Value;
			set
			{
				DatabaseRow.Fields[53].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float minimum_pitch_desired
		{
			get => (float) DatabaseRow.Fields[54].Value;
			set
			{
				DatabaseRow.Fields[54].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float maximum_pitch_desired
		{
			get => (float) DatabaseRow.Fields[55].Value;
			set
			{
				DatabaseRow.Fields[55].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float minimum_zoom
		{
			get => (float) DatabaseRow.Fields[56].Value;
			set
			{
				DatabaseRow.Fields[56].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float maximum_zoom
		{
			get => (float) DatabaseRow.Fields[57].Value;
			set
			{
				DatabaseRow.Fields[57].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float horizontal_rotate_tolerance
		{
			get => (float) DatabaseRow.Fields[58].Value;
			set
			{
				DatabaseRow.Fields[58].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float horizontal_rotate_modifier
		{
			get => (float) DatabaseRow.Fields[59].Value;
			set
			{
				DatabaseRow.Fields[59].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public Camera(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "Camera");
		}
	}
}
