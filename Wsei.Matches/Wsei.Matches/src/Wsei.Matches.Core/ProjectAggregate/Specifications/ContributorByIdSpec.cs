using Ardalis.Specification;
using Wsei.Matches.Core.ContributorAggregate;

namespace Wsei.Matches.Core.ProjectAggregate.Specifications;
public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  public ContributorByIdSpec(int contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
