using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a singleton powerup manager, that keeps track of all current powerups in the game.
/// </summary>
public sealed class PowerupManager : MonoBehaviour
{
    // ReSharper disable once InconsistentNaming
    private static readonly PowerupManager instance = new PowerupManager();

    public List<Powerup> AvailablePowerups;

    static PowerupManager()
    {
    }

    private PowerupManager()
    {
        AvailablePowerups = new List<Powerup>();
    }

    public static PowerupManager Instance
    {
        get { return instance; }
    }
}