using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private GameManager gameManager;

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    protected override void HandleAction()
    {

    }

    void OnMove(InputValue inputValue)
    {
        moveDirection = inputValue.Get<Vector2>().normalized;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.3f);
        Gizmos.DrawCube(transform.position, Vector3.one);

    }

    void OnInteract()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one, 0f, transform.forward, 0f, LayerMask.GetMask("Interactable"));

        IInteractable interactableObj;
        if (hit.collider != null)
        {
            interactableObj = hit.collider.GetComponent<IInteractable>();

            if (interactableObj != null)
            {
                interactableObj.OnInteract();
            }
        }
    }

    void OnRide()
    {
        // 캐릭터의 탑승 여부 확인

        // 탑승 상태가 아니면
        // 탑승 상태 활성화
        // 캐릭터 스프라이트 위로 올리기
        // 탑승물 스프라이트 활성화
        // 캐릭터 속도 변경

        // 탑승 상태라면
        // 탑승 상태 비활성화
        // 캐릭터 스프라이트 원위치
        // 탑승물 스프라이트 비활성화
        // 캐릭터 속도 원상복귀
    }
}
