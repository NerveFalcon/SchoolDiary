namespace SchoolDiary.Lessons.Models;

public class HomeWorkModel
{
	public HomeWorkModel()
	{
		
	}
	public HomeWorkModel(DateTime date, SubjectModel subject, string title)
	{
		Title = title;
		Subject = subject;
		Date = date;
	}

	public string Title { get; }
	public SubjectModel Subject { get; }
	public DateTime Date { get; }
}