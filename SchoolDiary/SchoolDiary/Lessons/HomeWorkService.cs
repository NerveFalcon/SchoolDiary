using SchoolDiary.Lessons.Models;

namespace SchoolDiary.Lessons;

public class HomeWorkService
{
	public List<HomeWorkModel> HomeWorkModels { get; set; }

	public HomeWorkService()
	{
		var friday = new DateTime(2024, 12, 13);
		HomeWorkModels =
		[
			new(friday, SubjectModel.Nature, "Написать в тетради что такое облака"),
			new(friday, SubjectModel.Nature, "Нарисовать белочку"),
			new(friday, SubjectModel.Russian, "Выучить. Азбука часть 2, страница 14, задания 2 и 3"),
			new(friday, SubjectModel.Math, "Решить задания 1 и 3 на странице 32"),
		];
	}

	public List<HomeWorkModel> GetHomeWorks(int dayOfMonth)
	{
		var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dayOfMonth);
		return GetHomeWorks(date);
	}

	private List<HomeWorkModel> GetHomeWorks(DateTime date)
	{
		return HomeWorkModels.Where(w => w.Date == date).ToList();
	}
}