using System.Linq;
using NiEditorApplication.Editor;

namespace Fdb.Database
{
	class SceneTable
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int sceneID
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string sceneName
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public SceneTable(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "SceneTable");
		}
	}
}
