using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpecialFloorType
{
    None,
    Ice,
    Lava,
    Swamp,
    Sand
}

public class SpecialFloor : MonoBehaviour {
    public SpecialFloorType type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            switch (type)
            {
                case SpecialFloorType.Ice:
                    collision.gameObject.GetComponent<Rigidbody2D>().mass *= 0.8f;
                    break;
                case SpecialFloorType.Swamp:
                    collision.gameObject.GetComponent<Rigidbody2D>().mass *= 5.4f;
                    break;
                case SpecialFloorType.Lava:
                    LevelController.Kill(collision.gameObject);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (type)
            {
                case SpecialFloorType.Ice:
                    collision.gameObject.GetComponent<Rigidbody2D>().mass /= 0.8f;
                    break;
                case SpecialFloorType.Swamp:
                    collision.gameObject.GetComponent<Rigidbody2D>().mass /= 5.4f;
                    break;
            } 
        }
    }
}
