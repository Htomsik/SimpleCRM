using System.Windows.Input;
using ProjectMateTask.Infrastructure.CMD.Base;

namespace ProjectMateTaskWpfTests.InfrastructureTests.CommandTests.Base;

public abstract class BaseCmdTests<TCommand> where TCommand : BaseCmd
{
    /// <summary>
    ///     Реагирует ли команда на изменение Executable
    /// </summary>
    [TestMethod]
    public void IsCanExecuteUpdateWhenExecutableChangeTest()
    {
        //Arrange
        TCommand someCommand = GenerateCommand();

        ICommand someAbstractCommand = someCommand;
        
        //Act+Assert
        Assert.IsTrue(someAbstractCommand.CanExecute(null));
        
        someCommand.Executable = false;
        
        Assert.IsFalse(someAbstractCommand.CanExecute(null));

    }
    
    /// <summary>
    ///     Проверяет нельзя ли создавать команду с пустыми аргументами
    /// </summary>
    [TestMethod]
    public virtual void IsCantCreateCmdWithNulArgsTest()
    {
        //Arrange+Act+Assert
        Assert.ThrowsException<ArgumentNullException>(()=>GenerateCommand(null,()=>true));
        Assert.ThrowsException<ArgumentNullException>(()=>GenerateCommand(null,(object p)=>true));
    }
    
    
    #region Generatecommand : генераторы команд

    protected abstract TCommand GenerateCommand(Action<object> action, Func<object, bool> func );
    
    protected abstract TCommand GenerateCommand(Action action, Func<bool> func);
    
    protected abstract TCommand GenerateCommand();

    #endregion
    
    
    


}