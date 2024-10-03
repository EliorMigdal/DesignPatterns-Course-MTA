using Model.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;

namespace Model.Logic.Filterer.Types
{
    public class DefaultFilterer : IFilterer<PostAdapter>
    {
        public string Name => "Default";

        public bool Filter(PostAdapter i_Obj)
        {
            return true;
        }
    }
}