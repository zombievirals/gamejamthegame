using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    private float _deltaTime = 0.0f;
    private GUIStyle _style;
    private Rect _guiRect;

    private void Start()
    {
        _style = new GUIStyle
        {
            alignment = TextAnchor.UpperLeft,
            fontSize = Screen.height * 2 / 50,
            normal = {textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f)}
        };

        _guiRect = new Rect(0, 0, Screen.width, Screen.height * 2 / 100f);
    }

    private void Update()
    {
        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        var msec = _deltaTime * 1000.0f;
        var fps = 1.0f / _deltaTime;
        var text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(_guiRect, text, _style);
    }
}