using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public float PassiveRotateSpeed;

	// Use this for initialization
	void Start () {
        PowerupManager.Instance.Powerups.Add(this);
        print("Added new powerup! Current number of powerups is " + PowerupManager.Instance.Powerups.Count);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 200 * Time.deltaTime);
	}

    public void Consume(GameObject player)
    {
        // Code here to do what happens.
        print(player.name + " picked up a powerup named " + this.gameObject.name);
        Destroy(this.gameObject);
    }
}
