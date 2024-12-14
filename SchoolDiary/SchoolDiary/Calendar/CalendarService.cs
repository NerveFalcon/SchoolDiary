using SchoolDiary.Calendar.Models;
using SchoolDiary.Lessons;

namespace SchoolDiary.Calendar;

public class CalendarService(LessonService lessonService, HomeWorkService homeWorkService)
{
	private LessonService LessonService { get; } = lessonService;
	private HomeWorkService HomeWorkService { get; } = homeWorkService;

	public IEnumerable<DayModel> GetCurrent()
	{
		var daysInMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);

		for (var i = 0; i < daysInMonth; i++)
		{
			var day = new DayModel(i + 1);
			day.Lessons = LessonService.GetLessons(day.InternalDayOfWeek).ToList();
			day.HomeWorks = HomeWorkService.GetHomeWorks(day.Day);
			yield return day;
		}
	}
}