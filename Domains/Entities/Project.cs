
namespace Domains.Entities
{
    public class Project : Base.BaseEntity  
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ClientName { get; set; } = null!;
        public int Year { get; set; }
        public string Location { get; set; } = null!;

        // Relations
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Image> Images { get; set; }
    }

}
