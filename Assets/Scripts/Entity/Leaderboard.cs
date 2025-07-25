using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Leaderboard : MonoBehaviour, IInteractable
{
    public GameObject leaderboardUI;
    public TextMeshProUGUI flappyBirdbestScoreText;
    public TextMeshProUGUI arrowAvoidbestScoreText;
    private TextMeshProUGUI interactText;

    // 플레이어 레이어
    [SerializeField] LayerMask targetLayor;

    private PlayerController player;
    private bool isLeaderboardOpen = false;

    private const string FlappyBirdBestScoreKey = "FlappyBirdBestScore";
    private const string ArrowAvoidBestScoreKey = "ArrowAvoidBestScore";

    private void Awake()
    {
        targetLayor = LayerMask.GetMask("Player");
        interactText = transform.GetComponentInChildren<TextMeshProUGUI>(true);
        interactText.gameObject.SetActive(false);
        leaderboardUI.SetActive(false);
    }

    public void OnInteract(PlayerController player)
    {
        this.player = player;

        if(isLeaderboardOpen)
            CloseLeaderboard();
        else
            ShowLeaderboard();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetLayor.value != (targetLayor | (1 << collision.gameObject.layer)))
            return;

        interactText.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targetLayor.value != (targetLayor | (1 << collision.gameObject.layer)))
            return;

        interactText.gameObject.SetActive(false);
    }

    private void ShowLeaderboard()
    {
        player.GetComponent<PlayerInput>().actions["Move"].Disable();
        player.GetComponent<PlayerInput>().actions["Ride"].Disable();

        isLeaderboardOpen = true;

        int flappybirdBestScore = PlayerPrefs.GetInt(FlappyBirdBestScoreKey);
        flappyBirdbestScoreText.text = $"Best Score: {flappybirdBestScore}";

        int arrowAvoidBestScore = PlayerPrefs.GetInt(ArrowAvoidBestScoreKey);
        arrowAvoidbestScoreText.text = $"Best Score: {arrowAvoidBestScore}";

        interactText.gameObject.SetActive(false);
        leaderboardUI.SetActive(true);
    }

    private void CloseLeaderboard()
    {
        isLeaderboardOpen = false;
        leaderboardUI.SetActive(false);

        player.GetComponent<PlayerInput>().actions["Move"].Enable();
        player.GetComponent<PlayerInput>().actions["Ride"].Enable();

        interactText.gameObject.SetActive(true);
    }
}
