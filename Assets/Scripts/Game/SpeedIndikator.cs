using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class SpeedIndikator : MonoBehaviour
    {
        [Header("SpeedClock")][SerializeField] private Text speedClock;
        private string dopText = "km/h";
        private string alarmNormSpeedText = "Оптимальная скорость";
        private string alarmMinSpeedText = "Опасная малая скорость";
        private string alarmMaxSpeedText = "Опасная высокая скорость";
        //
        private IGameExecutor games;
        [Inject]
        public void Init(IGameExecutor _games)
        {
            games = _games;
        }
        private void OnEnable()
        {
            games.OnSpeedIndikator += SpeedIndikatorText;
        }
        private void Start()
        {
            speedClock.text = String.Format("{0:0.0} {1}", 0, dopText);
        }
        private void SpeedIndikatorText(float _speed, float _minSpeed, float _maxSpeed)
        {
            if (_speed < _maxSpeed && _speed > _minSpeed) { speedClock.text = String.Format("{0:0.0} {1} {2}", _speed, dopText, alarmNormSpeedText); }
            if (_speed <= _minSpeed) { speedClock.text = String.Format("{0:0.0} {1} {2}", _speed, dopText, alarmMinSpeedText); }
            if (_speed >= _maxSpeed) { speedClock.text = String.Format("{0:0.0} {1} {2}", _speed, dopText, alarmMaxSpeedText); }
        }
    }
}

