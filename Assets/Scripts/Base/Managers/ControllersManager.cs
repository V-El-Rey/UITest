using System.Collections.Generic;

public class ControllersManager
{
    private List<IBaseController> m_controllers;
    public ControllersManager()
    {
        m_controllers = new List<IBaseController>();
    }

    public async void OnEnterControllersExecute()
    {
        foreach (var controller in m_controllers)
        {
            if (controller is IEnterAsyncController asyncControllerInstance)
            {
                await asyncControllerInstance.OnEnterAsyncExecute();
            }
            else if (controller is IEnterController controllerInstance)
            {
                controllerInstance.OnEnterExecute();
            }
        }
    }

    public void OnExitControllersExecute()
    {
        foreach (var controller in m_controllers)
        {
            if (controller is IExitController controllerInstance)
            {
                controllerInstance.OnExitExecute();
            }
        }

    }

    public void OnUpdateControllersExecute()
    {
        foreach (var controller in m_controllers)
        {
            if (controller is IUpdateController controllerInstance)
            {
                controllerInstance.OnUpdateExecute();
            }
        }
    }

    public void AddController(IBaseController controller)
    {
        if (!m_controllers.Contains(controller))
        {
            m_controllers.Add(controller);
        }
    }

    public void ClearAll()
    {
        m_controllers.Clear();
    }
}
