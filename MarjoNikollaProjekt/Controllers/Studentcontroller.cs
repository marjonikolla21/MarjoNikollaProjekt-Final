using CompaniesApp.API.Data;
using MarjoNikollaProjekt.API.Data.Models;
using MarjoNikollaProjekt.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // Marrim të gjithë studentët nga databaza
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var tëGjithëStudentëtNgaDb = FakeDb.StudentsDb.ToList();
            return Ok(tëGjithëStudentëtNgaDb);
        }

        // Marrim një student me një id të caktuar
        [HttpGet("{id}")]
        public IActionResult MerrStudentId(int id)
        {
            var studentNgaDb = FakeDb.StudentsDb.FirstOrDefault(x => x.Id == id);

            if (studentNgaDb == null)
            {
                return NotFound($"Student me id = {id} nuk u gjet");
            }
            else
            {
                return Ok(studentNgaDb);
            }
        }

        // Fshij një student me një id të caktuar
        [HttpDelete("{id}")]
        public IActionResult FshijStudentId(int id)
        {
            var studentNgaDb = FakeDb.StudentsDb.FirstOrDefault(x => x.Id == id);

            if (studentNgaDb == null)
            {
                return NotFound($"Student me id = {id} nuk u gjet");
            }
            else
            {
                FakeDb.StudentsDb.Remove(studentNgaDb);

                var listaMëeRe = FakeDb.StudentsDb.ToList();
                return Ok($"Student me id = {id} është larguar");
            }
        }

        // Shto një student të ri në databazë
        [HttpPost]
        public IActionResult ShtoStudent([FromBody] PostStudentDto payload)
        {
            // 1. Krijohet objekti
            var studentIRi = new Student()
            {
                // Do të gjeneroj id e studentëve nga 10-99
                Id = new Random().Next(10, 100),

                StName = payload.StName,
                LsName = payload.StName,
                DOB = payload.DOB,
            };

            // 2. Shtohet objekti në DB
            FakeDb.StudentsDb.Add(studentIRi);

            return Ok("Studenti është shtuar");
        }

        // Përditëso një student me një id të caktuar
        [HttpPut("{id}")]
        public IActionResult PërditësoStudentin([FromBody] PutStudentDto tëDhënatEreja, int id)
        {
            // 1. Merr të dhënat e vjetra nga db
            var studentNgaDb = FakeDb.StudentsDb.FirstOrDefault(x => x.Id == id);

            if (studentNgaDb == null)
            {
                return NotFound("Studenti nuk mund të përditësohet");
            }

            // 2. Përditëso të dhënat
            studentNgaDb.StName = tëDhënatEreja.StName;
            studentNgaDb.LsName = tëDhënatEreja.LsName;
            studentNgaDb.DOB = tëDhënatEreja.DOB;

            // 3. Ruaj në databazë

            return Ok("Studenti është përditësuar");
        }
    }
}
