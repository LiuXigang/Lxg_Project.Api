using MySql.Data.MySqlClient;
using Dapper;
using System.Threading.Tasks;

namespace Project.API.Application.Queries
{
    public class ProjectQueries : IProjectQueries
    {
        private string _constr;
        public ProjectQueries(string constr) => _constr = constr;

        public async Task<dynamic> GetProjectDetail(int projectId, int userId)
        {
            using (var conn = new MySqlConnection(_constr))
            {
                conn.Open();
                var sql = @"SELECT projects.*,projectvisiblerules.* FROM projects 
                            INNER JOIN projectvisiblerules ON projects.Id = projectvisiblerules.ProjectId 
                            WHERE projects.id = @projectId AND projects.userId = @userId";
                var result = await conn.QueryAsync<dynamic>(sql, new { projectId, userId });
                return result;
            }
        }

        public async Task<dynamic> GetProjectsByUserId(int userId)
        {
            using (var conn = new MySqlConnection(_constr))
            {
                conn.Open();
                var sql = "SELECT * FROM projects WHERE userId = @userId ";
                var result = await conn.QueryAsync<dynamic>(sql, new { userId });
                return result;
            }
        }
    }
}
