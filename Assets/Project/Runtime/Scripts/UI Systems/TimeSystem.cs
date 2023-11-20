using System;
using UnityEngine;
namespace RPGSandBox.WorldSystem
{
    public class TimeSystem : MonoBehaviour
    {
        public static TimeSystem Instance { get; private set; }
        public Action OnTimerChanged;
        public Action OnTimerPaused;
        public Action<float> OnNextHourTriggered;
        float day = 0f, hour = 0f, min = 0f, sec = 0f;
        float standardMinute = 60f;
        float standardHour = 60f;
        float standardDay = 24f;
        float TimeScale = 0.05f;
        float StartTimeScale;
        float StartFixedDeltaTime;
        //Take at least 2 seconds to slow down
        //float slowDurationTime = 2f;
        string currentTime = "00:00:00";
        bool onPause = false;
        bool onAction = false;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        private void Start()
        {
            StartTimeScale = Time.timeScale;
            StartFixedDeltaTime = Time.fixedDeltaTime;
        }
        private void Update()
        {
            if (onPause)
            {
                return;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                ExecuteSlowMotion(true);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ExecuteSlowMotion(false);
            }
            PerformLogic();
        }
        public void PauseTimer()
        {
            onPause = !onPause;
            if (onPause)
            {
                Time.timeScale = 0f;
            }
            else if (!onPause)
            {
                StopSlowMotion();
            }
        }
        public void ExecuteSlowMotion(bool update)
        {
            onAction = update;

        }
        void StopSlowMotion()
        {
            Time.timeScale = StartTimeScale;
            Time.fixedDeltaTime = StartFixedDeltaTime;
        }
        void StartSlowMotion()
        {
            Time.timeScale = TimeScale;
            Time.fixedDeltaTime = StartFixedDeltaTime * TimeScale;
        }
        private void PerformLogic()
        {
            if (onAction)
            {
                StartSlowMotion();
            }
            else if (!onAction)
            {
                StopSlowMotion();
            }
            sec += Time.deltaTime * 1f;
            OnTimerChanged?.Invoke();
            if (sec >= standardMinute)
            {
                sec = 0f;
                min++;

            }
            if (min >= standardHour)
            {
                min = 0f;
                hour++;
                OnNextHourTriggered?.Invoke(hour);
            }
            if (hour >= standardDay)
            {
                hour = 0f;
                day++;
            }
        }
        public string GetUpdateTimer()
        {
            currentTime = $"{day:00}:{hour:00}:{min:00}:{sec:00}";
            return currentTime;
        }
    }
}


