using System;

namespace ProjectMateTask.Services.AppInfrastructure;

static class RandomExtensions
{
    public static T NextItem<T>(this Random rnd, params T[] items) => items[rnd.Next(items.Length)];
}