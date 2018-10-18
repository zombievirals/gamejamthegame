using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class EightDirection : MonoBehaviour {
    //movement variables
    public float moveSpeed;
    private Rigidbody2D rb;
    private float horMov;
    private float vertMov;

    //hitflash variables
    public bool flashActive;
    public float flashLength;
    private float flashCounter;

    //other variables
    static float LIFE = 0f;

  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        flashCounter = flashLength;
    }

   
    void FixedUpdate()
    {
        horMov = Input.GetAxisRaw("Horizontal");
        vertMov = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(horMov * moveSpeed, vertMov * moveSpeed, 0);

        if (flashActive)
        {
            flash();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            flashActive = true;
            LIFE -= 1.0f;
            //Debug.Log(LIFE);
        }

    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        string text = string.Format("LIFE: " + LIFE);
        GUI.Label(rect, text, style);
    }

    void flash()
    {
        
        if (flashCounter > flashLength * .66f)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
        else if (flashCounter > flashLength * .33f)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
        else if (flashCounter > 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            flashActive = false;
            flashCounter = flashLength;
        }
        flashCounter -= Time.deltaTime;
    }
}


