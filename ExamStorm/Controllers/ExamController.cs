using ExamStorm.DataManager;
using ExamStorm.DataManager.Interfaces;
using ExamStorm.DataManager.Models.Exam;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamStorm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IBaseRepository<ExamModel> _examModelRepository;

        public ExamController(ExamDbContext dbContext)
        {
            _examModelRepository = new RepositoryProvider(dbContext).GetExamRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ExamModel>> GetUsers(int pageSize = 10, int pageIndex = 0)
        {
            var skip = pageIndex > 0 ? pageSize * pageIndex - pageSize : 0;
            var userModel = await _examModelRepository.Get(skip: skip, take: pageSize);
            return Ok(userModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamModel>> GetById(Guid id)
        {
            var examModel = await _examModelRepository.GetByIdAsync(id);
            if (examModel == null)
            {
                return NotFound();
            }
            return Ok(examModel);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ExamModel>> Add(ExamModel examModel)
        {
            var res = await _examModelRepository.AddAsync(examModel);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest(examModel);

        }

        [HttpPost("Update")]
        public async Task<ActionResult<ExamModel>> Update(ExamModel examModel)
        {
            var res = await _examModelRepository.UpdateAsync(examModel);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest(examModel);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var exam = await _examModelRepository.GetByIdAsync(id);
            var isRemovedSucessfuly = await _examModelRepository.RemoveAsync(exam);
            if (isRemovedSucessfuly)
            {
                return Ok(isRemovedSucessfuly);
            }
            return NotFound();
        }
    }
}
