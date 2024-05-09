
using System;

namespace Game
{
    public interface IGameExecutor
    {
        void SpeedIndikator(float _speed, float _minSpeed, float _maxSpeed);
        Action<float, float, float> OnSpeedIndikator { get; set; }
        void SetCollisionHash(int _hash);
        Action<int> OnSetCollisionHash { get; set; }
        void RaisingSpeed(int _speed);
        Action<int> OnRaisingSpeed { get; set; }
        void SetHashPlayer(int _hash);
        int GetHashPlayer();
    }
}

