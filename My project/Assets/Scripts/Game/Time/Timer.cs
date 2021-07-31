using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class Timer : Singleton<Timer>
    {
        private float _seconds;
        private int _minutes;

        public UnityAction<int, float> OnTimeChange;

        private IEnumerator coroutine;

        public int GetEndMinutes
        {
            get => _minutes;
        }

        public float GetEndSeconds
        {
            get => _seconds;
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
                _instance = this;
        }

        void Start()
        {
            _seconds = 0;
            _minutes = 0;

            coroutine = TimerTick_Coroutine();

            StartCoroutine(coroutine);

            GameManager.OnGameWin += StopTimer;
        }

        public void AddTime(float seconds)
        {
            if (seconds + Instance._seconds > 60)
            {
                float dif = 60 - Instance._seconds;
                float otherDif = seconds - dif;

                _minutes += 1;
                _seconds = otherDif;
            }
            else
                _seconds += seconds;

            OnTimeChange.Invoke(Instance._minutes, Instance._seconds);
        }

        public void RemoveTime(float seconds)
        {
            if (_seconds - seconds < 0)
            {
                float dif = seconds - Instance._seconds;

                _minutes -= 1;
                _seconds = 60 - dif;
            }
            else
                _seconds -= seconds;
        }

        private void OnDisable()
        {
            GameManager.OnGameWin -= StopTimer;
        }

        private IEnumerator TimerTick_Coroutine()
        {
            int ticks = 0;

            while(true)
            {
                yield return new WaitForSeconds(1f);

                _seconds += 1;

                ticks += 1;

                OnTimeChange?.Invoke(_minutes, _seconds);

                if(_seconds >= 60)
                {
                    _minutes += 1;
                    _seconds = 0;
                }
            
                if(ticks == 10)
                {
                    Score._instance.UpdateScoreCount(-5);
                    ticks = 0;
                }
            }
        }

        public void StopTimer() => StopCoroutine(coroutine);
    }
}