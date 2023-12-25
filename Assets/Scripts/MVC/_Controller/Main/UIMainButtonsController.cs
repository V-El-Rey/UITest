public class UIMainButtonsController : IBaseController, IEnterController, IExitController
{
    private UIScreenViewModel m_uiScreenViewModel;
    private UIStateChangeRequestModel m_uiStateChangeRequestModel;
    private MainUIView m_castedUIView;
    public UIMainButtonsController(UIScreenViewModel uIScreenViewModel, UIStateChangeRequestModel uIStateChangeRequestModel)
    {
        m_uiScreenViewModel = uIScreenViewModel;
        m_uiStateChangeRequestModel = uIStateChangeRequestModel;
    }
    public void OnEnterExecute()
    {
        m_castedUIView = (MainUIView)m_uiScreenViewModel.view;
        m_castedUIView.ExchangeButtonClickedAction += SwitchToExchangeScreen;
        m_castedUIView.ReserveButtonClickedAction += SwitchToReservesScreen;
    }

    public void OnExitExecute()
    {
        m_castedUIView.ExchangeButtonClickedAction -= SwitchToExchangeScreen;
        m_castedUIView.ReserveButtonClickedAction -= SwitchToReservesScreen;
    }
    private void SwitchToReservesScreen()
    {
        m_uiStateChangeRequestModel.screenSwitchRequest?.Invoke(StateScreen.Reserves);
    }

    private void SwitchToExchangeScreen()
    {
        m_uiStateChangeRequestModel.screenSwitchRequest?.Invoke(StateScreen.Exchange);
    }
}
