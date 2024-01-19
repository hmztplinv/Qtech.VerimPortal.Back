public class Brand:BaseEntity<Guid>
{
    public string Name { get; set; }

    public Brand()
    {
    }

    public Brand(Guid id, string name)
    {
        Id = id; // BaseEntity'den geliyor.
        Name = name;
    }
}