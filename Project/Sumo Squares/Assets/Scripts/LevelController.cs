using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class LevelController : MonoBehaviour
{
    public static List<GameObject> CurrentPlayers;
    public static bool GameActive;
	// Use this for initialization
	void Start () {
        GameActive = true;
	    CurrentPlayers = GameObject.FindGameObjectsWithTag("Player").ToList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            if (collider.transform.childCount > 0)
            {
                collider.transform.DetachChildren();
            }
            Destroy(collider.gameObject);
            CurrentPlayers.Remove(collider.gameObject);
            GameActive = false;
        }
    }
}
