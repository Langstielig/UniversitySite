using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharp_laba5._1.Domains.Entities
{
	public class Student: Abstract
	{
        [Required(ErrorMessage = "Заполните имя студента")]
		public override string Name { get; set; }

		[Required(ErrorMessage = "Заполните фамилию студента")]
		public string Surname { get; set; }
		public int Age { get; set; }
		public int? GroupId { get; set; }
        public Group Group { get; set; }

        [NotMapped]
        public ICollection<StudentActivity> StudentActivities { get; set; }

		//public string getActivities()
		//{
		//	string result;

		//}
    }
}
