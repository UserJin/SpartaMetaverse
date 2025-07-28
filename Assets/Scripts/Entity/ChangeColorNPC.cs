using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeColorNPC : MonoBehaviour, IInteractable
{
    // 플레이어 레이어
    [SerializeField] LayerMask targetLayor;
    // UI
    private TextMeshProUGUI interactText;

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

    public void OnInteract(PlayerController player)
    {
        ChangeColor(player);
    }

    private void ChangeColor(PlayerController player)
    {
        SpriteRenderer sr = player.gameObject.GetComponentInChildren<SpriteRenderer>();

        sr.color = new Color(Random.value, Random.value, Random.value);
    }
}
