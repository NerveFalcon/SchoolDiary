namespace SchoolDiary.Lessons.Data;

public class Lesson
{
#pragma warning disable CS8618, CS9264
	public Lesson()
	{
	}
#pragma warning restore CS8618, CS9264

	public Lesson(DayOfWeek dayOfWeek, int serial, Subject subject)
	{
		DayOfWeek = dayOfWeek;
		Serial = serial;
		Subject = subject;
	}

	public DayOfWeek DayOfWeek { get; set; }
	public int Serial { get; set; }
	public Subject Subject { get; set; }

	public void IncreaseSerial() => Serial++;
	public void DecreaseSerial() => Serial--;
}