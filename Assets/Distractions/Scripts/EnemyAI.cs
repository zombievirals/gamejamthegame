using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public static float DIFFICULTY;

    public GameObject Player;
    public  float EnemyMoveSpeed = 2f;

    public AudioClip[] enemyXplode; 
    public AudioSource source;

    private GameObject camAnim;

    private Animator anim;

	
	void Start () {
       
     Player = GameObject.FindGameObjectWithTag("Player");
     camAnim = GameObject.FindGameObjectWithTag("MainCamera");
        
     anim = camAnim.GetComponent<Animator>();


    }
	
	
	void Update () {
        
        Vector2 enemyPos2d = transform.position;
        Vector2 playerPos2d = Player.transform.position;

        Vector2 difference = playerPos2d - enemyPos2d + new Vector2(0.5f,0.5f);

        transform.Translate(difference.normalized * EnemyMoveSpeed * Time.fixedDeltaTime);          

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            anim.SetTrigger("ScreenShake");
            int whichSound2 = Random.Range(0, 1);
            source.PlayOneShot(enemyXplode[whichSound2]);
            Destroy(gameObject);
        }

    }

}
