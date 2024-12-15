using AutoMapper;
using SchoolDiary.Lessons.Data;
using SchoolDiary.Lessons.Models;

namespace SchoolDiary.Lessons;

public class LessonProfile : Profile
{
	public LessonProfile()
	{
		CreateProjection<Subject, SubjectModel>();
		CreateProjection<Lesson, LessonModel>();
		CreateProjection<HomeWork, HomeWorkModel>()
			.ForMember(m => m.Date, opt => opt.MapFrom(hw => hw.Date))
			.ForMember(m => m.Subject, opt => opt.MapFrom(hw => hw.Subject))
			.ForMember(m => m.Title, opt => opt.MapFrom(hw => hw.Exercise));
	}
}