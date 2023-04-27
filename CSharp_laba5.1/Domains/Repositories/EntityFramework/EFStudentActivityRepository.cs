using CSharp_laba5._1.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CSharp_laba5._1.Domains.Repositories.EntityFramework
{
    public class EFStudentActivityRepository
    {
        private readonly UniversityContext _context;

        public EFStudentActivityRepository(UniversityContext context)
        {
            this._context = context;
        }
        public IQueryable<StudentActivity> GetStudentActivities()
        {
            return _context.StudentActivities;
        }
        public StudentActivity GetStudentActivity(int id)
        {
            return _context.StudentActivities.Find(id);
        }
        public void AddOrUpdateStudentActivity(StudentActivity stAct)
        {
            if (stAct.Id == default)
            {
                Student student = _context.Students.Find(stAct.StudentId);
                stAct.Student = student;
                Activity activity = _context.Activities.Find(stAct.ActivityId);
                stAct.Activity = activity;
                _context.Entry(stAct).State = EntityState.Added;
            }
            else
            {
                Student student = _context.Students.Find(stAct.StudentId);
                stAct.Student = student;
                Activity activity = _context.Activities.Find(stAct.ActivityId);
                stAct.Activity = activity;
                _context.Entry(stAct).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
        public void DeleteStudentActivity(int id) //не работает
        {
            StudentActivity stAct = _context.StudentActivities.Find(id);
            Student student = _context.Students.Find(stAct.StudentId);
            foreach (var s in student.StudentActivities)
            {
                student.StudentActivities.Remove(s);
            }
            Activity activity = _context.Activities.Find(stAct.ActivityId);
            foreach(var a in activity.StudentActivities)
            {
                activity.StudentActivities.Remove(a);
            }
            _context.StudentActivities.Remove(stAct);
            _context.SaveChanges();
        }

        public StudentActivity findStudentActivity(int idOfStudent, int idOfActivity)
        {
            StudentActivity result = null;
            foreach(StudentActivity stAct in _context.StudentActivities)
            {
                if (stAct.StudentId == idOfStudent && stAct.ActivityId == idOfActivity)
                    result = stAct;
            }
            return result;
        }

        public bool isConnectionExists(int idOfStudent, string nameOfActivity)
        {
            bool flag = false;
            Activity activity = null;
            foreach (Activity a in _context.Activities)
            {
                if (a.Name == nameOfActivity)
                    activity = a;
            }
            foreach(StudentActivity stAct in _context.StudentActivities)
            {
                if (stAct.StudentId == idOfStudent && stAct.ActivityId == activity.Id)
                    flag = true;
            }
            return flag;
        }
    }
}
