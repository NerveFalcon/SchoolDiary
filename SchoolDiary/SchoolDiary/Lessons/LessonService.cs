using SchoolDiary.Lessons.Models;

namespace SchoolDiary.Lessons;

public class LessonService
{
	ILookup<DayOfWeek, LessonModel> Shedule { get; set; }
	List<LessonModel> Lessons { get; set; }
	public LessonService()
	{
		Lessons = [
			new LessonModel()
			{
				DayOfWeek = DayOfWeek.Monday,
				Serial = 1,
				Subject = SubjectModel.Math,
			},
			new LessonModel()
			{
				DayOfWeek = DayOfWeek.Monday,
				Serial = 2,
				Subject = SubjectModel.Russian,
			},
			new LessonModel()
			{
				DayOfWeek = DayOfWeek.Monday,
				Serial = 3,
				Subject = SubjectModel.Nature,
			},
			new LessonModel()
			{
				DayOfWeek = DayOfWeek.Tuesday,
				Serial = 1,
				Subject = SubjectModel.Russian,
			},
			new LessonModel()
			{
				DayOfWeek = DayOfWeek.Tuesday,
				Serial = 2,
				Subject = SubjectModel.Nature,
			},
			new LessonModel()
			{
				DayOfWeek = DayOfWeek.Wednesday,
				Serial = 1,
				Subject = SubjectModel.Nature,
			},
			new LessonModel()
			{
				DayOfWeek = DayOfWeek.Wednesday,
				Serial = 2,
				Subject = SubjectModel.Math,
			},
			new LessonModel()
			{
				DayOfWeek = DayOfWeek.Thursday,
				Serial = 1,
				Subject = SubjectModel.Russian,
			},
			new LessonModel()
			{
				DayOfWeek = DayOfWeek.Thursday,
				Serial = 1,
				Subject = SubjectModel.Math,
			},
			new LessonModel()
			{
				DayOfWeek = DayOfWeek.Thursday,
				Serial = 3,
				Subject = SubjectModel.Nature,
			},
			new LessonModel()
			{
				DayOfWeek = DayOfWeek.Friday,
				Serial = 1,
				Subject = SubjectModel.Nature,
			},
		];
		
		Shedule = Lessons.ToLookup(l => l.DayOfWeek, l => l);
	}

	public IEnumerable<LessonModel> GetLessons(DayOfWeek dayOfWeek) => Shedule[dayOfWeek];
}