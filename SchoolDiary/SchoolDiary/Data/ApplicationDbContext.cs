using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolDiary.Lessons.Data;

namespace SchoolDiary.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
	: IdentityDbContext<ApplicationUser>(options)
{
	public DbSet<Subject> Subjects { get; set; }
	public DbSet<Lesson> Lessons { get; set; }
	public DbSet<HomeWork> HomeWorks { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		
		builder.Entity<Lesson>().HasKey(l => new {l.DayOfWeek, l.Serial});
	}
}