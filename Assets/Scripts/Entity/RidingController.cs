using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class RidingController : MonoBehaviour
{
    private ResourceController playerResourceController;
    private BoxCollider2D playerCollider;

    private StatHandler mountStat;
    private SpriteRenderer mountSprite;

    public GameObject mountObj;

    [SerializeField] private float spriteDist = 0.6f;

    public bool IsRide { get; set; } = false;

    private int originSpeed = 0;
    private Vector2 originColiderSize = Vector2.zero;

    private void Awake()
    {
        playerResourceController = FindObjectOfType<PlayerController>().GetComponent<ResourceController>();
        playerCollider = playerResourceController.GetComponent<BoxCollider2D>();
        originColiderSize = playerCollider.size;

        mountStat = mountObj.GetComponent<StatHandler>();
        mountSprite = mountObj.GetComponentInChildren<SpriteRenderer>();
        mountObj.SetActive(false);
        IsRide = false;
    }

    public void ActiveRide()
    {
        IsRide = true;
        // 플레이어 애니메이션 비활성화
        playerResourceController.ToggleAimator();
        // 플레이어 스프라이트 위치변경
        playerResourceController.gameObject.GetComponentInChildren<SpriteRenderer>().gameObject.transform.position += new Vector3(0, spriteDist, 0);
        // 플레이어 콜라이더 크기 변경
        playerCollider.size = new Vector2(playerCollider.size.x, 2);
        // 탑승물 활성화
        mountObj.SetActive(true);
        mountSprite.flipX = playerResourceController.GetComponentInChildren<SpriteRenderer>().flipX;
        // 스탯 변경
        originSpeed = playerResourceController.GetSpeed();
        playerResourceController.SetSpeed(mountStat.Speed);
    }

    public void DeactiveRide()
    {
        IsRide = false;
        // 플레이어 애니메이션 활성화
        playerResourceController.ToggleAimator();
        // 플레이어 스프라이트 원위치
        playerResourceController.gameObject.GetComponentInChildren<SpriteRenderer>().gameObject.transform.position -= new Vector3(0, spriteDist, 0);
        // 플레이어 콜라이더 크기 변경
        playerCollider.size = originColiderSize;
        // 탑승물 활성화
        mountObj.SetActive(false);
        // 스탯 변경
        playerResourceController.SetSpeed(originSpeed);
    }

    public void SetMountFlip(Vector2 dir)
    {
        if (dir.x != 0)
            mountSprite.flipX = dir.x < 0 ? true : false;
    }
}
