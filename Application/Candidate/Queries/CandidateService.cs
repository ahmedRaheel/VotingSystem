using System.Threading.Tasks.Dataflow;
using Nest;
using DAL = VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Candidate.Queries;

public class CandidateService : ICandidateService
{
    private readonly IElasticClient _elasticClient;

    public CandidateService(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient ?? throw new ArgumentNullException();
    }

    public async Task<List<DAL.Candidate>> GetCandidates()
    {
        var response = await _elasticClient.SearchAsync<DAL.Candidate>(s => s
                            .Query(q => q
                                .MatchAll()
                            )
                        );
        
        return response.Documents.ToList();
    }

    public async Task<List<DAL.Candidate>> GetCandidateById(long Id)
    {
        var response = await _elasticClient.SearchAsync<DAL.Candidate>(s => s
                            .Query(q => q
                                .Match(x=> x.Field(i => i.Id).Query(Id.ToString()))
                            )
                        );
        
        return response.Documents.ToList();
    }
}