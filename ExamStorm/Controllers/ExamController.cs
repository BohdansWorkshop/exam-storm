using ExamStorm.DataManager;
using ExamStorm.DataManager.Interfaces;
using ExamStorm.DataManager.Models.Exam;
using ExamStorm.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamStorm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IBaseRepository<ExamModel> _examModelRepository;
        private readonly IBaseRepository<QuestionModel> _questionModelRepository;
        private readonly IBaseRepository<AnswerModel> _answerModelRepository;

        public ExamController(ExamDbContext dbContext)
        {
            var repoProvider = new RepositoryProvider(dbContext);
            _examModelRepository = repoProvider.GetExamRepository;
            _questionModelRepository = repoProvider.GetQuestionsRepository;
            _answerModelRepository = repoProvider.GetAnswerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ExamModel>> GetExams(int pageSize = 10, int pageIndex = 0)
        {
            var skip = pageIndex > 0 ? pageSize * pageIndex - pageSize : 0;
            var examsList = await _examModelRepository.Get(skip: skip, take: pageSize);
            return Ok(examsList);
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

        [HttpPost("CheckAnswers")]
        public async Task<ActionResult<Dictionary<string, bool>>> CheckAnswers(ExamResultsDTO examResults)
        {
            IDictionary<string, bool> questionIdToResultMap = new Dictionary<string, bool>();
            var currentExam = await _examModelRepository.GetByIdAsync(Guid.Parse(examResults.ExamId));
            foreach (var qIdaId in examResults.QuestionIdToAnswerIdMap)
            {
                var currentQuestion = currentExam.Questions.FirstOrDefault(q=>q.Id == Guid.Parse(qIdaId.Key));
                var currentAnswer = currentQuestion.Answers.FirstOrDefault(a => a.Id == Guid.Parse(qIdaId.Value));
                questionIdToResultMap.Add(qIdaId.Key, currentAnswer.IsCorrect);
            }
            return Ok(questionIdToResultMap);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var exam = await _examModelRepository.GetByIdAsync(id);

            foreach (var question in exam.Questions)
            {
                foreach (var answer in question.Answers)
                {
                    await _answerModelRepository.RemoveAsync(answer);
                }
                await _questionModelRepository.RemoveAsync(question);
            }

            var isRemovedSucessfuly = await _examModelRepository.RemoveAsync(exam);
            if (isRemovedSucessfuly)
            {
                return Ok(isRemovedSucessfuly);
            }
            return NotFound();
        }
    }
}
