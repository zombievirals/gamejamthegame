using UnityEngine;

public class GameSwitcher : MonoBehaviour
{
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			SwitchGame();
	}
    public void SwitchGame()
    {
	    switch (GameState.CurrentGame)
	    {
		    case GameState.BlockDistState:
		    {
			    GameState.CurrentGame = GameState.CodeTraceState;
			    break;
		    }
		    case GameState.CodeTraceState:
		    {
			    GameState.CurrentGame = GameState.BlockDistState;
			    break;
		    }
	    }
    }
}
