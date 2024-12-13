namespace HomeWork.Calendar.Models;

public class DayModel(int dayOfMonth)
{
	private readonly DateTime _date = new(DateTime.Today.Year, DateTime.Today.Month, dayOfMonth);

	public DayOfWeekRu DayOfWeek => Translate(_date.DayOfWeek);
	public int Day => _date.Day;
	public int Month => _date.Month;
	public int Year => _date.Year;
	public int DayOfYear => _date.DayOfYear;
	public List<Work> Works { get; set; } = [];

	private static DayOfWeekRu Translate(DayOfWeek dayOfWeek)
	{
		if (dayOfWeek is System.DayOfWeek.Sunday) return DayOfWeekRu.Sunday;

		return (DayOfWeekRu)dayOfWeek;
	}
}

public class Work
{
	public string Title { get; set; }
	public string Color { get; set; }
}
