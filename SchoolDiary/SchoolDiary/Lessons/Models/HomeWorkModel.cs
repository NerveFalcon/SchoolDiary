namespace SchoolDiary.Lessons.Models;

public class HomeWorkModel
{
	public string Title { get; set; }
	public string Description { get; set; }
	public SubjectModel Subject { get; set; }
	public DateTime Date { get; set; }
}