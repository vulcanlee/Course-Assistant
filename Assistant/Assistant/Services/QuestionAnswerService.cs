using Assistant.DataModels;
using Assistant.Extensions;
using Assistant.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private readonly MyDbContext myDbContext;

        public QuestionAnswerService(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public async Task<List<QuestionAnswer>> RetriveAsync(Course course)
        {
            return await myDbContext.QuestionAnswers.Where(x=>x.Course == course)
                .OrderByDescending(x=>x.Created).ToListAsync();
        }
        public async Task<QuestionAnswer> RetriveAsync(int id)
        {
            return await myDbContext.QuestionAnswers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedResult<QuestionAnswer>> GetPagedAsync(Course course, int page, int pageSize)
        {
            return await myDbContext.QuestionAnswers.Where(x => x.Course == course)
                .OrderByDescending(x => x.Created).GetPaged(page, pageSize);
        }
        public async Task CreateAsync(QuestionAnswer courseUser)
        {
            await myDbContext.QuestionAnswers.AddAsync(courseUser);
            await myDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fooItem = await RetriveAsync(id);
            if (fooItem != null)
            {
                myDbContext.QuestionAnswers.Remove(fooItem);
                await myDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(int id, QuestionAnswer questionAnswer)
        {
            var fooItem = await RetriveAsync(id);
            if (fooItem != null)
            {
                fooItem.Answer = questionAnswer.Answer;
                fooItem.Closed = questionAnswer.Closed;
                fooItem.Course = questionAnswer.Course;
                fooItem.Created = questionAnswer.Created;
                fooItem.HasAnswer = questionAnswer.HasAnswer;
                fooItem.QuestionDescription = questionAnswer.QuestionDescription;
                fooItem.QuestionTitle = questionAnswer.QuestionTitle;
                await myDbContext.SaveChangesAsync();
            }
        }

    }
}
