namespace Day_1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        AppDbContext context;
        public DepartmentController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var departments = context.Departments.ToList();
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
            Department department = context.Departments.Find(id);
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
            Department department = context.Departments.FirstOrDefault(c => c.Name == name);
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
            context.Departments.Add(department);
            context.SaveChanges();
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
            var existingDepartment = context.Departments.Find(department.Id);
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
            context.Departments.Update(existingDepartment);

            //or

            //context.Entry(student).State = EntityState.Modified;  //error runtime
            context.SaveChanges();
            return NoContent();//204
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingDepartment = context.Departments.Find(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }
            context.Departments.Remove(existingDepartment);
            context.SaveChanges();
            return Ok(existingDepartment);
        }

    }
}
