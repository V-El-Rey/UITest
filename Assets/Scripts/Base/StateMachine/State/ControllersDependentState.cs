using System;
using Base;

public class ControllersDependentState<TState> : BaseState<TState>, IBaseStateLoop where TState : Enum
{
    public ScreenManager<TState> StateManager;
    public ControllersManager ControllersManager { get; }
    public ControllersDependentState(TState key, ScreenManager<TState> stateManager) : base(key)
    {
        StateManager = stateManager;
        ControllersManager = new ControllersManager();
    }

    public virtual void EnterState()
    {
        ControllersManager.OnEnterControllersExecute();
    }

    public virtual void UpdateState()
    {
        ControllersManager.OnUpdateControllersExecute();
    }

    public virtual void FixedUpdateState()
    {
    }

    public virtual void ExitState()
    {
        ControllersManager.OnExitControllersExecute();
        ControllersManager.ClearAll();
    }
}
