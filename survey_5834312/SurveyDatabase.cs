using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace survey_5834312
{
    public class SurveyDatabase
    {
         readonly SQLiteAsyncConnection _database;

        public SurveyDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Survey>().Wait();
        }

        public Task<List<Survey>> GetSurveysAsync()
        {
            return _database.Table<Survey>().ToListAsync();
        }

        public Task<int> SaveSurveyAsync(Survey survey)
        {
            if (survey.Id != 0)
            {
                return _database.UpdateAsync(survey);
            }
            else
            {
                return _database.InsertAsync(survey);
            }
        }
    }
}
