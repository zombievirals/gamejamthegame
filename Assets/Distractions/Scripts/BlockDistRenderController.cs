namespace Distractions
{
    public class BlockDistRenderController : RenderController
    {
        private void LateUpdate()
        {
            Tick(GameState.IsBlockDistractionsActive());
        }
    }
}