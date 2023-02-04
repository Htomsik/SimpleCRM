using System.Windows.Input;
using ProjectMateTask.Infrastructure.CMD;
using ProjectMateTaskWpfTests.InfrastructureTests.CommandTests.Base;

namespace ProjectMateTaskWpfTests.InfrastructureTests.CommandTests;

[TestClass]
public class LambdaCmdTests : BaseCmdTests<LambdaCmd>
{
    #region GenerateCommand : Генераторы команд

    protected override LambdaCmd GenerateCommand(Action<object> action, Func<object, bool> func) =>
        new (action, func);
    
    protected override LambdaCmd GenerateCommand(Action action, Func<bool> func) => new (action, func);
    
    protected override LambdaCmd GenerateCommand() => new(() => {});

    #endregion
    
    
    /// <summary>
    ///     Проверяет изменяется ли canExecute при изменении параметров
    /// </summary>
    [TestMethod]
    public void IsCanExecuteUpdateWhenCanExecuteChangeTest()
    {
        //Arrange
        bool canExecute = true;
        
        LambdaCmd someCommandWithoutObj = new LambdaCmd(()=>{},()=>canExecute);
        
        ICommand someAbstractCommand = someCommandWithoutObj;
        
        //Act+Assert
        Assert.IsTrue(someAbstractCommand.CanExecute(null));
        
        canExecute = false;
        
        Assert.IsFalse(someAbstractCommand.CanExecute(null));

    }

    
   
    
}