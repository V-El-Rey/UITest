using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainUpdateValuesController : IBaseController, IEnterController
{
    private MainViewValuesUpdateModel m_uiValuesUpdateModel;
    private UIScreenViewModel m_uiScreenViewModel;
    private MainUIView m_castedView;
    public UIMainUpdateValuesController(MainViewValuesUpdateModel uiValuesUpdateModel, UIScreenViewModel uIScreenViewModel)
    {
        m_uiValuesUpdateModel = uiValuesUpdateModel;
        m_uiScreenViewModel = uIScreenViewModel;
        m_uiValuesUpdateModel.ValuesUpdateRequest += UpdateViewValues;
    }

    public void OnEnterExecute()
    {
        m_castedView = (MainUIView)m_uiScreenViewModel.view;
        UpdateViewValues();
    }

    private void UpdateViewValues()
    {
        m_castedView.CoinsValue.text = GameModel.CoinCount.ToString();
        m_castedView.CredsValue.text = GameModel.CreditCount.ToString();
        m_castedView.MedsValue.text = GameModel.GetConsumableCount(GameModel.ConsumableTypes.Medpack).ToString();
        m_castedView.PlatesValue.text = GameModel.GetConsumableCount(GameModel.ConsumableTypes.ArmorPlate).ToString();
    }
}
