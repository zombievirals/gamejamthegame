using UnityEngine;

namespace Distractions
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class Bullet : MonoBehaviour
    {
        public Vector2 Velocity;
        public float Lifetime = 3f;

        private SpriteRenderer _sprite;
        private bool _dead;
    
        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            var rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            Destroy(gameObject, Lifetime);
        }

        private void Update()
        {
            Vector3 motion = Velocity * GameState.BlockDistDeltaTime();
            transform.Translate(motion);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_dead)
                return;
            
            if (collision.gameObject.CompareTag("Enemy"))
            {
                PlayerMove.CameraAnim.SetTrigger("ScreenShake");
                AudioSystem.Main.PlayBlockDistEnemyDeath();
                Destroy(collision.gameObject);
                Destroy(gameObject);
                _dead = true;
            }
            else if (collision.gameObject.CompareTag("Wall"))
                Destroy(gameObject);
        }

        private void LateUpdate()
        {
            _sprite.enabled = GameState.IsBlockDistractionsActive();
        }
    } 
}