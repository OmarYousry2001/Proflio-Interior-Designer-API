

namespace Domains.Entities
{
    public class Comment : Base.BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!; 
        public string Message { get; set; } = null!;
    }
}
