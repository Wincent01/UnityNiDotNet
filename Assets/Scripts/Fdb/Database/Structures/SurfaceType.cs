using System.Linq;
using NiEditorApplication.Editor;

namespace Fdb.Database
{
	class SurfaceType
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int SurfaceTypeField
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string FootstepNDAudioMetaEventSetName
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public SurfaceType(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "SurfaceType");
		}
	}
}
