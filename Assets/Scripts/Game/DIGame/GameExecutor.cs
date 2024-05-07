
using System;

namespace Game
{
    public class GameExecutor : IGameExecutor
    {
        public Action OnOverScene { get { return onOverScene; } set { onOverScene = value; } }
        private Action onOverScene;
        public Action OnVictoryScene { get { return onVictoryScene; } set { onVictoryScene = value; } }
        private Action onVictoryScene;

        public void OverScene()
        {
            onOverScene?.Invoke();
        }
        public void VictoryScene()
        {
            onVictoryScene?.Invoke();
        }
    }
}
