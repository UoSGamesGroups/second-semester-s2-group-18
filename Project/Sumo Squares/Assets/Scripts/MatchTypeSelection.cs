using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTypeSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGameToBestOf5()
    {
        LevelController.BestOf5 = true;
    }

    public void SetGameToBestOf3()
    {
        LevelController.BestOf5 = false;
    }
}
