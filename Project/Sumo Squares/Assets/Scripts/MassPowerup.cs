using UnityEngine;

// TODO: Determine whether or not the mass increase should be permanent or temporary.
/// <summary>
/// This powerup will increase the player's mass.
/// </summary>
public class MassPowerup : Powerup
{
    /// <summary>
    /// How much the picking up players mass is increased.
    /// </summary>
    public float MassMultiplyFactor;

    public override void Consume(GameObject player)
    {
        Debug.Log("Player  " + player.name + " ate a mass powerup: " + gameObject.name);
        PowerupManager.Instance.AvailablePowerups.Remove(this);
        player.GetComponent<Rigidbody2D>().mass *= MassMultiplyFactor;
        Destroy(gameObject);
    }
}