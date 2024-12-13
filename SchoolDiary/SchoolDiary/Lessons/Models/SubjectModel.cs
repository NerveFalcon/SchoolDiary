namespace SchoolDiary.Lessons.Models;

public class SubjectModel
{
	public string Title { get; set; }
	public string Color { get; set; }

	public static SubjectModel Russian;
	public static SubjectModel Math;
	public static SubjectModel Nature;

	static SubjectModel()
	{
		Russian = new()
		{
			Title = "Russian",
			Color = "#dc3545",
		};
		Math = new()
		{
			Title = "Math",
			Color = "#0d6efd",
		};
		Nature = new()
		{
			Title = "Nature",
			Color = "#198754",
		};
	}
}