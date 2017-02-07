using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float Stamina;
    private float ExampleStat;
    private float ExampleStat2;
    public const float MaxStamina = 100;
	// Use t    his for initialization
	void Start ()
	{
	    SetStamina(MaxStamina);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetStamina()
    {
        return Stamina;
    }

    public void SetStamina(float stamina)
    {
        Stamina = stamina;
    }
}
