namespace SchoolDiary.Lessons.Models;

public class LessonModel
{
	public SubjectModel Subject { get; set; }
	public DayOfWeek DayOfWeek { get; set; }
	public int Serial { get; set; }
}