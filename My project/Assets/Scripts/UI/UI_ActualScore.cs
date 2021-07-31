using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using UnityEngine.UI;

namespace UI
{
    public class UI_ActualScore : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        private const string SCORE_FORMAT = "0#######";
        private void Start()
        {
            Score.Instance.OnScoreUpdate += UpdateScoreUI;
        }

        private void OnDisable()
        {
            Score.Instance.OnScoreUpdate -= UpdateScoreUI;
        }

        private void UpdateScoreUI(int actualScore)
        {
            _scoreText.text = actualScore.ToString(SCORE_FORMAT);
        }
    }
}