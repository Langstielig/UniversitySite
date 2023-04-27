using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CSharp_laba5._1.Models
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Логин")]
		public string UserName { get; set; }

		[Required]
		[UIHint("password")]
		[Display(Name = "Пароль")]
		public string Password { get; set; }

		[Display(Name ="Запомнить?")]
		public bool RememberMe { get; set; }
	}
}
