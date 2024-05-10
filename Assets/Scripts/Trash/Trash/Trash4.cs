using Game;
using Zenject;

namespace Trash
{
    public class Trash4 : BaseTrash
    {
        private IGameExecutor games;
        [Inject]
        public void Init(IGameExecutor _games)
        {
            games = _games;
        }
        public class Factory : PlaceholderFactory<Trash4>
        {
        }
    }
}

