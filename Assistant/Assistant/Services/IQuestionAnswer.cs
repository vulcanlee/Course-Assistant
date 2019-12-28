using Assistant.DataModels;
using Assistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public interface IQuestionAnswerService 
    {
        Task CreateAsync(QuestionAnswer courseUser);
        Task DeleteAsync(int id);
        Task<List<QuestionAnswer>> RetriveAsync(Course course);
        Task UpdateAsync(int id, QuestionAnswer courseUser);
        Task<PagedResult<QuestionAnswer>> GetPagedAsync(Course course,int page, int pageSize);
    }
}
