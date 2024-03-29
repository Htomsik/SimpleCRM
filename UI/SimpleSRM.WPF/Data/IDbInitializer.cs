﻿using System.Threading.Tasks;

namespace SimpleSRM.WPF.Data;

/// <summary>
///   Интефейс инициализации бд
/// </summary>
internal interface IDbInitializer
{
      /// <summary>
      /// Инициализация тестовых данных
      /// </summary>
      Task InitializeTestDataAsync();
      /// <summary>
      /// Пересборка бд
      /// </summary>
      Task RebuildDataBaseAsync();
      /// <summary>
      /// Инициализация бд
      /// </summary>
      Task InitializeAsync();
}