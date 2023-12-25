
using System;
using UnityEngine;

public class UIExchangeScreenValuesController : IBaseController, IEnterController, IExitController
{
    private const string FORMAT = "#,0";
    private UIScreenViewModel m_uiScreenViewModel;
    private ExchangeUiView m_castedUIView;
    public UIExchangeScreenValuesController(UIScreenViewModel uIScreenViewModel)
    {
        m_uiScreenViewModel = uIScreenViewModel;
    }
    public void OnEnterExecute()
    {
        m_castedUIView = (ExchangeUiView)m_uiScreenViewModel.view;
        GameModel.ModelChanged += UpdateValues;
        m_castedUIView.TextField.text = 0.ToString();
        m_castedUIView.InterValue.text = 0.ToString();
        UpdateValues();
        m_castedUIView.ExchangeRatio.text = GameModel.CoinToCreditRate.ToString();
    }

    public void OnExitExecute()
    {
        GameModel.ModelChanged -= UpdateValues;
    }

    private void UpdateValues()
    {
        if (int.TryParse(m_castedUIView.TextField.text, out int currentAmountInField))
        {
            m_castedUIView.TextField.textComponent.color = currentAmountInField > GameModel.CoinCount ? Color.red : Color.white;
        }
        m_castedUIView.CoinValue.text = GameModel.CoinCount.ToString(FORMAT);
        m_castedUIView.CredsValue.text = GameModel.CreditCount.ToString(FORMAT);
    }
}
