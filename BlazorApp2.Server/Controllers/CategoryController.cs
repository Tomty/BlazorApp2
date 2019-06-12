using BlazorApp2.Server.DataAccess;
using BlazorApp2.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Server.Controllers
{
    public class CategoryController : Controller
    {
        DataAccessLayer _flashcard = new DataAccessLayer();

        [HttpGet]
        [Route("api/Category/Index")]
        public IEnumerable<Category> Index()
        {
            return _flashcard.GetAllCategory();
        }
    }
}
