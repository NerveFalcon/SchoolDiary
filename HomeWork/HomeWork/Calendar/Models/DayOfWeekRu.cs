using System.ComponentModel;

namespace HomeWork.Calendar;

public enum DayOfWeekRu
{
	/// <summary>Indicates Monday.</summary>
	[Description("ПН")] Monday = 1,

	/// <summary>Indicates Tuesday.</summary>
	[Description("ВТ")] Tuesday,

	/// <summary>Indicates Wednesday.</summary>
	[Description("СР")] Wednesday,

	/// <summary>Indicates Thursday.</summary>
	[Description("ЧТ")] Thursday,

	/// <summary>Indicates Friday.</summary>
	[Description("ПТ")] Friday,

	/// <summary>Indicates Saturday.</summary>
	[Description("СБ")] Saturday,

	/// <summary>Indicates Sunday.</summary>
	[Description("ВС")] Sunday,
}