using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMovement : MonoBehaviour {

    public KeyCode MoveUp, MoveDown, MoveLeft, MoveRight;
    public KeyCode BoostKey;
    public float PlayerVelocity, MaxVelocity, BoostVelocityMultiplier;
    private float boostMaxVelocityMultiplier;
    public float StaminaRegenRate, StaminaDrainRate;

    private Rigidbody2D rb;
    private PlayerStats pstats;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pstats = GetComponent<PlayerStats>();
        boostMaxVelocityMultiplier = BoostVelocityMultiplier * MaxVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (pstats.GetStamina() < PlayerStats.MaxStamina && !Input.GetKey(BoostKey))
        {
            pstats.SetStamina(Mathf.Min(pstats.GetStamina() + StaminaRegenRate, PlayerStats.MaxStamina));
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(MoveUp))
        {
            Move(Vector2.up);
        }
        if (Input.GetKey(MoveDown))
        {
            Move(Vector2.down);
        }
        if (Input.GetKey(MoveRight))
        {
            Move(Vector2.right);
        }
        if (Input.GetKey(MoveLeft))
        {
            Move(Vector2.left);
        }
    }

    void Move(Vector2 direction)
    {
        // Multiply forces added by 1000 to make up for the deltatime, since it's such a tiny number.
        if (Input.GetKey(BoostKey) && pstats.GetStamina() > 0 + float.Epsilon)
        {
            rb.AddForce(direction * PlayerVelocity * BoostVelocityMultiplier * 1000 * Time.deltaTime);
            pstats.SetStamina(pstats.GetStamina() - StaminaDrainRate);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, boostMaxVelocityMultiplier);
        }
        else
        {
            rb.AddForce(direction * PlayerVelocity * 1000 * Time.deltaTime);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxVelocity);
        }


    }
}
