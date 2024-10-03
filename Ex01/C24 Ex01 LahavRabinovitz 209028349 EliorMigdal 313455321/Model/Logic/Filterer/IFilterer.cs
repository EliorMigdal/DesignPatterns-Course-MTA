namespace Model.Logic.Filterer
{
    public interface IFilterer<T> where T : class
    {
        string Name { get; }
        bool Filter(T i_Obj);
    }
}