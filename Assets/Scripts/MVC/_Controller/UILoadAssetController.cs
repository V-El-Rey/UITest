using Cysharp.Threading.Tasks;
using UnityEngine;

public class UILoadAssetController : IBaseController, IEnterAsyncController
{
    private string m_assetID;
    private UIScreenViewModel m_screenViewModel;
    public UILoadAssetController(string assetID, UIScreenViewModel screenViewModel)
    {
        m_assetID = assetID;
        m_screenViewModel = screenViewModel;
    }
    public async UniTask OnEnterAsyncExecute()
    {
        if (!m_screenViewModel.isInstantiated)
        {
            var prefab = await GameData.AssetLoader.LoadAsset(m_assetID);
            var obj = GameObject.Instantiate(prefab, m_screenViewModel.uiRoot);
            switch (m_assetID)
            {
                case AssetDataPath.UI_MAIN:
                    {
                        m_screenViewModel.view = obj.GetComponent<MainUIView>();
                    }
                    break;
                case AssetDataPath.UI_EXCHANGE:
                    {
                        m_screenViewModel.view = obj.GetComponent<ExchangeUiView>();
                    }
                    break;
                case AssetDataPath.UI_RESERVES:
                    {
                        m_screenViewModel.view = obj.GetComponent<ReservesUIView>();
                    }
                    break;
            }
            m_screenViewModel.isInstantiated = true;
        }
        else
        {
            m_screenViewModel.view.gameObject.SetActive(true);
        }
    }
}
