namespace SchoolDiary.Lessons.Models;

public class SubjectModel(string title, string color)
{
	public string Title { get; } = title;
	public string Color { get; } = color;
	public string BgColor => $"{Color}3b";
}