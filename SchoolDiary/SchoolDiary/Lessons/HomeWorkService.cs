#region

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SchoolDiary.Data;
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

	private List<HomeWorkModel> GetHomeWorks(DateTime date)
	{
		return db.HomeWorks
			.Include(hw => hw.Subject)
			.Where(w => w.Date == date)
			.ProjectTo<HomeWorkModel>(mapper.ConfigurationProvider)
			.ToList();
	}
}