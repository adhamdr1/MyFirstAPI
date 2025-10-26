using Swashbuckle.AspNetCore.Annotations;

namespace Day_1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        AppDbContext context;
        public StudentController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = context.Students.ToList();
            List<StudentDTO> stdDTO = new List<StudentDTO>();

            foreach (var student in students)
            {
                StudentDTO studentDTO = new StudentDTO()
                {
                    Id = student.Id,
                    FullName = student.FullName,
                    age = student.age,
                    Address = student.Address,
                    DepartmentName = student.Department.Name
                };
                stdDTO.Add(studentDTO);
            }
            
            return Ok(stdDTO);
        }

        //[HttpGet("{id:int}")]
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get Student by Id",
            Description = "Get Student by Id from the database",
            OperationId = "GetStudentById"
           // Tags = new[] { "Student Endpoints" }
            )]
        [SwaggerResponse(200,"Return Student",typeof(Student))]
        [SwaggerResponse(404,"Student not found")]
        public IActionResult GetbyId(int id)
        {
            Student student = context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            var stdDTO = new StudentDTO()
            {
                Id = student.Id,
                FullName = student.FullName,
                age = student.age,
                Address = student.Address,
                DepartmentName = student.Department.Name
            };
            return Ok(stdDTO);
        }

        //[HttpGet("{name:alpha}")]
        [HttpGet("/api/sts/{name}")] //is the better
        public IActionResult Getbyname(string name)
        {
            Student student = context.Students.FirstOrDefault(c => c.FullName == name);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Students.Add(student);
            context.SaveChanges();
            //return Created("ay7aga",student)
            return CreatedAtAction("GetbyId", new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Student student, int id)
        {
            if (student == null)
            {
                return BadRequest();
            }
            if (student.Id != id)
            {
                return BadRequest();
            }
            var existingStudent = context.Students.Find(student.Id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            existingStudent.FullName = student.FullName;
            existingStudent.age = student.age;
            existingStudent.Address = student.Address;
            existingStudent.DepartmentId = student.DepartmentId;
            context.Students.Update(existingStudent);

            //or

            //context.Entry(student).State = EntityState.Modified;  //error runtime
            context.SaveChanges();
            return NoContent();//204
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingStudent = context.Students.Find(id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            context.Students.Remove(existingStudent);
            context.SaveChanges();
            return Ok(existingStudent);
        }

    }
}
