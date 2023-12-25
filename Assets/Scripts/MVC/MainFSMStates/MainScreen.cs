using Base;

public class MainScreen : ControllersDependentState<StateScreen>
{
    private UIScreenViewModel m_uiScreenViewModel;
    private UIStateChangeRequestModel m_uiStateChangeRequestModel;
    private MainViewValuesUpdateModel m_uiUpdateModel;
    public MainScreen(StateScreen key, ScreenManager<StateScreen> stateManager, MainViewValuesUpdateModel uiUpdateModel, UIScreenViewModel uIScreenViewModel) : base(key, stateManager)
    {
        m_uiStateChangeRequestModel = new UIStateChangeRequestModel();
        m_uiScreenViewModel = uIScreenViewModel;
        m_uiUpdateModel = uiUpdateModel;
    }

    public override void EnterState()
    {
        m_uiStateChangeRequestModel.screenSwitchRequest += ExecuteSwitch;
        ControllersManager.AddController(new UILoadAssetController(AssetDataPath.UI_MAIN, m_uiScreenViewModel));
        ControllersManager.AddController(new UIMainButtonsController(m_uiScreenViewModel, m_uiStateChangeRequestModel));
        ControllersManager.AddController(new UIMainUpdateValuesController(m_uiUpdateModel, m_uiScreenViewModel));
        base.EnterState();
    }

    public override void ExitState()
    {
        m_uiStateChangeRequestModel.screenSwitchRequest -= ExecuteSwitch;
        base.ExitState();
    }

    private void ExecuteSwitch(StateScreen screen)
    {
        StateManager.SwitchScreen(screen);
    }
}
