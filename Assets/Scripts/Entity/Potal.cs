using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Potal : MonoBehaviour, IInteractable
{
    // 이동하려는 씬 넘버
    [SerializeField] int scneneNum;
    // 플레이어 레이어
    [SerializeField] LayerMask targetLayor;
    // UI
    private TextMeshProUGUI interactText;

    private PlayerController _player;

    private void Awake()
    {
        targetLayor = LayerMask.GetMask("Player");
        interactText = transform.GetComponentInChildren<TextMeshProUGUI>(true);
        interactText.gameObject.SetActive(false);
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

    public void LoadMinigame()
    {
        SceneLoader.Instance.LoadScene(scneneNum);
    }

    public void OnInteract(PlayerController player)
    {
        _player = player;
        LoadMinigame();
    }
}
