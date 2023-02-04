using System.Windows.Input;
using SimpleSRM.Tests.WPF.InfrastructureTests.CommandTests.Base;
using SimpleSRM.WPF.Infrastructure.CMD;

namespace SimpleSRM.Tests.WPF.InfrastructureTests.CommandTests;

[TestClass]
public class AsyncLambdaCmdTests : BaseCmdTests<AsyncLambdaCmd>
{
    #region GenerateCommand

    protected override AsyncLambdaCmd GenerateCommand(Action<object> action, Func<object, bool> func) =>
        action is null
            ? new(null, func)
            : new(async (object p) => action(p), func);
      


    protected override AsyncLambdaCmd GenerateCommand(Action action, Func<bool> func) =>
        action is null ? 
            new (null, func) 
            : new (async () => action(), func);


    protected override AsyncLambdaCmd GenerateCommand() => new (async () => { }, () => true);

    #endregion

    
    /// <summary>
    ///     Проверяет изменяется ли canExecute при изменении параметров
    /// </summary>
    [TestMethod]
    public void IsCanExecuteUpdateWhenCanExecuteChangeTest()
    {
        //Arrange
        bool canExecute = true;
        
        AsyncLambdaCmd someCommandWithoutObj = new AsyncLambdaCmd(async ()=>{},()=>canExecute);
        
        ICommand someAbstractCommand = someCommandWithoutObj;
        
        //Act+Assert
        Assert.IsTrue(someAbstractCommand.CanExecute(null));
        
        canExecute = false;
        
        Assert.IsFalse(someAbstractCommand.CanExecute(null));

    }

    
}