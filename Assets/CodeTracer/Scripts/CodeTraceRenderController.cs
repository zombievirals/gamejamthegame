public class CodeTraceRenderController : RenderController
{
    private void LateUpdate()
    {
        Tick(GameState.IsCodeTracerActive());
    }
}