using System.Threading.Tasks.Dataflow;
using Nest;
using DAL = VotingSystem.Domain.Entities;

namespace VotingSystem.Application.VoteCast.Queries;

public class VoteCastService : IVoteCastService
{
    private readonly IElasticClient _elasticClient;

    public VoteCastService(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient ?? throw new ArgumentNullException();
    }

    public async Task<List<DAL.VoteCast>> GetVotesByCanidate(long candidateID)
    {
         var response = await _elasticClient.SearchAsync<DAL.VoteCast>(s => s
                            .Query(q => q
                                .Match(x=> x.Field(i => i.CandidateId).Query(candidateID.ToString()))
                            )
                        );
        return response.Documents.ToList();
    }   
}