using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class RewardCodes
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

		public string code
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int attachmentLOT
		{
			get => (int) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int locStatus
		{
			get => (int) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string gate_version
		{
			get => (string) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public RewardCodes(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "RewardCodes");
		}
	}
}
