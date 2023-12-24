using UnityEngine;

public class StateManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        GameModel.Update();
    }

    private void OnDestroy()
    {
        
    }
}
