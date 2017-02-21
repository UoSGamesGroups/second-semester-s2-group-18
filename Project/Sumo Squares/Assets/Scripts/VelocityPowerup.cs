using UnityEngine;

public class VelocityPowerup : Powerup
{
    /// <summary>
    /// How much the picking up players acceleration and max velocity is increased.
    /// </summary>
    public float VelocityMultiplyFactor;

    public override void Consume(GameObject player)
    {
        Debug.Log("Player  " + player.name + " ate a velocity powerup: " + gameObject.name);
        PowerupManager.Instance.AvailablePowerups.Remove(this);
        player.GetComponent<PlayerMovement>().PlayerVelocity *= VelocityMultiplyFactor;
        player.GetComponent<PlayerMovement>().MaxVelocity *= VelocityMultiplyFactor;
        player.GetComponent<PlayerMovement>().BoostVelocityMultiplier *= VelocityMultiplyFactor;
        Destroy(gameObject);
    }
}