namespace Microservice.Core.Packages.ElasticSearch.Models;

public interface IElasticSearchResult
{
    bool Success { get; }
    string Message { get; }
}
