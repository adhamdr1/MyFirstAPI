using Day_1.Models;
using Day_1.UnitOfWork.Interface;

namespace Day_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        IUnitOfWork unitOfWork;
        public CourseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public List<Course> get()
        {
            return unitOfWork.CourseRepo.GetAll();
        }

        //[HttpGet("{id:int}")]
        [HttpGet("{id}")]
        public IActionResult getbyId(int id)
        {
            Course course = unitOfWork.CourseRepo.GetById(id);
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
            Course course = unitOfWork.CourseRepo.GetByCondition(c => c.Name == name);
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
            unitOfWork.CourseRepo.Add(course);
            unitOfWork.Save();
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
            var existingCourse = unitOfWork.CourseRepo.GetById(course.Id);
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
            unitOfWork.CourseRepo.Update(existingCourse);

            //or

            //context.Entry(student).State = EntityState.Modified;  //error runtime
            unitOfWork.Save();
            return NoContent();//204
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCourse(int id)
        {
            var existingCourse = unitOfWork.CourseRepo.GetById(id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            unitOfWork.CourseRepo.Delete(existingCourse.Id);
            unitOfWork.Save();
            return Ok(existingCourse);
        }

    }
}
