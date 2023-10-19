using DnaBrasil.Application.TodoLists.Queries.GetTodos;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.FunctionalTests.Estados.Queries;

using static Testing;

public class GetEstadosAllTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnAllEstados()
    {
        await RunAsDefaultUserAsync();

        await AddAsync(new Estado()
        {
            Sigla = "DF",
            Nome = "Distrito Federal"
        });

        var query = new GetTodosQuery();

        var result = await SendAsync(query);

        result.Lists.Should().HaveCount(1);
    }

    //[Test]
    //public async Task ShouldDenyAnonymousUser()
    //{
    //    var query = new GetEstadosQuery();

    //    var action = () => SendAsync(query);

    //    await action.Should().ThrowAsync<UnauthorizedAccessException>();
    //}
}
