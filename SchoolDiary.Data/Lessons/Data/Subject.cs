using System.ComponentModel.DataAnnotations;

namespace SchoolDiary.Data.Lessons.Data;

public class Subject
{
#pragma warning disable CS8618, CS9264
	public Subject()
	{
		
	}
#pragma warning restore CS8618, CS9264

	public Subject(string title, string color)
	{
		Title = title;
		Color = color;
	}

	[Key]
	public string Title { get; set; }
	public string Color { get; set; }
}