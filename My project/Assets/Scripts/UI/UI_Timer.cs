using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game;

namespace UI
{
    public class UI_Timer : MonoBehaviour
    {
        [SerializeField] private Text _timeText;
        private const string TIME_FORMAT = "0#";

        private void Start()
        {
            Timer.Instance.OnTimeChange += UpdateTimer; 
        }

        private void OnDisable()
        {
            Timer.Instance.OnTimeChange -= UpdateTimer;
        }

        private void UpdateTimer(int currentMinutes, float currentSeconds)
        {
            _timeText.text = $"{currentMinutes.ToString(TIME_FORMAT)}:{currentSeconds.ToString(TIME_FORMAT)}";
        }
    }
}