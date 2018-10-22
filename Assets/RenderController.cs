using UnityEngine;
using UnityEngine.UI;

public class RenderController : MonoBehaviour
{
    public Renderer[] Renderers;
    public Text[] Texts;
    public bool Enabled;

    private void Awake()
    {
        Renderers = gameObject.GetComponentsInChildren<Renderer>();
        Texts = gameObject.GetComponentsInChildren<Text>();
        Enabled = true;
    }

    protected void Tick(bool enable)
    {
        if (enable == Enabled)
            return;
        
        for (int i = 0; i < Renderers.Length; i++)
            Renderers[i].enabled = enable;
        
        var alpha = enable ? 1.0f : 0.0f;
        for (int n = 0; n < Texts.Length; n++)
        {
            var color = Texts[n].color;
            color.a = alpha;
            Texts[n].color = color;
        }
            
        Enabled = enable;
    }
}