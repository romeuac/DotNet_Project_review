using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Romeu_Project.ViewModels
{
    public class LoginViewModel
    {
        // Forma de tornar required tal campo no site, passando a mensagem de erro em aspas
        [Required(ErrorMessage ="Username is required")] 
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        // Forma de colocar uma max lenght para o campo password
        [StringLength(150, ErrorMessage ="Must be between 5 and 150 characters", MinimumLength = 5)]
        public string Password { get; set; }
    }
}
