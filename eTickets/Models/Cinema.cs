using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Cinema Logo is required")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Cinema Name is required")]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Cinema Name must be between 3 and 50 chars")]
        public string Name { get; set; }


        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        //defining relationships
        public List<Movie> Movies { get; set; }

    }
}
