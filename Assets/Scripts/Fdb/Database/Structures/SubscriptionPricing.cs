using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class SubscriptionPricing
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

		public string countryCode
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string monthlyFeeGold
		{
			get => (string) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string monthlyFeeSilver
		{
			get => (string) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string monthlyFeeBronze
		{
			get => (string) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int monetarySymbol
		{
			get => (int) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool symbolIsAppended
		{
			get => (bool) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public SubscriptionPricing(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "SubscriptionPricing");
		}
	}
}
