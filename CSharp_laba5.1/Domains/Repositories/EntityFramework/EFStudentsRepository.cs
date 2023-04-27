using CSharp_laba5._1.Areas.Admin.Controllers;
using CSharp_laba5._1.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CSharp_laba5._1.Domains.Repositories.EntityFramework
{
	public class EFStudentsRepository
	{
		private readonly UniversityContext _context;

		public EFStudentsRepository(UniversityContext context)
		{
			this._context = context;
		}

        public IQueryable<Student> GetStudents()
		{
			return _context.Students;
		}
        public Student GetStudent(int id)
		{
			return _context.Students.Find(id);
		}

		public void AddOrUpdateStudent(Student student)
		{
			if (student.Id == default)
			{
				if (student.GroupId != default) 
				{
					Group group = _context.Groups.Find(student.GroupId);
					student.Group = group;
					group.Students.Add(student);
					_context.Entry(group).State = EntityState.Modified;
                }
				_context.Entry(student).State = EntityState.Added;
			}
			else
			{
                if (student.GroupId != default)
				{
                    Group group = _context.Groups.Find(student.GroupId);
					if(group != null)
					{
                        student.Group = group;
                        group.Students.Add(student);
                        _context.Entry(group).State = EntityState.Modified;
                    }
                }
                _context.Entry(student).State = EntityState.Modified;
			}
			_context.SaveChanges();
		}

		public void DeleteStudent(int id)
		{
			Student st = _context.Students.Find(id);
			foreach (var stAct in _context.StudentActivities)
			{
				if(stAct.StudentId == id)
				{
					_context.StudentActivities.Remove(stAct);
				}
            }
            _context.Students.Remove(st);
			_context.SaveChanges();
		}

		public void AddStudentToActivity(int id, string nameOfActivity)
		{
			Activity result = null;
			Student student = _context.Students.Find(id);
			foreach(Activity activity in _context.Activities)
			{
				if (activity.Name == nameOfActivity)
					result = activity;
			}
			StudentActivity stAct = new StudentActivity { StudentId = id, Student = student, ActivityId = result.Id, Activity = result};
			//result.StudentActivities.Add(stAct);
            _context.Entry(stAct).State = EntityState.Added;
			//_context.Entry(result).State = EntityState.Modified;
			student.StudentActivities.Add(stAct);
			_context.Entry(student).State = EntityState.Modified;
			_context.SaveChanges();
        }

		public void DeleteActivity(int id, string nameOfActivity)
		{
            Activity result = null;
            Student student = _context.Students.Find(id);
            foreach (Activity activity in _context.Activities)
            {
                if (activity.Name == nameOfActivity)
                    result = activity;
            }
            StudentActivity stAct = null;
            foreach (StudentActivity s in _context.StudentActivities)
            {
                if (s.StudentId == id && s.ActivityId == result.Id)
                    stAct = s;
            }
			//student.StudentActivities.Add(stAct);
			//result.StudentActivities.Add(stAct);
			_context.StudentActivities.Remove(stAct);
            //_context.Entry(student).State = EntityState.Modified;
            //_context.Entry(result).State = EntityState.Modified;
            _context.SaveChanges();
        }

		public bool isNameExists(ClassForName studentName)
		{
			bool flag = false;
			foreach(var student in _context.Students)
			{
				if (studentName.Name == student.Name && studentName.Surname == student.Surname)
					flag = true;
			}
			return flag;
		}
    }
}
