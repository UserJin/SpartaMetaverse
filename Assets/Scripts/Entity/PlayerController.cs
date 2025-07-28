using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private GameManager gameManager;
    private ResourceController resourceController;
    private RidingController ridingController;

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        resourceController = GetComponent<ResourceController>();
        ridingController = GetComponent<RidingController>();
    }

    protected override void HandleAction()
    {

    }

    void OnMove(InputValue inputValue)
    {
        moveDirection = inputValue.Get<Vector2>().normalized;
        if (ridingController.IsRide) ridingController.SetMountFlip(MoveDirection);
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
                interactableObj.OnInteract(this);
            }
        }
    }

    void OnRide()
    {
        if(ridingController.IsRide)
            ridingController.DeactiveRide();
        else
            ridingController.ActiveRide();
    }
}
