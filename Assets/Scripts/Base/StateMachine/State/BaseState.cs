using System;

namespace Base
{
    public abstract class BaseState<EState> where EState : Enum
    {
        public EState StateKey { get; private set; }
        public BaseState(EState key)
        {
            StateKey = key;
        }
    }
}
