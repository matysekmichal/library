namespace Library.Data.Seed
{
    public interface IFactory<T>
    {
        T Create();
    }
}