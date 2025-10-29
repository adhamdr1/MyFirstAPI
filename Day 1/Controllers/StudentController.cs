using Day_1.Models;
using Day_1.UnitOfWork.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace Day_1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IUnitOfWork unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = unitOfWork.StudentRepo.GetAll();
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
            Student student = unitOfWork.StudentRepo.GetById(id);
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
            Student student = unitOfWork.StudentRepo.GetByCondition(c => c.FullName == name);
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
            unitOfWork.StudentRepo.Add(student);
            unitOfWork.Save();
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
            var existingStudent = unitOfWork.StudentRepo.GetById(student.Id);
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
            unitOfWork.StudentRepo.Update(existingStudent);

            //or

            //context.Entry(student).State = EntityState.Modified;  //error runtime
            unitOfWork.Save();
            return NoContent();//204
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingStudent = unitOfWork.StudentRepo.GetById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            unitOfWork.StudentRepo.Delete(existingStudent.Id);
            unitOfWork.Save();
            return Ok(existingStudent);
        }

    }
}
