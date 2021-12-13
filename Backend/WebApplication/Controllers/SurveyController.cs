using BL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : Controller
    {
        private readonly ISurveyServices surveyServices;
        public SurveyController(ISurveyServices surveyServices)
        {
            this.surveyServices = surveyServices;
        }

        [HttpGet]
        public IEnumerable<Question> GetAllQuestions()
        {
            return surveyServices.GetAllQuestions();
        }

        [HttpPost]
        public IActionResult RegisterAnswer([FromBody] List<Answer> answers)
        {
            try
            {
                surveyServices.RegisterAnswers(answers);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
