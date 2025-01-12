using SchoolDiary.Lessons.Models;

namespace SchoolDiary.Calendar.Models;

public class DayModel(int dayOfMonth)
{
	private readonly DateTime _date = new(DateTime.Today.Year, DateTime.Today.Month, dayOfMonth);

	public DayOfWeek DayOfWeek => _date.DayOfWeek;
	public int Day => _date.Day;
	public int Month => _date.Month;
	public int Year => _date.Year;
	public int DayOfYear => _date.DayOfYear;
	public List<LessonModel> Lessons { get; set; } = [];
	public List<HomeWorkModel> HomeWorks { get; set; } = [];

	public int? HomeWorksCount(SubjectModel subject)
	{
		var count = HomeWorks.Count(w => w.Subject == subject);
		return count == 0 ? null : count;
	}
	
	public DateTime GetDate() => _date;
}