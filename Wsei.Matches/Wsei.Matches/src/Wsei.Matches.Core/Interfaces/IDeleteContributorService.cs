using Ardalis.Result;

namespace Wsei.Matches.Core.Interfaces;
public interface IDeleteContributorService
{
  public Task<Result> DeleteContributor(int contributorId);
}
