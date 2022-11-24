using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotebookEntities.NoteBookDB
{
    public class NBUser
    {
        [Required]
        public int IdUser { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Max length 150, min length 10")]
        public string Password { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Max length 50  , min length 3")]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Max length 50  , min length 3")]
        public string LastName { get; set; }
    }
}
