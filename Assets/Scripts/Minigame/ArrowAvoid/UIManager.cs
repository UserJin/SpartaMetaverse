using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ArrowAvoid
{
    public class UIManager : MonoBehaviour
    {

        public TextMeshProUGUI scoreTxt;
        public TextMeshProUGUI curScoreTxt;
        public TextMeshProUGUI bestScoreTxt;
        public TextMeshProUGUI ResultTxt;

        public GameObject gameoverUI;

        private const string BestScoreKey = "ArrowAvoidBestScore";
        [SerializeField] private int ClearCount = 10;

        // Start is called before the first frame update
        void Start()
        {
            gameoverUI.gameObject.SetActive(false);
        }

        public void ShowGameOverUI(int score)
        {
            curScoreTxt.text = $"Score: {score}";
            int bestScore = PlayerPrefs.GetInt(BestScoreKey);
            if (score > bestScore)
            {
                bestScore = score;
                PlayerPrefs.SetInt(BestScoreKey, bestScore);
            }
            bestScoreTxt.text = $"Best: {bestScore}";
            if (score > ClearCount)
                ResultTxt.text = "Clear!";
            else
                ResultTxt.text = "Fail...";

            gameoverUI.gameObject.SetActive(true);
        }

        public void UpdateScore(int score)
        {
            scoreTxt.text = score.ToString();
        }

        public void ReturnBtn()
        {
            Time.timeScale = 1f;
            SceneLoader.Instance.LoadScene("LobbyScene");
        }
    }
}
