using Ardalis.HttpClientTestExtensions;
using Wsei.Matches.Web;
using Wsei.Matches.Web.Endpoints.ProjectEndpoints;
using Xunit;

namespace Wsei.Matches.FunctionalTests.ApiEndpoints;
[Collection("Sequential")]
public class ProjectList : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  public ProjectList(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsOneProject()
  {
    var result = await _client.GetAndDeserializeAsync<ProjectListResponse>("/Projects");

    Assert.Single(result.Projects);
    Assert.Contains(result.Projects, i => i.Name == SeedData.TestProject1.Name);
  }
}
