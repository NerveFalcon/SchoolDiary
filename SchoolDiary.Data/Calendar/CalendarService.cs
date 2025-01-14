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

		var lessons = LessonService.GetSchedule();
		var homeWorks = HomeWorkService.GetMonth(DateTime.Today.Month);
		
		for (var i = 0; i < daysInMonth; i++)
		{
			var day = new DayModel(i + 1);
			day.Lessons = lessons[day.DayOfWeek].ToList();
			day.HomeWorks = homeWorks[day.Day].ToList();
			yield return day;
		}
	}
}