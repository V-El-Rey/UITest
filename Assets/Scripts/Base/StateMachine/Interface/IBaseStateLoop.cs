public interface IBaseStateLoop
{
    void EnterState();
    void UpdateState();
    void FixedUpdateState();
    void ExitState();
}