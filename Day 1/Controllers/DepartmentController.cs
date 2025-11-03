using Day_1.UnitOfWork.Interface;

namespace Day_1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IUnitOfWork unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var departments = unitOfWork.DepartmentRepo.GetAll();
            List<DepartmentDTO> deptDTO = new List<DepartmentDTO>();

            foreach (var department in departments)
            {
                DepartmentDTO departmentDTO = new DepartmentDTO()
                {
                    Id = department.Id,
                    Name = department.Name,
                    Location = department.Loc,
                    // StudentsName = department.Students.Select(s=>s.FullName).ToList(),
                    CountOfStudent = department.Students.Count
                };
                deptDTO.Add(departmentDTO);
            }
            
            return Ok(deptDTO);
        }

        //[HttpGet("{id:int}")]
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            Department department = unitOfWork.DepartmentRepo.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            DepartmentDTO departmentDTO = new DepartmentDTO()
            {
                Id = department.Id,
                Name = department.Name,
                Location = department.Loc,
                CountOfStudent = department.Students.Count
                // StudentsName = department.Students.Select(s => s.FullName).ToList(),
            };
            //foreach (var student in department.Students)
            //{
            //    departmentDTO.StudentsName.Add(student.FullName);
            //}
            return Ok(departmentDTO);
        }

        //[HttpGet("{name:alpha}")]
        [HttpGet("/api/dept/{name}")] //is the better
        public IActionResult Getbyname(string name)
        {
            Department department = unitOfWork.DepartmentRepo.GetByCondition(c => c.Name == name);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unitOfWork.DepartmentRepo.Add(department);
            unitOfWork.Save();
            //return Created("ay7aga",student)
            return CreatedAtAction("GetbyId", new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Department department, int id)
        {
            if (department == null)
            {
                return BadRequest();
            }
            if (department.Id != id)
            {
                return BadRequest();
            }
            var existingDepartment = unitOfWork.DepartmentRepo.GetById(department.Id);
            if (existingDepartment == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            existingDepartment.Name = department.Name;
            existingDepartment.Loc = department.Loc;
            //existingDepartment.Address = department.Address;
            //existingDepartment.DepartmentId = department.DepartmentId;
            unitOfWork.DepartmentRepo.Update(existingDepartment);

            //or

            //context.Entry(student).State = EntityState.Modified;  //error runtime
            unitOfWork.Save();
            return NoContent();//204
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingDepartment = unitOfWork.DepartmentRepo.GetById(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }
            unitOfWork.DepartmentRepo.Delete(existingDepartment.Id);
            unitOfWork.Save();
            return Ok(existingDepartment);
        }

    }
}
