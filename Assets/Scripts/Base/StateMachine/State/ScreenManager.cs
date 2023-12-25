using System;
using System.Collections.Generic;

namespace Base
{
    public class ScreenManager<EState> where EState : Enum
    {
        public Dictionary<EState, IBaseStateLoop> States = new Dictionary<EState, IBaseStateLoop>();
        public IBaseStateLoop CurrentState { get; set; }

        private bool isStateTransitioning;

        public void InitScreenManager()
        {
            CurrentState.EnterState();
        }

        public void OnUpdateExecute()
        {
            if (!isStateTransitioning)
            {
                CurrentState.UpdateState();
            }
        }

        public void OnFixedUpdateExecute()
        {
            if (!isStateTransitioning)
            {
                CurrentState.FixedUpdateState();
            }
        }

        public void SwitchScreen(EState nextStateKey)
        {
            isStateTransitioning = true;
            CurrentState.ExitState();
            CurrentState = States[nextStateKey];
            CurrentState.EnterState();
            isStateTransitioning = false;
        }
    }
}
