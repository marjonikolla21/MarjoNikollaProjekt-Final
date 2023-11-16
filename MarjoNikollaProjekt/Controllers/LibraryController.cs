using CompaniesApp.API.Data;
using MarjoNikollaProjekt.API.Data;
using MarjoNikollaProjekt.API.Data.Models;
using MarjoNikollaProjekt.Data.DTOs;
using MarjoNikollaProjekt.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MarjoNikollaProjekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // Marrim të gjitha librat nga databaza
        [HttpGet]
        public IActionResult MerrTëGjithaLibrat()
        {
            var tëGjithaLibratNgaDb = FakeDb.BooksDb.ToList();
            return Ok(tëGjithaLibratNgaDb);
        }

        // Merr një libër me ID e caktuar
        [HttpGet("{id}")]
        public IActionResult MerrLibërNgaId(int id)
        {
            var libërNgaDb = FakeDb.BooksDb.FirstOrDefault(x => x.Id == id);

            if (libërNgaDb == null)
            {
                return NotFound($"Libër me id = {id} nuk u gjet");
            }
            else
            {
                return Ok(libërNgaDb);
            }
        }

        // Fshij një libër me ID e caktuar
        [HttpDelete("{id}")]
        public IActionResult FshijLibërNgaId(int id)
        {
            var libërNgaDb = FakeDb.BooksDb.FirstOrDefault(x => x.Id == id);

            if (libërNgaDb == null)
            {
                return NotFound($"Libër me id = {id} nuk u gjet");
            }
            else
            {
                FakeDb.BooksDb.Remove(libërNgaDb);

                var listaMëeRe = FakeDb.BooksDb.ToList();
                return Ok($"Libër me id = {id} është larguar");
            }
        }

        // Shto një libër të ri në bibliotekë
        [HttpPost]
        public IActionResult ShtoLibër([FromBody] PostBookDto payload)
        {
            var libërIRi = new Book()
            {
                Id = new Random().Next(10, 100), // Gjenerimi i një ID të rastësishëm për shembull

                Title = payload.Title,
                Author = payload.Author,
                Year = payload.Year
            };

            FakeDb.BooksDb.Add(libërIRi);

            return Ok("Libër është shtuar");
        }

        // Përditëso një libër me ID e caktuar
        [HttpPut("{id}")]
        public IActionResult PërditësoLibër([FromBody] PutBookDto tëDhënatEreja, int id)
        {
            var libërNgaDb = FakeDb.BooksDb.FirstOrDefault(x => x.Id == id);

            if (libërNgaDb == null)
            {
                return NotFound("Libër nuk mund të përditësohet");
            }

            // Përditëso të dhënat e librit
            libërNgaDb.Title = tëDhënatEreja.Title;
            libërNgaDb.Author = tëDhënatEreja.Author;
            libërNgaDb.Year = tëDhënatEreja.Year;

            return Ok("Librat janë përditësuar");
        }
    }
}
