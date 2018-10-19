using UnityEngine;

public class GameSwitcher : MonoBehaviour
{
    public GameObject BlockDistGame;
    public GameObject CodeTraceGame;

    public void SwitchGame()
    {
	    Debug.LogFormat("GameState pre-switch: {0}", GameState.CurrentGame);
	    switch (GameState.CurrentGame)
	    {
		    case GameState.BlockDistState:
		    {
			    GameState.CurrentGame = GameState.CodeTraceState;
			    BlockDistGame.gameObject.SetActive(false);
			    CodeTraceGame.gameObject.SetActive(true);
			    break;
		    }
		    case GameState.CodeTraceState:
		    {
			    GameState.CurrentGame = GameState.BlockDistState;
			    BlockDistGame.gameObject.SetActive(true);
			    CodeTraceGame.gameObject.SetActive(false);
			    break;
		    }
	    }
	    Debug.LogFormat("GameState post-switch: {0}", GameState.CurrentGame);
    }
}
