namespace SchoolDiary.Lessons.Models;

public class LessonModel(DayOfWeek dayOfWeek, int serial, SubjectModel subject)
{
	public SubjectModel Subject { get; } = subject;
	public DayOfWeek DayOfWeek { get; } = dayOfWeek;
	public int Serial { get; } = serial;
}