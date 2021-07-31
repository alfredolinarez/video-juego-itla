using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using UnityEngine.UI;

namespace UI
{
    public class UI_WinScreen : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _timeText;
        private string SCORE_FORMAT = "#######";
        private string TIME_FORMAT = "0#";
        private void Start()
        {
            _scoreText.text = Score.Instance.ActualScore.ToString(SCORE_FORMAT);
            _timeText.text = $"{Timer.Instance.GetEndMinutes.ToString(TIME_FORMAT)}:{Timer.Instance.GetEndSeconds.ToString(TIME_FORMAT)}";
        }
    }
}