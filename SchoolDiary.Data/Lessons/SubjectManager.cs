using System.Globalization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SchoolDiary.Data.Lessons.Data;
using SchoolDiary.Data.Lessons.Models;

namespace SchoolDiary.Data.Lessons;

public class SubjectManager(ApplicationDbContext db, IMapper mapper)
{
	public List<SubjectModel> GetSubjects() =>
		db.Subjects.ProjectTo<SubjectModel>(mapper.ConfigurationProvider).ToList();

	public bool AddSubject(SubjectModel model)
	{
		if (db.Subjects.Any(s => s.Title == model.Title))
			return false;

		var subject = new Subject(model.Title, ValidateColor(model.Color));
		db.Add(subject);

		var res = db.SaveChanges();
		return res > 0;
	}

	public bool EditSubjectColor(SubjectModel model, string newColor)
	{
		var subject = db.Subjects.SingleOrDefault(s => s.Title == model.Title);
		if (subject == null) return false;

		subject.Color = ValidateColor(newColor);
		var res = db.SaveChanges();

		return res > 0;
	}

	public bool EditSubjectTitle(SubjectModel model, string newTitle)
	{
		var subject = db.Subjects.SingleOrDefault(s => s.Title == model.Title);
		if (subject == null) return false;

		subject.Title = newTitle;
		var res = db.SaveChanges();

		return res > 0;
	}


	public bool RemoveSubject(SubjectModel model)
	{
		var transaction = db.Database.BeginTransaction();
		
		var subject = db.Subjects.SingleOrDefault(s => s.Title == model.Title);
		if (subject == null) return false;

		RemoveLessons(subject);
		db.Subjects.Remove(subject);

		var res = db.SaveChanges();
		transaction.Commit();
		
		return res > 0;
	}

	private void RemoveLessons(Subject subject)
	{
		var removable = db.Lessons.Where(l => l.Subject == subject).ToList();
		var days = db.Lessons.Where(l => removable.Select(lesson => lesson.DayOfWeek).Distinct().Contains(l.DayOfWeek))
			.OrderBy(l => new { l.DayOfWeek, l.Serial })
			.ToLookup(l => l.DayOfWeek);

		foreach (var day in days)
		{
			var remaining = day.Where(l => l.Subject != subject).OrderBy(l => l.Serial).ToList();
			for (var i = 0; i < remaining.Count; i++)
				remaining[i].Serial = i;
		}
	}

	private static string ValidateColor(string color)
	{
		if (!color.StartsWith('#')) return color;

		if (color.Length != 9)
			throw new ArgumentException("Invalid color code");

		var colorCode = color.Substring(1);
		var colors = new int[4];

		for (var i = 0; i < 4; i++)
			colors[i] = int.Parse(colorCode.Substring(i * 2, 2), NumberStyles.HexNumber);

		return string.Join(',', colors);
	}
}