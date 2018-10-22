using UnityEngine;
using Random = UnityEngine.Random;

namespace Distractions
{
	public class PlayerShoot : MonoBehaviour
    {
        // Inspector attributes
        public float BulletSpeed;
        public float ShotCooldownSeconds;
        public GameObject BulletPrefab;
        
        // Work vars
        private float _lastShotTime;
    
    	
    	private void Update () {       
    	    if (!GameState.IsBlockDistractionsActive() || _lastShotTime > Time.time)
    	        return;
    
    	    var up = Input.GetKey(KeyCode.UpArrow);
    	    var left = Input.GetKey(KeyCode.LeftArrow);
    	    var down = Input.GetKey(KeyCode.DownArrow);
    	    var right = Input.GetKey(KeyCode.RightArrow);
    
    	    if (right)
    	    {
    	        if (up)
    	            ShootBullet(1);
    	        else if (down)
    	            ShootBullet(7);
    	        else
    	            ShootBullet(0);
    	    }
    	    else if (left)
    	    {
    	        if (up)
    	            ShootBullet(3);
    	        else if (down)
    	            ShootBullet(5);
    	        else
    	            ShootBullet(4);
    	    }
    	    else if (up)
    	        ShootBullet(2);
    	    else if (down)
    	        ShootBullet(6);
    	}
    
        private void ShootBullet(int dir)
        {
            var bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
            AudioSystem.Main.PlayBlockDistBulletShoot();
            var velocity = MathExt.AngleToVec(dir * 45f) * BulletSpeed;
            bullet.Velocity = velocity;
            _lastShotTime = Time.time + ShotCooldownSeconds;
        }
    }
}
