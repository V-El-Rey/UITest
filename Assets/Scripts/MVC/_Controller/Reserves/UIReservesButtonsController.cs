using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIReservesButtonsController : IBaseController, IEnterController, IExitController
{
    private UIScreenViewModel m_uiScreenViewModel;
    private UIStateChangeRequestModel m_uiStateChangeRequestModel;
    private ReservesUIView m_castedUIView;
    public UIReservesButtonsController(UIScreenViewModel uIScreenViewModel, UIStateChangeRequestModel uIStateChangeRequestModel)
    {
        m_uiScreenViewModel = uIScreenViewModel;
        m_uiStateChangeRequestModel = uIStateChangeRequestModel;
    }
    public void OnEnterExecute()
    {
        m_castedUIView = (ReservesUIView)m_uiScreenViewModel.view;
        m_castedUIView.CloseClickedAction += ExitScreen;
        m_castedUIView.BuyMedsClickedAction += BuyMeds;
        m_castedUIView.BuyPlatesClickedAction += BuyPlates;
    }

    public void OnExitExecute()
    {
        m_castedUIView.CloseClickedAction -= ExitScreen;
        m_castedUIView.BuyMedsClickedAction -= BuyMeds;
        m_castedUIView.BuyPlatesClickedAction -= BuyPlates;
    }

    private void BuyPlates()
    {
        if (!GameModel.HasRunningOperations)
        {
            if (GameModel.ConsumablesPrice.TryGetValue(GameModel.ConsumableTypes.ArmorPlate, out var priceConfig))
            {
                if (priceConfig.CoinPrice > 0)
                {
                    GameModel.BuyConsumableForGold(GameModel.ConsumableTypes.ArmorPlate);
                }
                else if (priceConfig.CreditPrice > 0)
                {
                    GameModel.BuyConsumableForSilver(GameModel.ConsumableTypes.ArmorPlate);
                }
            }
        }
    }

    private void BuyMeds()
    {
        if (!GameModel.HasRunningOperations)
        {
            if (GameModel.ConsumablesPrice.TryGetValue(GameModel.ConsumableTypes.Medpack, out var priceConfig))
            {
                if (priceConfig.CoinPrice > 0)
                {
                    GameModel.BuyConsumableForGold(GameModel.ConsumableTypes.Medpack);
                }
                else if (priceConfig.CreditPrice > 0)
                {
                    GameModel.BuyConsumableForSilver(GameModel.ConsumableTypes.Medpack);
                }
            }
        }
    }

    private void ExitScreen()
    {
        m_uiStateChangeRequestModel.screenSwitchRequest?.Invoke(StateScreen.Main);
    }
}
