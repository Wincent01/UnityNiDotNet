using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class NpcIcons
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

		public int color
		{
			get => (int) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float offset
		{
			get => (float) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int LOT
		{
			get => (int) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string Texture
		{
			get => (string) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool isClickable
		{
			get => (bool) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float scale
		{
			get => (float) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool rotateToFace
		{
			get => (bool) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float compositeHorizOffset
		{
			get => (float) DatabaseRow.Fields[8].Value;
			set
			{
				DatabaseRow.Fields[8].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float compositeVertOffset
		{
			get => (float) DatabaseRow.Fields[9].Value;
			set
			{
				DatabaseRow.Fields[9].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float compositeScale
		{
			get => (float) DatabaseRow.Fields[10].Value;
			set
			{
				DatabaseRow.Fields[10].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string compositeConnectionNode
		{
			get => (string) DatabaseRow.Fields[11].Value;
			set
			{
				DatabaseRow.Fields[11].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int compositeLOTMultiMission
		{
			get => (int) DatabaseRow.Fields[12].Value;
			set
			{
				DatabaseRow.Fields[12].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int compositeLOTMultiMissionVentor
		{
			get => (int) DatabaseRow.Fields[13].Value;
			set
			{
				DatabaseRow.Fields[13].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string compositeIconTexture
		{
			get => (string) DatabaseRow.Fields[14].Value;
			set
			{
				DatabaseRow.Fields[14].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public NpcIcons(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "NpcIcons");
		}
	}
}
