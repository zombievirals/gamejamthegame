using UnityEngine;

namespace Distractions
{
    public class DistractionEnemy : MonoBehaviour
    {
        // Inspector attributes
        public float EnemyMoveSpeed = 2f;
        
        // Work vars
        private GameObject _plr;
        private SpriteRenderer _sprite;
        
    	private void Start ()
	    {
            _plr = GameObject.FindGameObjectWithTag("Player");
		    _sprite = GetComponent<SpriteRenderer>();
	    }
        
    	private void FixedUpdate ()
	    {
            Vector2 myPos = transform.position;
            Vector2 target = _plr.transform.position;
    
            var difference = target - myPos + new Vector2(0.01f, 0);
            transform.Translate(difference.normalized * EnemyMoveSpeed * GameState.BlockDistDeltaTime());
        }

	    private void LateUpdate()
	    {
		    _sprite.enabled = GameState.IsBlockDistractionsActive();
	    }
    }
}
