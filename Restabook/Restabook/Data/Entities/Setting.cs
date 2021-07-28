using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Setting:BaseEntity
    {
       
        public string HeaderLogo { get; set; }

        [NotMapped]
        public IFormFile Header { get; set; }

       
        public string FooterLogo { get; set; }

        [NotMapped]
        public IFormFile Footer { get; set; }

        [StringLength(maximumLength: 200, ErrorMessage = "Lenght should be no more than 200 characters!!!")]
        public string FooterDesc { get; set; }


        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string VideoRedirectUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string FacebookUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string TwitterUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string InstagramUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string VkUrl { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string StartDay1 { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string StartTime1 { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string OverDay1 { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string OverTime1 { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string StartDay2 { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string StartTime2 { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string OverDay2 { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string OverTime2 { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string ServicePhone { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string SupportEmail { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string SupportPhone { get; set; }

       

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 5000, ErrorMessage = "Lenght should be no more than 5000 characters!!!")]
        public string AboutStory { get; set; }

        
        public string AboutPhoto { get; set; }

        [NotMapped]
        public IFormFile AboutFile { get; set; }

        [NotMapped]
        public List<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}
