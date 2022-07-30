using System.Threading.Tasks;

namespace ProjectMateTask.Data;

internal interface IDbInitializer
{
      Task InitializeTestDataAsync();
      Task RebuildDataBaseAsync();
      Task InitializeAsync();
}