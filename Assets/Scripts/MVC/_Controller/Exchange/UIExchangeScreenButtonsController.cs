using System;
using UnityEngine;

public class UIExchangeScreenButtonsController : IBaseController, IEnterController, IExitController
{
    private const string FORMAT = "#,0";
    private UIScreenViewModel m_uiScreenViewModel;
    private UIStateChangeRequestModel m_uiStateChangeRequestModel;
    private ExchangeUiView m_castedUIView;
    private int m_coinToConvert;

    public UIExchangeScreenButtonsController(UIScreenViewModel uIScreenViewModel, UIStateChangeRequestModel uIStateChangeRequestModel)
    {
        m_uiScreenViewModel = uIScreenViewModel;
        m_uiStateChangeRequestModel = uIStateChangeRequestModel;
    }
    public void OnEnterExecute()
    {
        m_castedUIView = (ExchangeUiView)m_uiScreenViewModel.view;
        m_castedUIView.CancelButtonClickedAction += SwitchToMainScreen;
        m_castedUIView.ApplyButtonClickedAction += ApplyExchange;
        m_castedUIView.TextField.onValueChanged.AddListener(UpdateInterValue);
    }
    public void OnExitExecute()
    {
        m_castedUIView.CancelButtonClickedAction -= SwitchToMainScreen;
        m_castedUIView.ApplyButtonClickedAction -= ApplyExchange;
        m_castedUIView.TextField.onValueChanged.RemoveListener(UpdateInterValue);
    }

    private void UpdateInterValue(string arg0)
    {
        if (int.TryParse(arg0, out int currentAmountInField))
        {
            m_castedUIView.TextField.textComponent.color = currentAmountInField > GameModel.CoinCount ? Color.red : Color.white;
            m_castedUIView.InterValue.text = (currentAmountInField * GameModel.CoinToCreditRate).ToString(FORMAT);
            m_coinToConvert = currentAmountInField;
        }
        else
        {
            m_castedUIView.InterValue.text = 0.ToString();
        }
    }

    private void ApplyExchange()
    {
        if (m_coinToConvert <= GameModel.CoinCount && !GameModel.HasRunningOperations)
        {
            GameModel.ConvertCoinToCredit(m_coinToConvert);
        }
    }

    private void SwitchToMainScreen()
    {
        m_uiStateChangeRequestModel.screenSwitchRequest?.Invoke(StateScreen.Main);
    }

}
