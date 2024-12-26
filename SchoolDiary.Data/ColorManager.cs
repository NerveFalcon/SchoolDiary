using System.Globalization;
using System.Text;

namespace SchoolDiary;

public static class ColorManager
{
	public static string HexToRgba(string color)
	{
		if (!color.StartsWith('#')) return color;
		color = color.Substring(1);
		return color.Length switch
		{
			8 => Hex9ToRgba(color),
			6 => Hex6ToRgba(color),
			3 => Hex3ToRgba(color),
			_ => throw new ArgumentException("Invalid color code", nameof(color)),
		};
	}

	public static string HexToRgba(string color, string opacity)
	{
		if (!color.StartsWith('#')) return $"{color},{opacity}";
		color = color.Substring(1);
		
		return color.Length switch
		{
			8 => $"{Convert(color,3)},{opacity}",
			6 => $"{Convert(color,3)},{opacity}",
			_ => throw new ArgumentException("Invalid color code", nameof(color)),
		};
		
	}

	public static string RgbaToHex(string color)
	{
		if (color.StartsWith('#')) return color;
		var colors = color.Split(',').Select(s => decimal.Parse(s, CultureInfo.InvariantCulture)).ToArray();

		return colors.Length switch
		{
			4 => Convert((int)colors[0], (int)colors[1], (int)colors[2], (int)(colors[3] * 255)),
			3 => Convert((int)colors[0], (int)colors[1], (int)colors[2], 255),
			_ => throw new ArgumentException("Invalid color code", nameof(color)),
		};
	}

	private static string Convert(int r, int g, int b, int a)
	{
		var sb = new StringBuilder();
		sb.Append('#')
			.Append(r.ToString("X2"))
			.Append(g.ToString("X2"))
			.Append(b.ToString("X2"))
			.Append(a.ToString("X2"));

		return sb.ToString();
	}

	private static string Hex3ToRgba(string color)
	{
		var sb = new StringBuilder(6);
		foreach (var c in color)
		{
			sb.Append(c);
			sb.Append(c);
		}

		return Hex6ToRgba(sb.ToString());
	}

	private static string Hex6ToRgba(string color) => Convert(color, 3);
	private static string Hex9ToRgba(string color) => Convert(color, 4);

	private static string Convert(string color, int pairs)
	{
		var colors = new int[pairs];

		for (var i = 0; i < pairs; i++)
			colors[i] = int.Parse(color.Substring(i * 2, 2), NumberStyles.HexNumber);
		return string.Join(',', colors);
	}
}