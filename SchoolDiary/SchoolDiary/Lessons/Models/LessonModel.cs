namespace SchoolDiary.Lessons.Models;

public class LessonModel
{
	public LessonModel()
	{
		
	}
	public LessonModel(DayOfWeek dayOfWeek, int serial, SubjectModel subject)
	{
		Subject = subject;
		DayOfWeek = dayOfWeek;
		Serial = serial;
	}

	public SubjectModel Subject { get; }
	public DayOfWeek DayOfWeek { get; }
	public int Serial { get; }
}