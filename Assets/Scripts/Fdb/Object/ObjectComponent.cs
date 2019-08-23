using Fdb.Database;

namespace Fdb.Object
{
    public class ObjectComponent
    {
        public Row RegistryRow { get; set; }
        
        public ReplicaComponentsId ComponentType { get; set; }
        
        public Row ComponentRow { get; set; }
    }
}