
using System;

namespace Game
{
    public class GameExecutor : IGameExecutor
    {
        private int hashPlayer;
        public Action<float, float, float> OnSpeedIndikator { get { return onSpeedIndikator; } set { onSpeedIndikator = value; } }
        private Action<float, float, float> onSpeedIndikator;
        public Action<int> OnSetCollisionHash { get { return onSetCollisionHash; } set { onSetCollisionHash = value; } }
        private Action<int> onSetCollisionHash;
        public Action<int> OnRaisingSpeed { get { return onRaisingSpeed; } set { onRaisingSpeed = value; } }
        private Action<int> onRaisingSpeed;

        #region Player
        public void SetHashPlayer(int _hash)
        {
            hashPlayer=_hash;
        }
        public int GetHashPlayer()
        {
            return hashPlayer;
        }
        #endregion
        #region Indikator
        public void SpeedIndikator(float _speed, float _minSpeed, float _maxSpeed)
        {
            if (_speed > 0) { onSpeedIndikator?.Invoke(_speed, _minSpeed, _maxSpeed); }
        }
        #endregion
        #region Executor
        public void SetCollisionHash(int _hash)
        {
            onSetCollisionHash?.Invoke(_hash);
        }
        public void RaisingSpeed(int _speed)
        {
            onRaisingSpeed?.Invoke(_speed);
        }
        #endregion

    }
}
