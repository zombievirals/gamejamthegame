using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private string codeWordInput;
    private string theCodeWord;
    public InputField codeInputField;

    public GameObject codeTextObject;

    private float fallSpeed = 1.0f;

    //[SerializeField]
    private string[] newCodeWord = new string[4]
      {
            "coding",
            "your",
            "own",
            "games"
      };

    private int i = 0;
    private Vector3 startPos = new Vector3 (30,200,0);

    public void OnTextChanged(string codeInput)
    {
        codeWordInput = codeInput;

    }


    public void Start()
    {
        RectTransform myRectTransform = codeTextObject.GetComponent<RectTransform>();
        SetCodeWord();
    }

    public void Update()
    {
        RectTransform myRectTransform = codeTextObject.GetComponent<RectTransform>();
        myRectTransform.localPosition += Vector3.down * fallSpeed;

        if (codeWordInput == newCodeWord[i]) //code which checks if the word user types matches the word falling
        {
            if (i >= newCodeWord.Length - 1)
            {
                i = 0;
            }
            else
            {
                i += 1;
            }

            SetCodeWord();
            GameState.CodeCombo += 1;
            myRectTransform.localPosition = startPos;
            fallSpeed += 0.2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {

           
            if (i >= newCodeWord.Length - 1)
            {
                i = 0;
            }
            else
            {
                i += 1;
            }

            SetCodeWord();
            GameState.CodeCombo = 0;
            RectTransform myRectTransform = codeTextObject.GetComponent<RectTransform>();
            myRectTransform.localPosition = startPos;
        }

    }

    public void SetCodeWord()
    {
        Text codeWord = codeTextObject.GetComponent<Text>();
        codeWord.text = newCodeWord[i];
        codeInputField.text = "";
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        string text = string.Format("COMBO: " + GameState.CodeCombo);
        GUI.Label(rect, text, style);
    }


}