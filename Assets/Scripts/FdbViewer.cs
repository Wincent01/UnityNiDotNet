using Fdb;
using Fdb.Database;
using UnityEngine;

public class FdbViewer : MonoBehaviour
{
    public string Path;

    public FdbDatabase Database;

    private void Start()
    {
        Database = new FdbDatabase(new FdbFile(Path));
    }
}