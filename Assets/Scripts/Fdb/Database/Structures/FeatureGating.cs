using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class FeatureGating
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public string featureName
		{
			get => (string) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int major
		{
			get => (int) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int current
		{
			get => (int) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int minor
		{
			get => (int) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string description
		{
			get => (string) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public FeatureGating(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "FeatureGating");
		}
	}
}
