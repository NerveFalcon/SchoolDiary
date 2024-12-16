#region

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolDiary.Data.Lessons.Models;

#endregion

namespace SchoolDiary.Data.Lessons;

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
			.ToLookup(hw=>hw.Date.Day);
}