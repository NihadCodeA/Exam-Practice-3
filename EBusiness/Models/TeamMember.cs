using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBusiness.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50)]
        public string Fullname { get; set; }
        [StringLength(maximumLength:50)]
        public string Positon { get; set; }

        public int Order { get; set; }
        public string? SocialMediaAccountUrl1 { get; set; }
        public string? SocialMediaAccountIcon1 { get; set; }
        public string? SocialMediaAccountUrl2 { get; set; }
        public string? SocialMediaAccountIcon2 { get; set; }
        public string? SocialMediaAccountUrl3 { get; set; }
        public string? SocialMediaAccountIcon3 { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
