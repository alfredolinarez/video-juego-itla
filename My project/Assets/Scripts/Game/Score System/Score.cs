using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game {
    public class Score : Singleton<Score> {
        [SerializeField] private int _pointsRequiredToWin;
        public UnityAction<int> OnScoreUpdate;
        private bool _gameEnded = false;
        public int PointsRequiredToWin {
            get => Instance._pointsRequiredToWin;
            private set => Instance._pointsRequiredToWin = value;
        }

        [SerializeField] private int _actualScore;
        public int ActualScore {
            get => Instance._actualScore;
            private set => Instance._actualScore = value;
        }

        private void Awake() {
            if(_instance != this && _instance != null)
                Destroy(this.gameObject);
            else
                _instance = this;
        }

        public void UpdateScoreCount(int value) {
            if(_gameEnded)
                return;

            if(ActualScore + value < 0) {
                GameManager.Instance.LoseGame();

                _gameEnded = true;
                return;
            }

            ActualScore += value;

            OnScoreUpdate?.Invoke(ActualScore);

            if(ActualScore >= PointsRequiredToWin) {
                GameManager.Instance.WinGame();

                _gameEnded = true;
            }
        }
    }
}