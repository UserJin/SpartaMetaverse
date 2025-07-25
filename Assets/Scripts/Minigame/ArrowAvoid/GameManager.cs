using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ArrowAvoid
{
    public class GameManager : MonoBehaviour
    {
        static GameManager gameManager;
        public static GameManager Instance { get { return gameManager; } }

        public int curScore = 0;

        UIManager uiManager;
        public UIManager UIManager { get { return uiManager; } }

        public GameObject gameStartUI;
        ArrowGenerator generator;

        private void Awake()
        {
            gameManager = this;
            uiManager = FindObjectOfType<UIManager>();
            generator = GetComponent<ArrowGenerator>();
        }

        private void Start()
        {
            gameStartUI.SetActive(true);
            uiManager.UpdateScore(0);
            Time.timeScale = 0;
        }

        public void GameOver()
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
            generator.StopGenerateArrow();
            uiManager.ShowGameOverUI(curScore);
        }

        public void AddScore(int score)
        {
            curScore += score;
            uiManager.UpdateScore(curScore);
        }

        public void StartGame()
        {
            gameStartUI.SetActive(false);
            generator.StartGenerateArrow();
            Time.timeScale = 1;
        }
    }
}
