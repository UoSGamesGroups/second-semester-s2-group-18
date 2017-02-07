using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PowerupManager : MonoBehaviour {
    private static readonly PowerupManager instance = new PowerupManager();
    public List<Powerup> Powerups;

    static PowerupManager() { }
    private PowerupManager() {
        Powerups = new List<Powerup>();
    }

    public static PowerupManager Instance
    {
        get
        {
            return instance;
        }
    }



}
