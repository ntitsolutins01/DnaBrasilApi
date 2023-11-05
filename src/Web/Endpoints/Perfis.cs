using System.Collections;
using System.Security.Claims;
using DnaBrasil.Web.Dto;
using DnaBrasil.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DnaBrasil.Web.Endpoints;

public class Perfis : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetPerfisAll)
            .MapPost(CreatePerfil);
    }

    public Task<List<PerfilDto>> GetPerfisAll(ISender sender, [FromBody] PerfilCommand command)
    {
        try
        {
            var list = command.DbContext.Roles.Select(s => s).ToList().Select(item => new PerfilDto { Nome = item.Name, Id = item.Id }).ToList();
            return Task.FromResult(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<int> CreatePerfil(ISender sender, PerfilCommand command)
    {
        try
        {
            var adminRole = await command.RoleManager.FindByNameAsync(command.Nome);
            var result = false;
            if (adminRole == null)
            {
                adminRole = new IdentityRole(command.Nome);
                await command.RoleManager.CreateAsync(adminRole);
                foreach (DictionaryEntry claim in command.Claims)
                {
                    var addClaim = new Claim(claim.Key.ToString()!, claim.Value!.ToString()!);
                    await command.RoleManager.AddClaimAsync(adminRole, addClaim);
                }

                result = true;
            }

            return result ? 1 : 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
