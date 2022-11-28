using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotebookWeb.Models.Notebook
{
    public class NoteViewModel
    {
        [Required]
        public int IdNote { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title max characters 500 and min characters 3")]
        public string Title { get; set; }

        [StringLength(500, MinimumLength = 3, ErrorMessage = "Description max characters 500")]
        public string Body { get; set; }

        public DateTime Created { get; set; }

        public string DateCreated { get; set; }

        public DateTime Updated { get; set; }

        public string DateUpdated { get; set; }
    }
}
