using UnityEngine;

namespace Distractions
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        public Vector2 Velocity;
        public float Lifetime = 3f;
    
        private void Start()
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = Velocity;
            Destroy(gameObject, Lifetime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall"))
                Destroy(gameObject);
        }
    } 
}