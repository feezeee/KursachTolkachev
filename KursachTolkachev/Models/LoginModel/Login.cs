using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указан мобильный телефон")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}
