using UnityEngine;

public class GameData
{
    private static readonly GameData m_instance = new GameData();
    public IDataDescriprionContext DataDescriptions;
    public static AddressableAssetLoader<GameObject> AssetLoader = new AddressableAssetLoader<GameObject>();
    public static GameData Instanse
    {
        get
        {
            if (m_instance == null)
            {
                return new GameData();
            }
            return m_instance;
        }
    }

    static GameData()
    {
    }

    private GameData()
    {
    }
}
