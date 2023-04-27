using CSharp_laba5._1.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CSharp_laba5._1.Domains.Repositories.EntityFramework
{
    public class EFGroupsRepository
    {
        private readonly UniversityContext _context;

        public EFGroupsRepository(UniversityContext context)
        {
            this._context = context;
        }

        public IQueryable<Group> GetGroups()
        {
            return _context.Groups;
        }
        public Group GetGroup(int id)
        {
            return _context.Groups.Find(id);
        }

        public void AddOrUpdateGroup(Group group)
        {
            if (group.Id == default)
            {
                _context.Entry(group).State = EntityState.Added;
            }
            else
            {
                _context.Entry(group).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
        public void DeleteGroup(int id)
        {
            Group group = _context.Groups.Find(id);
            foreach (var s in _context.Students)
            {
                if(s.GroupId == id)
                {
                    s.Group = null;
                    s.GroupId = null;
                }
            }
            _context.Groups.Remove(_context.Groups.Find(id));
            _context.SaveChanges();
        }

        public void AddStudent(int id, ClassForName nameOfStudent)
        {
            Group group = _context.Groups.Find(id);
            Student student = null;
            foreach(Student st in _context.Students)
            {
                if (st.Name == nameOfStudent.Name && st.Surname == nameOfStudent.Surname)
                    student = st;
            }
            student.GroupId = group.Id;
            student.Group = group;
            _context.Entry(student).State = EntityState.Modified;
            group.Students.Add(student);
            _context.Entry(group).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
