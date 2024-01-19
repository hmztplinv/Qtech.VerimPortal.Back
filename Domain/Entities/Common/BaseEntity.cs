public class BaseEntity<TId> // TId generic bir tip olup Guid, int, string gibi tipler olabilir.
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; } // null olabilir.
    public DateTime? DeletedDate { get; set; } // null olabilir.

    // default constructor, bu constructor'ı yazmazsak, new'lediğimizde Id'yi set edemeyiz.Hiç bir şey verilmezse o tipin default değerini alır.
    public BaseEntity() 
    {
        Id= default;
    }

    // Id verilirse bu constructor çalışır.
    public BaseEntity(TId id) 
    {
        Id = id;
    }
}