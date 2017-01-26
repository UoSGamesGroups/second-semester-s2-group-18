using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public KeyCode MoveUp, MoveDown, MoveLeft, MoveRight;
    public float Speed, MaxSpeed;
    const float SpeedMultipler = 100; // This is used because Time.deltaTime produces a very low number.

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(MoveUp))
        {
            transform.position += Vector3.up * Speed * Time.deltaTime;
        }
        if (Input.GetKey(MoveDown))
        {
            transform.position += Vector3.down * Speed * Time.deltaTime;
        }
        if (Input.GetKey(MoveRight))
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;
        }
        if (Input.GetKey(MoveLeft))
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }
    }
}
