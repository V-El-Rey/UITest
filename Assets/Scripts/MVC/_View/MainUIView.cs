using System;
using TMPro;
using UnityEngine;

public class MainUIView : MonoBehaviour
{
    public Action ExchangeButtonClickedAction;
    public Action ReserveButtonClickedAction;
    public TMP_Text CoinsValue;
    public TMP_Text CredsValue;
    public TMP_Text MedsValue;
    public TMP_Text PlatesValue;
    public void OnExchangeButtonClicked() => ExchangeButtonClickedAction?.Invoke();
    public void OnReserveButtonClicked() => ReserveButtonClickedAction?.Invoke();
}
