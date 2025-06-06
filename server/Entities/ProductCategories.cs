namespace server.Entities
{
    public class ProductCategories: AuditBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
