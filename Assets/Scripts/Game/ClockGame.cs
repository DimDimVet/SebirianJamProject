using Input;
using MainMenu;
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class ClockGame : MonoBehaviour
    {
        [Header("TextClock")]
        [SerializeField] private Text txtClock;
        [Header("Стартовое время,секунды")]
        [SerializeField] private float startTimeSec;
        [Header("Стартовое время,минуты")]
        [SerializeField] private float startTimeMin;
        [Header("Стартовое время,часы")]
        [SerializeField] private float startTimeHour;
        private string dopText = "";
        private bool isTicClock = false;
        //
        private float clock, countClockSec = 0f, countClockMin = 0f, countClockHour = 0f;

        private IMenuExecutor panels;
        private IGameExecutor games;
        [Inject]
        public void Init(IGameExecutor _games, IMenuExecutor _panels)
        {
            panels = _panels;
            games = _games;
        }
        private void OnEnable()
        {
            panels.OnGetClock += SetClock;
        }
        private void SetClock(float secund, float minute, float hour)
        {
            if (isTicClock) { txtClock.text = String.Format("{0:00} {1:00}:{2:00}.{3:00}", dopText, hour, minute, secund); }
            else { txtClock.text = String.Format("{0:00} {1:00}:{2:00} {3:00}", dopText, hour, minute, secund); }
            isTicClock = !isTicClock;
        }
        void Update()
        {
            Clock();
        }
        private void Clock()
        {
            if (clock + 1 <= Time.time)
            {
                clock = Time.time;
                countClockSec++;

                if (countClockSec >= 60) { countClockMin++; countClockSec = 0f; }
                if (countClockMin >= 60) { countClockHour++; countClockMin = 0f; }

                startTimeSec--;
                if (startTimeSec <= 0)
                {
                    startTimeMin--;
                    if (startTimeMin == 0) { startTimeSec = 60f; }

                    if (startTimeMin < 0) { startTimeSec = 0f; }
                    else { startTimeSec = 60f; }
                }
                
                if (startTimeMin <= 0 & startTimeSec <= 0)
                {
                    startTimeHour--;
                    if (startTimeHour <= 0) { countClockMin = 0f; }
                    else { countClockMin = 60f; }

                }

                // panels.SetClock(countClockSec, countClockMin, countClockHour);
                if (startTimeSec < 0) { startTimeSec = 0; }
                if (startTimeMin < 0) { startTimeMin = 0; }
                if (startTimeHour < 0) { startTimeHour = 0; }

                panels.SetClock(MathF.Abs(startTimeSec), MathF.Abs(startTimeMin), MathF.Abs(startTimeHour));
                if (startTimeSec == 0 & startTimeMin == 0 & startTimeHour == 0) { panels.OverScene(); }
            }
        }
    }
}

