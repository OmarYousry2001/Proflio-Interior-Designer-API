
namespace Domains.Entities
{
    public class Category : Base.BaseEntity 
    {
        public string Name { get; set; } = null!;   

        // Relations
        public ICollection<Project> Projects { get; set; }
    }
}
