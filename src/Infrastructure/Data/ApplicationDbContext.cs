using System.Reflection;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;
using DnaBrasil.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<TipoLaudo> TipoLaudos => Set<TipoLaudo>();
    public DbSet<Serie> Series => Set<Serie>();
    public DbSet<Local> Locais => Set<Local>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
