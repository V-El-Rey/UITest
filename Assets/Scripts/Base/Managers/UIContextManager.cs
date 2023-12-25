using UnityEngine;

public class UIContextManager : MonoBehaviour
{
    [HideInInspector]
    public Transform UiRoot;
    public static UIContextManager Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        UiRoot = transform.GetChild(0).GetComponent<Transform>();
    }
}
