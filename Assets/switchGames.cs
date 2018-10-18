using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchGames : MonoBehaviour {

    public GameObject blockDistractions;
    public GameObject codeTracers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void switchGame()
    {
        Debug.Log("Switch game!");
        if (GameState.currentGame == 1)
        {
            GameState.currentGame = 2;
            blockDistractions.gameObject.SetActive(false);
            codeTracers.gameObject.SetActive(true);
            return;
        }

        if(GameState.currentGame == 2)
        {
            GameState.currentGame = 1;
            blockDistractions.gameObject.SetActive(true);
            codeTracers.gameObject.SetActive(false);
            return;
        }


    }

}
