namespace ProjectMateTaskExtensions.Services;

/// <summary>
///     Сервис работающий с random
/// </summary>
public static class RandomExtensions
{
    /// <summary>
    ///     Выборка рандомного элемента из массива
    /// </summary>
    /// <param name="rnd">Random Type</param>
    /// <param name="items">Массив элементов для выборки</param>
    /// <typeparam name="T">Любой тип</typeparam>
    /// <returns></returns>
    public static T NextItem<T>(this Random rnd, params T[] items) => items[rnd.Next(items.Length)];
}