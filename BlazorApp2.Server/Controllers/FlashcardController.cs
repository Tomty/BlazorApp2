using BlazorApp2.Server.DataAccess;
using BlazorApp2.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Server.Controllers
{
    public class FlashCardController : Controller
    {
        DataAccessLayer _flashcard = new DataAccessLayer();

        [HttpGet]
        [Route("api/FlashCard/Index")]
        public IEnumerable<Flashcard> Index()
        {
            return _flashcard.GetAllFlashCard();
        }

        [HttpGet]
        [Route("api/FlashCard/GetByCategory/{id}")]
        public IEnumerable<Flashcard> GetByCategory(int id)
        {
            return _flashcard.GetFlashCardByCategory(id);
        }

        [HttpGet]
        [Route("api/FlashCard/{id}")]
        public Flashcard GetById(int id)
        {
            return _flashcard.GetById(id);
        }

        [HttpPost]
        [Route("api/FlashCard/Create")]
        public void Create([FromBody] Flashcard fc)
        {
            if (ModelState.IsValid)
                _flashcard.AddFlashCard(fc);
        }

        [HttpPut]
        [Route("api/FlashCard/Edit")]
        public void Edit([FromBody]Flashcard fc)
        {
            if (ModelState.IsValid)
                _flashcard.UpdateFlashCard(fc);
        }

        [HttpDelete]
        [Route("api/FlashCard/Delete/{id}")]
        public void Delete(int id)
        {
            _flashcard.DeleteFlashCard(id);
        }
    }
}
