using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MetalCore.ETL.Entities
{
    public class RecoveryPassword
    {
        public string token { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "La contraseña debe tener al menos 8 caracteres, mayusculas y un caracter espacial")]

        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "La contraseña debe tener al menos 8 caracteres, mayusculas y un caracter espacial")]
        public string Password2 { get; set; }


         [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
