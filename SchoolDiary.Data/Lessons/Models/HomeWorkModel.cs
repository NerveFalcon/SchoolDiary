namespace SchoolDiary.Data.Lessons.Models;

public class HomeWorkModel(DateTime date, SubjectModel subject, string exercise)
{
	public string Exercise { get; } = exercise;
	public SubjectModel Subject { get; } = subject;
	public DateTime Date { get; } = date;
}