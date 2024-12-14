namespace SchoolDiary.Lessons.Models;

public class HomeWorkModel(DateTime date, SubjectModel subject, string title)
{
	public string Title { get; set; } = title;
	public SubjectModel Subject { get; set; } = subject;
	public DateTime Date { get; set; } = date;
}