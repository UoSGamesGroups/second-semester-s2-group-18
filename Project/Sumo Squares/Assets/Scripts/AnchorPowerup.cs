using UnityEngine;

/// <summary>
/// This powerup should freeze the player in place for a set amount of time.
/// </summary>
public class AnchorPowerup : Powerup
{
    /// <summary>
    /// The duration for which the player is frozen.
    /// </summary>
    public float Duration;

    public override void Consume(GameObject player)
    {
        Debug.Log("Player  " + player.name + " ate an anchor powerup: " + gameObject.name);
        PowerupManager.Instance.AvailablePowerups.Remove(this);
        player.GetComponent<PlayerMovement>().Freeze(Duration);
        Destroy(gameObject);
    }
}