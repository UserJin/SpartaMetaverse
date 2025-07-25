using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlappyBird
{
    public class UIManager : MonoBehaviour
    {

        public TextMeshProUGUI scoreTxt;
        public TextMeshProUGUI curScoreTxt;
        public TextMeshProUGUI bestScoreTxt;

        public Image gameoverUI;

        private const string BestScoreKey = "BestScore";

        // Start is called before the first frame update
        void Start()
        {
            if (curScoreTxt == null)
                Debug.LogError("A");
            if (scoreTxt == null)
                Debug.LogError("B");
            if (bestScoreTxt == null)
                Debug.LogError("C");

            gameoverUI.gameObject.SetActive(false);
        }

        public void ShowGameOverUI(int score)
        {
            curScoreTxt.text = $"Score: {score}";
            int bestScore = PlayerPrefs.GetInt(BestScoreKey);
            if(score > bestScore)
            {
                bestScore = score;
                PlayerPrefs.SetInt(BestScoreKey, bestScore);
            }
            bestScoreTxt.text = $"Best: {bestScore}";

            gameoverUI.gameObject.SetActive(true);
        }

        public void UpdateScore(int score)
        {
            scoreTxt.text = score.ToString();
        }

        public void ReturnBtn()
        {
            SceneManager.LoadScene(0); // 이 부분 하드코딩이라 수정 필요할 듯
        }
    }

}