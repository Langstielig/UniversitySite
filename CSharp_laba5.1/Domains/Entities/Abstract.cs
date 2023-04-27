using System;
using System.ComponentModel.DataAnnotations;

namespace CSharp_laba5._1.Domains.Entities
{
	public class Abstract
	{	
		[Required]
		public int Id { get; set; }

		[Display(Name = "Имя/Название")]
		public virtual string Name { get; set; }

		[Display(Name = "Описание")]
		public virtual string Description { get; set; }

		[Display(Name = "Картинка")]
		public virtual string InmagePath { get; set; }

		[Display(Name = "SEO метатег Name")]
		public string MetaName { get; set; }

		[Display(Name = "SEO метатег Description")]
		public virtual string MetaDescription { get; set; }

		[Display(Name = "SEO метатег KeyWords")]
		public virtual string MetaKeywords { get; set; }
	}
}
