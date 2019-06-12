using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BlazorApp2.Shared.Models;

namespace BlazorApp2.Server.DataAccess
{
    public class DataAccessLayer
    {
        BlazorCardContext db = new BlazorCardContext();
        public IEnumerable<Flashcard> GetAllFlashCard()
        {
            try
            {
                return db.Flashcard
                    .Include(fc => fc.Category)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }
        public Flashcard GetById(int id)
        {
            try
            {
                return db.Flashcard
                    .Where(fc => fc.FlashcardId == id)
                    .Include(fc => fc.Category)
                    .FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public void AddFlashCard(Flashcard fc)
        {
            try
            {
                db.Flashcard.Add(fc);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateFlashCard(Flashcard fc)
        {
            try
            {
                db.Entry(fc).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteFlashCard(int id)
        {
            try
            {
                Flashcard fc = db.Flashcard.Find(id);
                db.Flashcard.Remove(fc);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Category> GetAllCategory()
        {
            try
            {
                return db.Category.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Flashcard> GetFlashCardByCategory(int id)
        {
            try
            {
                List<Flashcard> fcList = new List<Flashcard>();
                fcList = db.Flashcard
                    .Where(fc => fc.CategoryId == id)
                    .Include(f => f.Category)
                    .ToList();
                return fcList;
            }
            catch
            {
                throw;
            }
        }
    }
}
