using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VezeetaAPI.DTOs.Patient;
using VezeetaAPI.Models;

namespace VezeetaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        VezeetaContext db;
        IMapper mapper;

        public PatientController(VezeetaContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPatient([FromBody] PatientRegisterDTO registerDTO)
        {
            if (await db.Patients.AnyAsync(p => p.Pemail == registerDTO.Email))
            {
                return BadRequest("This email is already registered.");
            }

            var newPatient = mapper.Map<Patient>(registerDTO);

            db.Patients.Add(newPatient);
            await db.SaveChangesAsync();

            return Ok(new { message = "Patient registered successfully!" });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] PatientLoginDTO loginDto)
        {
            var patient = await db.Patients.FirstOrDefaultAsync(p => p.Pemail == loginDto.Email);

            if (patient == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, patient.PpasswordHash);

            if (!isPasswordValid)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            return Ok(new { message = "Login successful!", patientName = patient.Pname });
        }
    }

}

