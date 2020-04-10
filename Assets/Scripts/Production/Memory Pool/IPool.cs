namespace Tools
{
    public interface IPool<T>
    {
        T GetUnit(bool returnActive);
    }
}