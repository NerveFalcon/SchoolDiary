namespace SchoolDiary.Lessons.Models;

public class HomeWorkModel(DateTime date, SubjectModel subject, string title)
{
	public string Title { get; } = title;
	public SubjectModel Subject { get; } = subject;
	public DateTime Date { get; } = date;
}