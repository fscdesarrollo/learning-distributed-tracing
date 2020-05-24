using Refit;
using System.Threading.Tasks;

namespace Learning.DistributedTracing.Star.Api.Clients.War
{
    public interface IWarsAPI
    {
        [Get("/wars")]
        Task<WarsResponse> GetWars([AliasAs("emitError")]bool emitError);
    }
}
