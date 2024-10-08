using Microsoft.EntityFrameworkCore;
using todo.models;

namespace todos.data
{

    public class TodosDbContext(DbContextOptions<TodosDbContext> options) : DbContext(options)
    {

        public DbSet<TodoItem> Todos { get; set; }
    }
}