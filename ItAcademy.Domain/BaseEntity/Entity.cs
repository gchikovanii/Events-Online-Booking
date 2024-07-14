namespace ItAcademy.Domain.BaseEntity
{
    public class Entity
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
