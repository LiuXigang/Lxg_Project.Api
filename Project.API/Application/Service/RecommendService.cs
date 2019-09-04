using System.Threading.Tasks;

namespace Project.API.Application.Service
{
    public class RecommendService : IRecommendService
    {
        public Task<bool> IsProjectRecommend(int projectId, int userId)
        {
            return Task.FromResult(true);
        }
    }
}
