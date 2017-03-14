using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MatchEndScreen : MonoBehaviour
{
    public static string WinningPlayer;
    public Text winnerText;

	// Use this for initialization
	void Start ()
	{
	    winnerText.text += WinningPlayer;
	    winnerText.text += " Wins!";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
