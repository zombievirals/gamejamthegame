using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {
    //hit flash references
    public bool flashActive;
    public float flashLength;
    private float flashCounter;
    

    void Update()
    {
        if (flashActive)
        {
            flash();
        }
    }


    void flash()
    {

        Debug.Log("Hit flash!!");
        if (flashCounter > flashLength * .66f)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
        else if (flashCounter > flashLength * .33f)
        {
            Debug.Log("Hit flash2!!");
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
        else if (flashCounter > 0)
        {
            Debug.Log("Hit flash3!!");
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
        else
        {
            Debug.Log("Hit flash4!!");
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            flashActive = false;
            

        }

        flashCounter -= Time.deltaTime;
    }
}
