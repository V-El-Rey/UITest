using Base;

public class ReservesScreen : ControllersDependentState<StateScreen>
{
    private UIScreenViewModel m_uiScreenViewModel;
    private UIStateChangeRequestModel m_uiStateChangeRequestModel;
    public ReservesScreen(StateScreen key, ScreenManager<StateScreen> stateManager, UIScreenViewModel uIScreenViewModel) : base(key, stateManager)
    {
        m_uiStateChangeRequestModel = new UIStateChangeRequestModel();
        m_uiScreenViewModel = uIScreenViewModel;
    }

    public override void EnterState()
    {
        m_uiStateChangeRequestModel.screenSwitchRequest += ExecuteSwitch;
        ControllersManager.AddController(new UILoadAssetController(AssetDataPath.UI_RESERVES, m_uiScreenViewModel));
        ControllersManager.AddController(new UIReservesValuesUpdateController(m_uiScreenViewModel));
        ControllersManager.AddController(new UIReservesButtonsController(m_uiScreenViewModel, m_uiStateChangeRequestModel));
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void ExitState()
    {
        m_uiScreenViewModel.view.gameObject.SetActive(false);
        m_uiStateChangeRequestModel.screenSwitchRequest -= ExecuteSwitch;
        base.ExitState();
    }

    private void ExecuteSwitch(StateScreen screen)
    {
        StateManager.SwitchScreen(screen);
    }
}
