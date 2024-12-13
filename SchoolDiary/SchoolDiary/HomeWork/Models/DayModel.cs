using SchoolDiary.Lessons.Models;

namespace SchoolDiary.HomeWork.Models;

public class DayModel(int dayOfMonth)
{
	private readonly DateTime _date = new(DateTime.Today.Year, DateTime.Today.Month, dayOfMonth);

	public DayOfWeekRu DayOfWeek => Translate(_date.DayOfWeek);
	internal DayOfWeek InternalDayOfWeek => _date.DayOfWeek;
	public int Day => _date.Day;
	public int Month => _date.Month;
	public int Year => _date.Year;
	public int DayOfYear => _date.DayOfYear;
	public List<LessonModel> Lessons { get; set; } = [];
	public List<HomeWorkModel> HomeWorks { get; set; } = [];

	private static DayOfWeekRu Translate(DayOfWeek dayOfWeek)
	{
		if (dayOfWeek is System.DayOfWeek.Sunday) return DayOfWeekRu.Sunday;

		return (DayOfWeekRu)dayOfWeek;
	}

	public int? HomeWorksCount(LessonModel lesson)
	{
		var count = HomeWorks.Count(w => w.Subject == lesson.Subject);
		return count == 0 ? null : count;
	}
}