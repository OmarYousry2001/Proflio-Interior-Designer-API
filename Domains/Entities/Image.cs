
namespace Domains.Entities 
{
    public class Image : Base.BaseEntity    
    {
        public string ImgPath { get; set; } = null!;    

        // Relations
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
