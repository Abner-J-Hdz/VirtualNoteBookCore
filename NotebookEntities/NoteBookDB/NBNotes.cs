﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotebookEntities.NoteBookDB
{
    public class NBNotes
    {
        [Required]
        public int IdNote { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title max characters 500 and min characters 3")]
        public string Title { get; set; }

        [StringLength(500, MinimumLength = 3, ErrorMessage = "Description max characters 500")]
        public string Body { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
