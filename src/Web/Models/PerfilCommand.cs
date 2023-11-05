using System.Collections.Specialized;
using DnaBrasil.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace DnaBrasil.Web.Models;

public class PerfilCommand
{
    public required ApplicationDbContext DbContext { get; set; }
    public required RoleManager<IdentityRole> RoleManager { get; set; }
    public required string Nome { get; set; }
    public required ListDictionary Claims { get; set; }
}
