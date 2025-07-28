using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class RidingController : MonoBehaviour
{
    private ResourceController playerResourceController;
    private StatHandler mountStat;
    private AnimationHandler mountAnimationHandler;
    private SpriteRenderer mountSprite;

    public GameObject mountObj;

    [SerializeField] private float spriteDist = 0.6f;

    public bool IsRide { get; set; } = false;

    private int originSpeed = 0;

    private void Awake()
    {
        playerResourceController = FindObjectOfType<PlayerController>().GetComponent<ResourceController>();
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
        // 탑승물 활성화
        mountObj.SetActive(true);
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
