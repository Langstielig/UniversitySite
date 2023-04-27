using System.ComponentModel.DataAnnotations;

namespace CSharp_laba5._1.Domains.Entities
{
	public class TextField:Abstract
	{
		[Required]
		public string CodeWord { get; set; }

		[Display(Name = "Заголовок")]
		public override string Name { get; set; } = "О нас";

		[Display(Name = "Содержание страницы")]
		public override string Description { get; set; } = "Содержание заполняется администратором";
	}
}
