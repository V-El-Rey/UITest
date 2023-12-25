using Base;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public Transform UIRoot;
    private ScreenManager<StateScreen> m_gameStateScreensManager;
    private MainViewValuesUpdateModel m_mainViewValuesUpdateModel;

    private UIScreenViewModel m_mainViewModel;
    private UIScreenViewModel m_exchangeModel;
    private UIScreenViewModel m_reservesModel;

    private void Start()
    {
        m_mainViewModel = new UIScreenViewModel() { uiRoot = UIRoot, isInstantiated = false };
        m_exchangeModel = new UIScreenViewModel() { uiRoot = UIRoot, isInstantiated = false };
        m_reservesModel = new UIScreenViewModel() { uiRoot = UIRoot, isInstantiated = false };
        m_mainViewValuesUpdateModel = new MainViewValuesUpdateModel();
        InitializeScreenManager();
        GameModel.ModelChanged += UpdateMainScreenValues;
    }

    private void Update()
    {
        m_gameStateScreensManager?.OnUpdateExecute();
        GameModel.Update();
    }

    private void OnDestroy()
    {
        GameModel.ModelChanged -= UpdateMainScreenValues;
    }

    private void InitializeScreenManager()
    {
        m_gameStateScreensManager = new ScreenManager<StateScreen>();
        m_gameStateScreensManager.States[StateScreen.Main] = new MainScreen(StateScreen.Main, m_gameStateScreensManager, m_mainViewValuesUpdateModel, m_mainViewModel);
        m_gameStateScreensManager.States[StateScreen.Exchange] = new ExchangeScreen(StateScreen.Exchange, m_gameStateScreensManager, m_exchangeModel);
        m_gameStateScreensManager.States[StateScreen.Reserves] = new ReservesScreen(StateScreen.Reserves, m_gameStateScreensManager);
        m_gameStateScreensManager.CurrentState = m_gameStateScreensManager.States[StateScreen.Main];
        m_gameStateScreensManager.InitScreenManager();
    }
    private void UpdateMainScreenValues()
    {
        m_mainViewValuesUpdateModel.ValuesUpdateRequest?.Invoke();
    }
}
