using System.Threading.Tasks.Dataflow;
using Nest;
using DAL = VotingSystem.Domain.Entities;

namespace VotingSystem.Application.CandidateCategory.Queries;

public class CandidateCategoryService : ICandidateCategoryService
{
    private readonly IElasticClient _elasticClient;

    public CandidateCategoryService(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient ?? throw new ArgumentNullException();
    }

    public async Task<List<DAL.CandidateCategory>> GetCandidateCategory()
    {
        var response = await _elasticClient.SearchAsync<DAL.CandidateCategory>(s => s
                            .Query(q => q
                                .MatchAll()
                            )
                        );
        
        return response.Documents.ToList();
    }

    public async Task<List<DAL.CandidateCategory>> GetCandidateCategoryById(long Id)
    {
        var response = await _elasticClient.SearchAsync<DAL.CandidateCategory>(s => s
                            .Query(q => q
                                .Match(x=> x.Field(i => i.Id).Query(Id.ToString()))
                            )
                        );
        
        return response.Documents.ToList();
    }
}