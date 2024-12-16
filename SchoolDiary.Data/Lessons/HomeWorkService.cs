#region

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolDiary.Data;
using SchoolDiary.Lessons.Data;
using SchoolDiary.Lessons.Models;

#endregion

namespace SchoolDiary.Lessons;

public class HomeWorkService(ApplicationDbContext db, IMapper mapper, ILogger<HomeWorkService> logger)
{
	private readonly ILogger<HomeWorkService> _logger = logger;


	public List<HomeWorkModel> GetHomeWorks(int dayOfMonth)
	{
		var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dayOfMonth);
		return GetHomeWorks(date);
	}

	private List<HomeWorkModel> GetHomeWorks(DateTime date) =>
		db.HomeWorks
			.Include(hw => hw.Subject)
			.Where(w => w.Date == date)
			.ProjectTo<HomeWorkModel>(mapper.ConfigurationProvider)
			.ToList();

	public ILookup<int, HomeWorkModel> GetMonth(int month)
		=> db.HomeWorks
			.Include(hw => hw.Subject)
			.Where(hw => hw.Date.Month == month)
			.ProjectTo<HomeWorkModel>(mapper.ConfigurationProvider)
			.ToLookup(hw => hw.Date.Day);

	public bool AddNewHomeWork(HomeWorkModel homeWork)
	{
		if (string.IsNullOrWhiteSpace(homeWork.Exercise)) return false;

		var subject = db.Subjects.SingleOrDefault(s => s.Title == homeWork.Subject.Title);
		if (subject == null) return false;

		var hw = db.HomeWorks.FirstOrDefault(hw =>
			hw.Date == homeWork.Date && hw.Subject == subject && hw.Exercise == homeWork.Exercise);
		if (hw != null) return false;
		
		hw = new(homeWork.Date, subject, homeWork.Exercise);
		db.HomeWorks.Add(hw);
		var res = db.SaveChanges();

		return res > 0;
	}

	public bool Remove(HomeWorkModel work)
	{
		var hw = db.HomeWorks.FirstOrDefault(hw =>
			hw.Date == work.Date && hw.Subject.Title == work.Subject.Title && hw.Exercise == work.Exercise);
		if (hw == null) return false;

		db.HomeWorks.Remove(hw);
		var res = db.SaveChanges();

		return res > 0;
	}
}