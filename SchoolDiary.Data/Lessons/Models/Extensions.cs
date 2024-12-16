using SchoolDiary.Data.Lessons.Data;

namespace SchoolDiary.Data.Lessons.Models;

public static class Extensions
{
	public static IOrderedQueryable<Lesson> WhereDay(this IQueryable<Lesson> lessons, DayOfWeek dayOfWeek) =>
		lessons.Where(l => l.DayOfWeek == dayOfWeek).OrderBy(l => l.Serial);
	
	public static Lesson? SingleOrDefault(this IQueryable<Lesson> lessons, DayOfWeek dayOfWeek, int serial) =>
		lessons.SingleOrDefault(l=>l.DayOfWeek == dayOfWeek && l.Serial == serial);
}