using System;
using TMPro;
using UnityEngine;

public class ReservesUIView : MonoBehaviour
{
    public Action BuyPlatesClickedAction;
    public Action BuyMedsClickedAction;
    public Action CloseClickedAction;
    public TMP_Text MedsCount;
    public TMP_Text PlatesCount;
    public TMP_Text MedsCoinPrice;
    public TMP_Text MedsCredsPrice;
    public TMP_Text PlatesCoinPrice;
    public TMP_Text PlatesCredsPrice;
    public GameObject MedsCoinPriceObj;
    public GameObject MedsCredsPriceObj;
    public GameObject PlatesCoinPriceObj;
    public GameObject PlatesCredsPriceObj;
    public void OnBuyMedsClicked() => BuyMedsClickedAction?.Invoke();
    public void OnBuyPlatesClicked() => BuyPlatesClickedAction?.Invoke();
    public void OnCloseClicked() => CloseClickedAction?.Invoke();
}
