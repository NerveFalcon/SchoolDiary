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
		CreateProjection<HomeWork, HomeWorkModel>();
	}
	
}