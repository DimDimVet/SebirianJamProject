using Input;
using MainMenu;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class ClockGame : MonoBehaviour
    {
        [Header("TextClock")]
        [SerializeField] private Text txtClock;
        private bool isTicClock = false;
        //
        private float clock, countClockSec = 0f, countClockMin = 0f, countClockHour = 0f;

        private IMenuExecutor panels;
        [Inject]
        public void Init(IInputPlayerExecutor _inputs, IMenuExecutor _panels)
        {
            panels = _panels;
        }
        private void OnEnable()
        {
            panels.OnGetClock += SetClock;
        }
        private void SetClock(float secund, float minute, float hour)
        {
            if (isTicClock) { txtClock.text = String.Format("{0:00}:{1:00}.{2:00}", hour, minute, secund); }
            else { txtClock.text = String.Format("{0:00}:{1:00} {2:00}", hour, minute, secund); }
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
                panels.SetClock(countClockSec, countClockMin, countClockHour);
            }
        }
    }
}

