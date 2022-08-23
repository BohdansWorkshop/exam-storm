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

        [HttpPut]
        public async Task<ActionResult<ExamModel>> Put(ExamModel examModel)
        {
            var res = await _examModelRepository.AddOrUpdateAsync(examModel);
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
