using UnityEngine;

namespace Distractions
{
    public class DistractionEnemy : MonoBehaviour
    {
        // Inspector attributes
        public float EnemyMoveSpeed = 2f;
        public AudioClip[] DeathSounds;
        
        // Work vars
        private GameObject _plr;
        private AudioSource _audio;
        private Animator _cameraAnim;
        
    	private void Start ()
	    {
            _plr = GameObject.FindGameObjectWithTag("Player");
	        _audio = _plr.GetComponent<AudioSource>();
            _cameraAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        }
        
    	private void FixedUpdate ()
	    {
            Vector2 myPos = transform.position;
            Vector2 target = _plr.transform.position;
    
            var difference = target - myPos + new Vector2(0.01f, 0);
            transform.Translate(difference.normalized * EnemyMoveSpeed * Time.fixedDeltaTime);
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Bullet"))
                return;
            
            _cameraAnim.SetTrigger("ScreenShake");
            _audio.PlayOneShot(DeathSounds[Random.Range(0, DeathSounds.Length - 1)]);
            Destroy(gameObject);
        }
    }
}
