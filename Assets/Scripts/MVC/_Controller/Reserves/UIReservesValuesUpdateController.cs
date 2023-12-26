using TMPro;
using UnityEngine;

public class UIReservesValuesUpdateController : IBaseController, IEnterController, IExitController
{
    private const string FORMAT = "#,0";
    private UIScreenViewModel m_uiScreenViewModel;
    private ReservesUIView m_castedView;
    public UIReservesValuesUpdateController(UIScreenViewModel uIScreenViewModel)
    {
        m_uiScreenViewModel = uIScreenViewModel;
    }
    public void OnEnterExecute()
    {
        m_castedView = (ReservesUIView)m_uiScreenViewModel.view;
        GameModel.ModelChanged += UpdateValues;
        UpdateValues();
    }

    public void OnExitExecute()
    {
        GameModel.ModelChanged -= UpdateValues;
    }

    private void UpdateValues()
    {
        m_castedView.MedsCount.text = GameModel.GetConsumableCount(GameModel.ConsumableTypes.Medpack).ToString(FORMAT);
        m_castedView.PlatesCount.text = GameModel.GetConsumableCount(GameModel.ConsumableTypes.ArmorPlate).ToString(FORMAT);
        UpdateButtonPrices(GameModel.ConsumableTypes.Medpack, m_castedView.MedsCoinPrice, m_castedView.MedsCredsPrice,
            m_castedView.MedsCoinPriceObj, m_castedView.MedsCredsPriceObj);
        UpdateButtonPrices(GameModel.ConsumableTypes.ArmorPlate, m_castedView.PlatesCoinPrice, m_castedView.PlatesCredsPrice,
            m_castedView.PlatesCoinPriceObj, m_castedView.PlatesCredsPriceObj);
    }

    private void UpdateButtonPrices(GameModel.ConsumableTypes consumableType, TMP_Text coinPrice, TMP_Text credPrice, GameObject coinObj, GameObject credObj)
    {
        if (GameModel.ConsumablesPrice.TryGetValue(consumableType, out var priceConfig))
        {
            if (priceConfig.CoinPrice != 0)
            {
                coinObj.SetActive(true);
                coinPrice.text = priceConfig.CoinPrice.ToString(FORMAT);
            }
            else
            {
                coinObj.SetActive(false);
            }
            if (priceConfig.CreditPrice != 0)
            {
                credObj.SetActive(true);
                credPrice.text = priceConfig.CreditPrice.ToString(FORMAT);
            }
            else
            {
                credObj.SetActive(false);
            }
        }

    }
}
