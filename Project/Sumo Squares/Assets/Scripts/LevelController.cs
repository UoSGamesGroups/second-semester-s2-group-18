using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class LevelController : MonoBehaviour {
    public static bool GameActive;
	// Use this for initialization
	void Start () {
        GameActive = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.name == "Player 1")
            {
                Debug.Log("Player 2 wins!");
            } else
            {
                Debug.Log("Player 1 wins!");
            }
            collision.gameObject.SetActive(false);
            GameActive = false;
        }
    }
}
