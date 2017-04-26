using UnityEngine;

/// <summary>
/// The main player class.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{

    public int RoundsWon;
    private AudioSource audio;

    public AudioClip[] punches;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Touched another player");
            Camera.main.gameObject.GetComponent<CameraShake>().Shake(1000, 1);
            if(!audio.isPlaying)
            {
                int index = Random.Range(0, punches.Length);
                audio.clip = punches[index];
                audio.Play();
            }
        }
    }
}