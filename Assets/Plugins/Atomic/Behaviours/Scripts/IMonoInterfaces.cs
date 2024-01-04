namespace Atomic.Behaviours
{
    public interface ILogic
    {
    }

    public interface IEnable : ILogic
    {
        void Enable();
    }

    public interface IDisable : ILogic
    {
        void Disable();
    }

    public interface IUpdate : ILogic
    {
        void OnUpdate();
    }

    public interface IFixedUpdate : ILogic
    {
        void OnFixedUpdate();
    }

    public interface ILateUpdate : ILogic
    {
        void OnLateUpdate();
    }
}