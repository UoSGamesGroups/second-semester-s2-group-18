using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMovement : MonoBehaviour {

    public KeyCode MoveUp, MoveDown, MoveLeft, MoveRight;
    public KeyCode BoostKey;
    public float Speed, MaxSpeed, BoostMaxSpeedMultiplier, BoostSpeedMultiplier;
    public float StaminaRegenRate, StaminaDrainRate;
    private const float SpeedMultipler = 1000; // This is used because Time.deltaTime produces a very low number.

    private Rigidbody2D rb;
    private PlayerStats pstats;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pstats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pstats.GetStamina() < PlayerStats.MaxStamina && !Input.GetKey(BoostKey))
        {
            pstats.SetStamina(Mathf.Min(pstats.GetStamina() + StaminaRegenRate, PlayerStats.MaxStamina));
        }
        Debug.Log(pstats.GetStamina());
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
        if (Input.GetKey(BoostKey) && pstats.GetStamina() > 0 + float.Epsilon)
        {
            if (rb.velocity.sqrMagnitude < MaxSpeed * MaxSpeed * BoostMaxSpeedMultiplier)
            {
                rb.AddForce(direction * Speed * SpeedMultipler * BoostSpeedMultiplier * Time.deltaTime);
                pstats.SetStamina(pstats.GetStamina() - StaminaDrainRate);
            }
        }
        else
        {
            if (rb.velocity.sqrMagnitude < MaxSpeed * MaxSpeed)
            {
                rb.AddForce(direction * Speed * SpeedMultipler * Time.deltaTime);
            }
        }

    }
}
