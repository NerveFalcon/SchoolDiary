using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SchoolDiary.Data;
using SchoolDiary.Lessons.Data;
using SchoolDiary.Lessons.Models;

namespace SchoolDiary.Lessons;

public class LessonService(ApplicationDbContext db, IMapper mapper, ILogger<LessonService> logger)
{
	public IEnumerable<LessonModel> GetLessons(DayOfWeek dayOfWeek) =>
		db.Lessons.WhereDay(dayOfWeek)
			.ProjectTo<LessonModel>(mapper.ConfigurationProvider).ToList();

	public bool AddLesson(LessonModel model)
	{
		var lesson = db.Lessons.SingleOrDefault(model.DayOfWeek, model.Serial);
		if (lesson != null) return false;

		var subject = db.Subjects.SingleOrDefault(s => s.Title == model.Subject.Title);
		if (subject == null) return false;

		lesson = new(model.DayOfWeek, model.Serial, subject);
		db.Lessons.Add(lesson);
		var res = db.SaveChanges();

		return res > 0;
	}

	public bool RemoveLesson(LessonModel model)
	{
		var lesson = db.Lessons.Include(l => l.Subject)
			.SingleOrDefault(model.DayOfWeek, model.Serial);
		if (lesson == null || lesson.Subject.Title != model.Subject.Title) return false;

		var day = db.Lessons.WhereDay(model.DayOfWeek).ToList();
		foreach (var less in day.SkipWhile(l => l.Serial < lesson.Serial)) less.IncreaseSerial();

		db.Lessons.Remove(lesson);
		var res = db.SaveChanges();

		return res > 0;
	}

	public bool ChangeSubject(LessonModel model, Subject subject)
	{
		var lesson = db.Lessons.SingleOrDefault(model.DayOfWeek, model.Serial);
		if (lesson == null) return false;

		var subjects = db.Subjects.SingleOrDefault(s => s.Title == subject.Title);
		if (subjects == null) return false;

		lesson.Subject = subjects;
		var res = db.SaveChanges();

		return res > 0;
	}
}