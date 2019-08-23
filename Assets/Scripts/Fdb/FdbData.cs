namespace Fdb
{
    public class FdbData
    {
        public bool Empty { get; set; } = false;
        
        public virtual void Write(FdbFile writer){}
    }
}