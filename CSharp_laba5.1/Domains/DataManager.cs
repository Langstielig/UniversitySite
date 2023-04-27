using CSharp_laba5._1.Domains.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_laba5._1.Domains
{
	public class DataManager //класс-помощник для связи с базой данных
	{
		public EFStudentsRepository Students { get; set; }
		public EFTextFieldsRepository TextFields { get; set; }
		public EFGroupsRepository Groups { get; set; }
		public EFActivitiesRepository Activities { get; set; }
		public EFStudentActivityRepository StudentActivities { get; set; }


		public DataManager(EFStudentsRepository studentsRepository, EFTextFieldsRepository textFieldsRepository, 
			EFGroupsRepository groups, EFActivitiesRepository activities, EFStudentActivityRepository studentActivities)
		{
			Students = studentsRepository;
			TextFields = textFieldsRepository;
			Groups = groups;
			Activities = activities;
			StudentActivities = studentActivities;
		}
	}
}
