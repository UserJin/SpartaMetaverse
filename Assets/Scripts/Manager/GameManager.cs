using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController player {  get; private set; }
    private ResourceController _playerResourceController;

    public static bool isFirstLoading = true;

    private void Awake()
    {
        Instance = this;

        player = FindFirstObjectByType<PlayerController>();
        player.Init(this);
    }
}
