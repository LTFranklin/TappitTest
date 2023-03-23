using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TappitTest.Models;

namespace TappitTest.Controllers
{
    [ApiController]
    public class SportController : Controller
    {
        public DatabaseContext _databaseContext { get; set; }
        public SportController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        //Get the id from the Url
        [HttpGet("/Person/{id}")]
        public JsonResult Person(int id)
        {
            //Get the person requested, include the other tables for easy access
            var person = _databaseContext.People
                .Include(x => x.FavouriteSports)
                .ThenInclude(x => x.Sports)
                .SingleOrDefault(x => x.PersonId == id) ?? null;
            //make a Dto instead of JSON parsing everything as this can create errors with infinite loops (+ some stuff isn't required like sportID)
            return Json(person?.ToDto());
        }
        [HttpGet("/People")]
        public JsonResult People()
        {
            var people = _databaseContext.People
                .Include(x => x.FavouriteSports)
                .ThenInclude(x => x.Sports)
                .Select(x => x.ToDto());
            return Json(people);
        }
        [HttpGet("/Sports")]
        public JsonResult Sports()
        {
            var sport = _databaseContext.Sports
                .Include(x => x.FavouriteSports)
                .Select(x => x.ToDto());
            return Json(sport);
        }
    }
}
