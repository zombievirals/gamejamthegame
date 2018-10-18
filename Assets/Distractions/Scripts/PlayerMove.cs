using Starry2D;
using UnityEngine;

namespace Distractions
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : PhysicsBody2D
    {
        // Inspector Attributes
        public float MoveSpeed = 5;
        public float FlashDuration = 0.5f;
        public int FlashCount = 5;
        public float FlashAlpha = 0.5f;
        
        // Hitflash work vars
        private bool _flashing;
        private float _flashTimer;
        private SpriteRenderer _sprite;
        
        // GUI work vars
        private GUIStyle _style;
        private Rect _guiRect;
      
        private void Start()
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            
            _sprite = GetComponent<SpriteRenderer>();
            
            _style = new GUIStyle
            {
                alignment = TextAnchor.UpperLeft,
                fontSize = Screen.height * 2 / 50,
                normal = { textColor = Color.cyan }
            };
            _guiRect = new Rect(0, 0, Screen.width, Screen.height * 2 / 100f);
        }
    
        protected override void UpdateMotion()
        {
            Velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * MoveSpeed;
        }
    
        private void LateUpdate()
        {
            if (_flashing)
                UpdateFlash();
        }
    
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Enemy"))
                return;
            
            GameState.Time -= Time.fixedDeltaTime / 4f;
            StartFlash();
        }
    
        private void OnGUI()
        {
            var text = string.Format("Time: " + GameState.Time);
            GUI.Label(_guiRect, text, _style);
        }
    
        private void StartFlash()
        {
            if (_flashing)
                return;
            
            _flashing = true;
            _flashTimer = FlashDuration;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    
        private void UpdateFlash()
        {
            if (_flashTimer <= 0)
            {
                _sprite.color = Color.white;
                _flashing = false;
                return;
            }
            
            var intervalTime = FlashDuration / FlashCount;
            var flashTime = _flashTimer % (intervalTime * 2);
            _sprite.color = flashTime > intervalTime ? new Color(1.0f, 1.0f, 1.0f, FlashAlpha) : Color.white;
            _flashTimer -= Time.deltaTime;
        }
    }
}
