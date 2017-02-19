using UnityEngine;

/// <summary>
/// The main player class.
/// </summary>
public class Player : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            print("Touched a powerup");
            other.GetComponent<Powerup>().Consume(gameObject);
        }
    }
}