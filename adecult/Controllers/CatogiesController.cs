using System;
using System.Collections.Generic;
using adecult.entities;
using adecult.Logic;
using adecult.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace adecult.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // GET api/Categories
        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            var categoryLogic = new CategoryLogic();
            var cats = categoryLogic.GetCategorias();
            Console.WriteLine(cats);
            return cats;
        }

        // GET api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
