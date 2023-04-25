using DAL.Models;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace PV178_Projects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRepository<Project> _repository;

        public ProjectsController(
            IUnitOfWorkFactory unitOfWorkFactory,
            IRepository<Project> repository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get()
        {
            List<Project> projects = new List<Project>();

            using (var db = _unitOfWorkFactory.CreateUnitOfWork())
            {
                projects.AddRange(_repository.Get());
            }

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            Project project = null;
            
            using (var db = _unitOfWorkFactory.CreateUnitOfWork())
            {
                project = _repository.Get(id);
            }
            
            return project == null ? NotFound(id) : Ok(project);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            using (var db = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _repository.Create(project);
                db.Save();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Project project)
        {
            using (var db = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var existingProject = _repository.Get(id);
                if (existingProject == null)
                {
                    return NotFound(id);
                }

                existingProject.Name = project.Name;
                existingProject.StudentId = project.StudentId;

                db.Save();
            }

            return Ok(id);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var db = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var project = _repository.Get(id);
                if (project == null)
                {
                    return NotFound(id);
                }

                _repository.Delete(id);
                db.Save();
            }

            return Ok(id);
        }
    }
}
