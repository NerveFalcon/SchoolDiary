using AutoMapper;
using SchoolDiary.Data.Lessons.Data;
using SchoolDiary.Data.Lessons.Models;

namespace SchoolDiary.Data.Lessons;

public class LessonProfile : Profile
{
	public LessonProfile()
	{
		CreateProjection<Subject, SubjectModel>();
		CreateProjection<Lesson, LessonModel>();
		CreateProjection<HomeWork, HomeWorkModel>();
	}
}