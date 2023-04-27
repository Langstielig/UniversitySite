using CSharp_laba5._1.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CSharp_laba5._1.Domains.Repositories.EntityFramework
{
	public class EFTextFieldsRepository
	{
        private readonly UniversityContext _context;

        public EFTextFieldsRepository(UniversityContext context)
        {
            this._context = context;
        }

        public IQueryable<TextField> GetTextFields()
        {
            return _context.TextFields;
        }
        public TextField GetTextField(int id)
        {
            return _context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        public TextField GetTextField(string codeWord)
        {
            return _context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public void AddTextField(TextField textField)
        {
            _context.TextFields.Add(textField);
            _context.SaveChanges();
        }

        public void UpdateTextField(TextField textField)
        {
            _context.Entry(textField).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTextField(int id)
        {
            _context.TextFields.Remove(_context.TextFields.Find(id));
            _context.SaveChanges();
        }
    }
}
