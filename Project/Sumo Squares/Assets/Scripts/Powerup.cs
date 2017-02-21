using UnityEngine;

/// <summary>
/// This is the abstract powerup class that should be implemented by all powerup types.
/// </summary>
public abstract class Powerup : MonoBehaviour
{
    /// <summary>
    /// The rate at which the gameobject will rotate.
    /// </summary>
    public float PassiveRotateSpeed;

    // Use this for initialization
    void Start()
    {
        PowerupManager.Instance.AvailablePowerups.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 200 * PassiveRotateSpeed * Time.deltaTime);
    }

    /// <summary>
    /// This method should implement the functionality of what happens when a player consumes (picks up) a powerup.
    /// </summary>
    /// <param name="player">The player picking up the powerup.</param>
    public abstract void Consume(GameObject player);
}