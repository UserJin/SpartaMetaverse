using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour, IInteractable
{
    // �̵��Ϸ��� �� �ѹ�
    [SerializeField] int scneneNum;
    // �÷��̾� ���̾�
    [SerializeField] LayerMask targetLayor;
    // UI
    private TextMeshProUGUI entranceText;

    private void Awake()
    {
        targetLayor = LayerMask.GetMask("Player");
        entranceText = transform.GetComponentInChildren<TextMeshProUGUI>(true);
        entranceText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetLayor.value != (targetLayor | (1 << collision.gameObject.layer)))
            return;

        entranceText.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targetLayor.value != (targetLayor | (1 << collision.gameObject.layer)))
            return;

        entranceText.gameObject.SetActive(false);
    }

    public void LoadMinigame()
    {
        SceneManager.LoadScene(scneneNum);
    }

    public void OnInteract()
    {
        //Debug.Log(gameObject.name);
        LoadMinigame();
    }
}
