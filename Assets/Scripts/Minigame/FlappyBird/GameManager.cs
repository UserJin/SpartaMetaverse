using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyBird
{
    public class GameManager : MonoBehaviour
    {
        static GameManager gameManager;
        public static GameManager Instance { get { return gameManager; } }

        public int curScore = 0;

        UIManager uiManager;
        public UIManager UIManager { get { return uiManager; } }

        private void Awake()
        {
            gameManager = this;
            uiManager = FindObjectOfType<UIManager>();
        }

        private void Start()
        {
            uiManager.UpdateScore(0);
        }

        public void GameOver()
        {
            Debug.Log("Game Over");
            uiManager.ShowGameOverUI(curScore);
        }

        public void AddScore(int score)
        {
            curScore += score;
            uiManager.UpdateScore(curScore);
        }

    }
}

