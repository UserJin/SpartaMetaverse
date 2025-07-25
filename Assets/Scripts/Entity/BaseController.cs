using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] SpriteRenderer spriteRenderer;

    protected Vector2 moveDirection;
    public Vector2 MoveDirection { get { return moveDirection; } }

    protected AnimationHandler animationHandler;
    protected StatHandler statHandler;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
    }

    protected virtual void FixedUpdate()
    {
        Movement(moveDirection);
    }

    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction)
    {
        direction = direction * statHandler.Speed;

        _rigidbody.velocity = direction;
        Rotate(direction);
        animationHandler.Move(direction);
    }

    private void Rotate(Vector2 dir)
    {
        if(dir.x != 0)
            spriteRenderer.flipX =  dir.x <0 ? true : false;
    }
}
