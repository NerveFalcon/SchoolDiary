using System.ComponentModel.DataAnnotations;

namespace SchoolDiary.Lessons.Data;

public class HomeWork
{
#pragma warning disable CS8618, CS9264
	public HomeWork()
	{
	}
#pragma warning restore CS8618, CS9264

	public HomeWork(DateTime date, Subject subject, string exercise)
	{
		Id = Guid.NewGuid();
		Date = date;
		Subject = subject;
		Exercise = exercise;
	}

	[Key]
	public Guid Id { get; set; }
	public DateTime Date { get; set; }
	public Subject Subject { get; set; }
	public string Exercise { get; set; }
}