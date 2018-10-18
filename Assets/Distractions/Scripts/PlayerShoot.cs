using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public GameObject bullet;
    public float bulletSpeed;
    public float coolDownPeriodInSeconds;
    private float timeStamp;

    public AudioClip[] gunShot;
    public AudioSource source;

	
	void Update () {       
        GetInputForShooting();	
	}


    void GetInputForShooting()
    {
        if (timeStamp <= Time.time)
        {
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    createBullet(4); //up right diagonal shot
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    createBullet(6); //down right diagonal shot
                }
                else
                {
                    createBullet(0); //regular right shot
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    createBullet(5); //up left diagonal shot
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    createBullet(7); //down left diagonal shot
                }
                else
                {
                    createBullet(1); //regular left shot
                }
                
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
                {
                    return; //do nothing as this is already handled
                }
                else
                {
                    createBullet(2); //regular up shot
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
                {
                    return; //do nothing as this is already handled
                }
                else
                {
                    createBullet(3); //regular down shot
                }
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }


           
        
        }
    }

    void createBullet(int dir)
    {
        GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);

        int whichSound = Random.Range(0, 3);
        

        source.PlayOneShot(gunShot[whichSound]);

        if (dir == 0) //shoot right
        {
            bulletInstance.GetComponent<Bullet>().speed = Vector2.right * bulletSpeed;
        }
        else if (dir == 1) //shoot left
        {
            bulletInstance.GetComponent<Bullet>().speed = Vector2.left * bulletSpeed;
        }
        else if (dir == 2) //shoot up
        {
            bulletInstance.GetComponent<Bullet>().speed = Vector2.up * bulletSpeed;
        }
        else if (dir == 3) //shoot down
        {
            bulletInstance.GetComponent<Bullet>().speed = Vector2.down * bulletSpeed;
        }

 ///code for diagonal shooting that I would like to keep separate
        if (dir == 4) // shoot up+right
        {
            bulletInstance.GetComponent<Bullet>().speed = new Vector2(1,1) * bulletSpeed;
        }

        else if (dir == 5) //shoot up+left
        {
            bulletInstance.GetComponent<Bullet>().speed = new Vector2(-1, 1) * bulletSpeed;
        }

        else if (dir == 6) // shoot down+right
        {
            bulletInstance.GetComponent<Bullet>().speed = new Vector2(1, -1) * bulletSpeed;
        }

        else if (dir == 7) // shoot down+left
        {
            bulletInstance.GetComponent<Bullet>().speed = new Vector2(-1, -1) * bulletSpeed;
        }


        timeStamp = Time.time + coolDownPeriodInSeconds;
    }

}
