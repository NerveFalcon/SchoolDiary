using System.ComponentModel.DataAnnotations;

namespace SchoolDiary.Lessons.Data;

public class Subject
{
	public Subject()
	{
		
	}
	public Subject(string title, string color)
	{
		Title = title;
		Color = color;
	}

	[Key]
	public string Title { get; set; }
	public string Color { get; set; }
}