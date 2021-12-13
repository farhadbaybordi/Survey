using DAL.Context;
using DAL.Entities;
using DAL.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services
{
    public interface ISurveyServices
    {
        IEnumerable<Question> GetAllQuestions();
        void RegisterAnswers(List<Answer> answers);
    }
    public class SurveyServices : ISurveyServices
    {
        private readonly IRepository<Question,QuestionContext> questionRepository;
        private readonly IRepository<Answer, AnswerContext> answerRepository;
        public SurveyServices(IRepository<Question, QuestionContext> questionRepository, IRepository<Answer, AnswerContext> answerRepository)
        {
            this.questionRepository = questionRepository;
            this.answerRepository = answerRepository;
        }
        public IEnumerable<Question> GetAllQuestions()
        {
            return questionRepository.GetEntities();
        }
        public void RegisterAnswers(List<Answer> answers) => answers.ForEach(x => answerRepository.InsertEntity(x));

    }
}
