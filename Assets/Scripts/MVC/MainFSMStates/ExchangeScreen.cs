using Base;
using UnityEngine;

public class ExchangeScreen : ControllersDependentState<StateScreen>
{
    private UIStateChangeRequestModel m_uiStateChangeRequestModel;
    private UIScreenViewModel m_uiScreenViewModel;

    public ExchangeScreen(StateScreen key, ScreenManager<StateScreen> stateManager, UIScreenViewModel uIScreenViewModel) : base(key, stateManager)
    {
        m_uiStateChangeRequestModel = new UIStateChangeRequestModel();
        m_uiScreenViewModel = uIScreenViewModel;
    }

    public override void EnterState()
    {
        m_uiStateChangeRequestModel.screenSwitchRequest += ExecuteSwitch;
        ControllersManager.AddController(new UILoadAssetController(AssetDataPath.UI_EXCHANGE, m_uiScreenViewModel));
        ControllersManager.AddController(new UIExchangeScreenValuesController(m_uiScreenViewModel));
        ControllersManager.AddController(new UIExchangeScreenButtonsController(m_uiScreenViewModel, m_uiStateChangeRequestModel));
        base.EnterState();
    }

    private void ExecuteSwitch(StateScreen screen)
    {
        StateManager.SwitchScreen(screen);
    }

    public override void ExitState()
    {
        m_uiScreenViewModel.view.gameObject.SetActive(false);
        base.ExitState();
    }
}
