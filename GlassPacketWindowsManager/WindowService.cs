using System.Text.RegularExpressions;

namespace GlassPacketWindowsManager;

public static class WindowService
{
    public static int GetSegmentsCount(string articleNumber)
    {
        var articleParts = articleNumber.Split("/");

        return articleParts.Length switch
        {
            1 => 0,
            3 => 1,
            5 => 2,
            _ => throw new InvalidOperationException("Не верный формат артикула."),
        };
    }

    public static int GetWindowThickness(string articleNumber)
    {
        var windowParts = articleNumber.Split("/");
        var windowPartsThickess = windowParts.Select(GetFirstNumbers).Select(int.Parse).ToList();

        return windowPartsThickess.Sum();
    }

    public static int GetGlassThickness(string articleNumber)
    {
        var articleParts = articleNumber.Split("/");

        return articleParts.Length switch
        {
            1 => int.Parse(GetFirstNumbers(articleParts.ElementAt(0))),
            3 => GetSingleSegmentGlassThickness(articleParts),
            5 => GetDoubleSegmentGlassThickness(articleParts),
            _ => throw new InvalidOperationException("Не верный формат артикула."),
        };
    }

    private static int GetDoubleSegmentGlassThickness(IEnumerable<string> windowParts)
    {
        var windowPartsThickess = windowParts.Select(GetFirstNumbers).Select(int.Parse).ToList();
        return windowPartsThickess[0] + windowPartsThickess[2] + windowPartsThickess[4];
    }

    private static int GetSingleSegmentGlassThickness(IEnumerable<string> windowParts)
    {
        return int.Parse(GetFirstNumbers(windowParts.ElementAt(0))) + int.Parse(GetFirstNumbers(windowParts.ElementAt(2)));
    }

    private static string GetFirstNumbers(string str) => Regex.Match(str, @"\d+").Value;
}

