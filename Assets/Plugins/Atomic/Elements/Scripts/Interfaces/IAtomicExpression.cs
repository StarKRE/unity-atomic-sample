namespace Atomic.Elements
{
    public interface IAtomicExpression<T> : IAtomicFunction<T>
    {
        IAtomicExpression<T> AddMember(IAtomicValue<T> member);
        IAtomicExpression<T> RemoveMember(IAtomicValue<T> member);
    }
}