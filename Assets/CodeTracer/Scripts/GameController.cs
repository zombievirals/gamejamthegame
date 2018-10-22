using UnityEngine;
using UnityEngine.UI;

namespace CodeTracer
{
    public class GameController : MonoBehaviour
    {
        private static readonly string[] Words = {
            "coding",
            "your",
            "own",
            "games",
            "is",
            "easier",
            "than",
            "you",
            "think",
            "you",
            "know",
            "you",
            "should",
            "try",
            "this",
            "online",
            "unity",
            "course",
            "on",
            "udemy",
            "it",
            "is",
            "taught",
            "by",
            "a",
            "software",
            "engineer",
            "and",
            "a",
            "game",
            "developer",
            "who",
            "are",
            "both",
            "expert",
            "instructors"
        };
        
        public float WordFallSpeed = 1.1f;
        public Vector3 StartPosition = new Vector3(30, 200, 0);
    
        public InputField InputField;
        public RectTransform TextTransform;
        
        private int _currentWordPtr = 0;
        private GUIStyle _style;
        private Rect _guiRect;
        
        public void OnTextChanged(string codeInput)
        {
            // If I typed too many letters, cut it down to the relevant length.
            if (codeInput.Length > Words[_currentWordPtr].Length)
                codeInput = codeInput.Substring(0, Words[_currentWordPtr].Length);

            // Check through each char and cut it off where the chars are incorrect.
            for (var i = 0; i < codeInput.Length; i++)
            {
                if (codeInput[i] == Words[_currentWordPtr][i])
                    continue;

                codeInput = i == 0 ? "" : codeInput.Substring(0, i);
            }

            InputField.text = codeInput;

            // Reset the word if you got it right.
            if (codeInput == Words[_currentWordPtr])
            {
                GameState.CodeCombo += 1;
                NextWord();
            }
        }


        public void Start()
        {
            SetWord();
            _style = new GUIStyle
            {
                alignment = TextAnchor.UpperRight, 
                fontSize = Screen.height * 2 / 50, 
                normal = { textColor = Color.yellow }
            };
            _guiRect = new Rect(0, 0, Screen.width, Screen.height * 2 / 100f);
        }

        public void Update()
        {
            if (InputField.isFocused && !GameState.IsCodeTracerActive())
                InputField.DeactivateInputField();
            else if (!InputField.isFocused && GameState.IsCodeTracerActive())
                InputField.ActivateInputField();
                
            TextTransform.localPosition += Vector3.down * WordFallSpeed * GameState.CodeTraceDeltaTime();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameState.CodeCombo = 0;
            NextWord();
        }

        private void OnGUI()
        {
            GUI.Label(_guiRect, string.Format("COMBO: " + GameState.CodeCombo), _style);
        }

        private void LateUpdate()
        {
            InputField.interactable = GameState.IsCodeTracerActive();
            
        }
        
        private void SetWord ()
        {
            var codeWord = TextTransform.GetComponent<Text>();
            codeWord.text = Words[_currentWordPtr];
            InputField.text = "";
        }

        private void NextWord ()
        {
            if (_currentWordPtr >= Words.Length - 1)
                _currentWordPtr = 0;
            else
                _currentWordPtr += 1;
            SetWord();
            TextTransform.localPosition = StartPosition;
        }
    }
}