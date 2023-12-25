using System;

public class UIStateChangeRequestModel : IModel
{
    public Action<StateScreen> screenSwitchRequest;
}
