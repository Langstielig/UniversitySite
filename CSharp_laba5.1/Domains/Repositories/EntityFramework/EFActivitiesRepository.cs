using CSharp_laba5._1.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_laba5._1.Domains.Repositories.EntityFramework
{
    public class EFActivitiesRepository
    {
        private readonly UniversityContext _context;

        public EFActivitiesRepository(UniversityContext context)
        {
            this._context = context;
        }

        public IQueryable<Activity> GetActivities()
        {
            return _context.Activities;
        }
        public Activity GetActivity(int id)
        {
            return _context.Activities.Find(id);
        }

        public List<Student> GetStudents(int id)
        {
            List<Student> students = new List<Student>();
            Student st;
            foreach (StudentActivity stAct in _context.StudentActivities)
            {
                if(stAct.ActivityId == id)
                {
                    st = _context.Students.Find(stAct.StudentId);
                    students.Add(st);
                }
            }
            return students;
        }
        public void AddOrUpdateActivity(Activity activity)
        {
            if (activity.Id == default)
            {
                _context.Entry(activity).State = EntityState.Added;
            }
            else
            {
                _context.Entry(activity).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
        public void DeleteActivity(int id)
        {
            Activity act = _context.Activities.Find(id);
            foreach (var stAct in _context.StudentActivities)
            {
                if(stAct.ActivityId == id)
                {
                    _context.StudentActivities.Remove(stAct);
                }
            }
            _context.Activities.Remove(_context.Activities.Find(id));
            _context.SaveChanges();
        }

        public void addActivityToStudent(int id, ClassForName nameOfStudent)
        {
            Student result = null;
            Activity activity = _context.Activities.Find(id);
            foreach (Student student in _context.Students)
            {
                if (student.Name == nameOfStudent.Name && student.Surname == nameOfStudent.Surname)
                    result = student;
            }
            StudentActivity stAct = new StudentActivity { StudentId = result.Id, Student = result, ActivityId = activity.Id, Activity = activity };
            //student.StudentActivities.Add(stAct);
            //result.StudentActivities.Add(stAct);
            _context.Entry(stAct).State = EntityState.Added;
            //_context.Entry(student).State = EntityState.Modified;
            //_context.Entry(result).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void deleteStudent(int id, ClassForName nameOfStudent)
        {
            Student result = null;
            Activity activity = _context.Activities.Find(id);
            foreach (Student student in _context.Students)
            {
                if (student.Name == nameOfStudent.Name && student.Surname == nameOfStudent.Surname)
                    result = student;
            }
            StudentActivity stAct = null;
            foreach (StudentActivity s in _context.StudentActivities)
            {
                if (s.StudentId == result.Id && s.ActivityId == id)
                    stAct = s;
            }
            //student.StudentActivities.Add(stAct);
            //result.StudentActivities.Add(stAct);
            if(stAct != null)
                _context.StudentActivities.Remove(stAct);
            //_context.Entry(student).State = EntityState.Modified;
            //_context.Entry(result).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool isNameExists(string nameOfActivity)
        {
            bool flag = false;
            foreach(Activity activity in _context.Activities)
            {
                if (activity.Name == nameOfActivity)
                    flag = true;
            }
            return flag;
        }

        public bool isConnectionExists(int idOfActivity, ClassForName nameOfStudent)
        {
            bool flag = false;
            Student student = null;
            foreach (Student s in _context.Students)
            {
                if (s.Name == nameOfStudent.Name && s.Surname == nameOfStudent.Surname)
                    student = s;
            }
            foreach (StudentActivity stAct in _context.StudentActivities)
            {
                if (stAct.StudentId == student.Id && stAct.ActivityId == idOfActivity)
                    flag = true;
            }
            return flag;
        }
    }
}
