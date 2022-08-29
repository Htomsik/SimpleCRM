namespace ProjectMateTaskDalTests.Resources;

internal static class GlobalResources
{
    #region Initializer : тестовые Entity данные

    private static EntitiesTestDataInitializer? _initializer;

    public static EntitiesTestDataInitializer Initializer => _initializer ??= new EntitiesTestDataInitializer();

    #endregion


}