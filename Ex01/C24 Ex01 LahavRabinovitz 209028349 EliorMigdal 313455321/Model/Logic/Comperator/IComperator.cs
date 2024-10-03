namespace Model.Logic.Comperator
{
    public interface IComperator<T> where T : class
    {
        string Name { get; }
        int Compare(T i_ObjA, T i_ObjB);
    }
}