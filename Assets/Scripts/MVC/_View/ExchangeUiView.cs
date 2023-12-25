using System;
using TMPro;
using UnityEngine;

public class ExchangeUiView : MonoBehaviour
{
    public Action ApplyButtonClickedAction;
    public Action CancelButtonClickedAction;
    public TMP_InputField TextField;
    public TMP_Text ExchangeRatio;
    public TMP_Text InterValue;
    public TMP_Text CoinValue;
    public TMP_Text CredsValue;

    public void OnApplyButtonClicked() => ApplyButtonClickedAction?.Invoke();
    public void OnCancelButtonClicked() => CancelButtonClickedAction?.Invoke();
}
