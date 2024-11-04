using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=localhost,3306;Database=app;User=root;Password=test;");

    }
}
public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}