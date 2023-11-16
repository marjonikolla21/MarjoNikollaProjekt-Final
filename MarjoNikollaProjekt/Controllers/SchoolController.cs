using CompaniesApp.API.Data;
using MarjoNikollaProjekt.API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ConsoleAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        // Merr të gjitha shkollat nga databaza
        [HttpGet]
        public IActionResult MerrTëGjithaShkollat()
        {
            var tëGjithaShkollatNgaDb = FakeDb.GetAllSchools();
            return Ok(tëGjithaShkollatNgaDb);
        }

        // Merr një shkollë me id e caktuar
        [HttpGet("{id}")]
        public IActionResult MerrShkollëNgaId(int id)
        {
            var shkollëNgaDb = FakeDb.SchoolsDb.FirstOrDefault(x => x.Id == id);

            if (shkollëNgaDb == null)
            {
                return NotFound($"Shkolla me id = {id} nuk u gjet");
            }
            else
            {
                return Ok(shkollëNgaDb);
            }
        }
    }
}

//Kjo është një klasë kontrolluese në ASP.NET Core API,
//e cila është përgjegjëse për menaxhimin e të dhënave të shkollave.
//Klasa përdor atributet [Route("api/[controller]")] dhe [ApiController] për të specifikuar
//rrugën e API-ut dhe për të shënuar klasën si një kontroller API.

//Metoda MerrTëGjithaShkollat(GetAllSchools) kthen të gjitha shkollat nga databaza
//duke përdorur metoden GetAllSchools e cila është definuar në klasën e ndihmës FakeDb.
//Kjo metode përdor Ok për të kthyer një përgjigje pozitive me të dhënat e shkollave.

//Metoda MerrShkollëNgaId (GetSchoolById) merr një shkollë me një ID të caktuar nga databaza
//duke përdorur FirstOrDefault në listën e shkollave në FakeDb.SchoolsDb.
//Nëse shkolla nuk gjendet, kthehet një përgjigje NotFound,
//ndryshe kthehet një përgjigje pozitive me të dhënat e shkollës.

