using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MatchEndScreen : MonoBehaviour
{
    public static string WinningPlayer;

    public Sprite Player1Wins, Player2Wins;
    public GameObject Backdrop;

	// Use this for initialization
	void Start ()
	{   
        if(WinningPlayer == "Player 1")
        {
            Backdrop.GetComponent<Image>().sprite = Player1Wins;
        }

        if(WinningPlayer == "Player 2")
        {
            Backdrop.GetComponent<Image>().sprite = Player2Wins;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
