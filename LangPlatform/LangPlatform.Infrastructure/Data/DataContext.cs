using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Topic> Topics { get; set; } = null!;
    public DbSet<Test> Tests { get; set; } = null!;
    public DbSet<Section> Sections { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Media> Medias { get; set; } = null!;
    public DbSet<Lesson> Lessons { get; set; } = null!;
    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Article> Articles { get; set; } = null!;
    public DbSet<Answer> Answers { get; set; } = null!;
    
    public DataContext(DbContextOptions options):base(options)
    {}
}