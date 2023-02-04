using System.Text.RegularExpressions;

namespace SimpleSRM.Extensions.Services;

/// <summary>
///     Сервис обработки string значений
/// </summary>
public static class StringExtensions
{
    public static string RemoveDuplicate(ref string value,string removedValue) => Regex.Replace(value, @" {2,}", removedValue);
   
}