namespace SchoolDiary.Lessons.Models;

public class SubjectModel(string title, string color)
{
	public string Title { get; } = title;
	public string Color { get; } = color;
	public string BgColor => $"{Color}3b";

	public static readonly SubjectModel Russian = new("Русский язык", "#dc3545");
	public static readonly SubjectModel Math = new("Математика", "#0d6efd");
	public static readonly SubjectModel Nature = new("Окружающий мир", "#198754");
}