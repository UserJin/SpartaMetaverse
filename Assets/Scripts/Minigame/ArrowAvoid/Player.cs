using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrowAvoid
{
    public class Player : MonoBehaviour
    {
        Rigidbody2D rb;
        SpriteRenderer spriteRenderer;
        Animator animator;

        [SerializeField] int xMax;
        [SerializeField] int xMin;

        [SerializeField] float speed;

        Vector2 movement;

        float horizontal;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            HandleInput();
            LookForward();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void HandleInput()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        private void Move()
        {
            movement = new Vector2(horizontal * speed, 0);
            rb.velocity = movement;
            if(movement != Vector2.zero)
                animator.SetBool("IsMove", true);
            else
                animator.SetBool("IsMove", false);
        }

        private void LookForward()
        {
            if (horizontal > 0)
                spriteRenderer.flipX = false;
            else if (horizontal < 0)
                spriteRenderer.flipX = true;
        }
    }
}
