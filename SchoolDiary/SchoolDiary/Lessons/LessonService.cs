using SchoolDiary.Lessons.Models;

namespace SchoolDiary.Lessons;

public class LessonService
{
	ILookup<DayOfWeek, LessonModel> Shedule { get; set; }
	List<LessonModel> Lessons { get; set; }

	public LessonService()
	{
		Lessons =
		[
			new(DayOfWeek.Monday, 1, SubjectModel.Math),
			new(DayOfWeek.Monday, 2, SubjectModel.Russian),
			new(DayOfWeek.Monday, 3, SubjectModel.Nature),
			new(DayOfWeek.Tuesday, 1, SubjectModel.Russian),
			new(DayOfWeek.Tuesday, 2, SubjectModel.Nature),
			new(DayOfWeek.Wednesday, 1, SubjectModel.Math),
			new(DayOfWeek.Thursday, 1, SubjectModel.Russian),
			new(DayOfWeek.Thursday, 1, SubjectModel.Math),
			new(DayOfWeek.Thursday, 3, SubjectModel.Nature),
			new(DayOfWeek.Friday, 1, SubjectModel.Nature),
		];

		Shedule = Lessons.ToLookup(l => l.DayOfWeek, l => l);
	}

	public IEnumerable<LessonModel> GetLessons(DayOfWeek dayOfWeek) => Shedule[dayOfWeek];
}