using Ardalis.GuardClauses;
using Wsei.Matches.SharedKernel;
using Wsei.Matches.SharedKernel.Interfaces;

namespace Wsei.Matches.Core.ContributorAggregate;

public class Contributor : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }

  public Contributor(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
