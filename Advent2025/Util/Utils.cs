using System.Text.RegularExpressions;

public static class Utils
{
    public static int GrabInt(string input) => int.Parse(
        Regex.Match(input, @"\d+").Value);

    public static string GrabAlpha(string input) =>
        Regex.Match(input, @"[A-Za-z]*").Value;

    public static string Match(string input, string pattern) =>
        Regex.Match(input, pattern).Value;

}