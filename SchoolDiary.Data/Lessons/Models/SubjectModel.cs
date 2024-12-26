namespace SchoolDiary.Lessons.Models;

public class SubjectModel(string title, string color)
{
	public string Title { get; } = title;
	/// <summary>
	/// Color in format <c>R,G,B,A</c>
	/// </summary>
	public string Color { get; } = color;

	public static bool operator ==(SubjectModel first, SubjectModel second ) => first.Title == second.Title;
	public static bool operator !=(SubjectModel first, SubjectModel second) => !(first == second);
	
	protected bool Equals(SubjectModel other)
	{
		return Title == other.Title;
	}

	public override bool Equals(object? obj)
	{
		if (obj is null) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
		return Equals((SubjectModel)obj);
	}

	public override int GetHashCode() => Title.GetHashCode();
}