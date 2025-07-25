using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArrowAvoid
{
    public class Arrow : MonoBehaviour
    {
        float _speed;
        public void Init(float speed)
        {
            _speed = speed;
        }

        private void Update()
        {
            if(transform.position.y < -8f)
            {
                GameManager.Instance.AddScore(1);
                Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            transform.Translate(new Vector3(0, -_speed * Time.fixedDeltaTime, 0));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.CompareTag("Player"))
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
