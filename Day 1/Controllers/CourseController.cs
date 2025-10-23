namespace Day_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        AppDbContext context;
        public CourseController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public List<Course> get()
        {
            return context.Courses.ToList();
        }

        //[HttpGet("{id:int}")]
        [HttpGet("{id}")]
        public IActionResult getbyId(int id)
        {
            Course course = context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        //[HttpGet("{name:alpha}")]
        [HttpGet("/api/crs/{name}")] //is the better
        public IActionResult coursebyname(string name)
        {
            Course course = context.Courses.FirstOrDefault(c => c.Name == name);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public IActionResult Post(Course course)
        {
            if (course == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Courses.Add(course);
            context.SaveChanges();
            //return Created("ay7aga",student)
            return CreatedAtAction("GetbyId", new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Course course, int id)
        {
            if (course == null)
            {
                return BadRequest();
            }
            if (course.Id != id)
            {
                return BadRequest();
            }
            var existingCourse = context.Courses.Find(course.Id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            existingCourse.Name = course.Name;
            existingCourse.Duration = course.Duration;
            existingCourse.Description = course.Description;
            context.Courses.Update(existingCourse);

            //or

            //context.Entry(student).State = EntityState.Modified;  //error runtime
            context.SaveChanges();
            return NoContent();//204
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCourse(int id)
        {
            var existingCourse = context.Courses.Find(id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            context.Courses.Remove(existingCourse);
            context.SaveChanges();
            return Ok(existingCourse);
        }

    }
}
