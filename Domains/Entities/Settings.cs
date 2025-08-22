
using Domains.Entities.Base;

namespace Domains.Entities
{
    public class Settings : BaseEntity
    {
        public string Location { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string InteriorLink { get; set; } = null!;// or WebsiteLink
        public string AboutMe { get; set; } = null!;
        public string Logo { get; set; } = null!; // store image path
        public string CopyrightText { get; set; } = null!;
        public int ProjectsCompleted { get; set; }
        public int YearsExperience { get; set; }
        public int HappyClients { get; set; }
    }
}
