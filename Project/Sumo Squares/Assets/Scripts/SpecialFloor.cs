using System;
using UnityEngine;

/// <summary>
/// The type of floor.
/// </summary>
public enum SpecialFloorType
{
    None,
    Ice,
    Lava,
    Swamp,
    Sand
}

// TODO: Use inheritance instead of enum and switch case.
public class SpecialFloor : MonoBehaviour
{
    public SpecialFloorType Type;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // TODO: Marsh modify stamina drain rate.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (Type)
            {
                case SpecialFloorType.Ice:
                    collision.gameObject.GetComponent<Rigidbody2D>().mass *= 0.8f;
                    break;
                case SpecialFloorType.Swamp:
                    collision.gameObject.GetComponent<PlayerMovement>().MaxVelocity *= 0.5f;
                    break;
                case SpecialFloorType.Lava:
                    LevelController.Kill(collision.gameObject);
                    break;
                case SpecialFloorType.Sand:
                    break;
                case SpecialFloorType.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (Type)
            {
                case SpecialFloorType.Ice:
                    collision.gameObject.GetComponent<Rigidbody2D>().mass /= 0.8f;
                    break;
                case SpecialFloorType.Swamp:
                    collision.gameObject.GetComponent<PlayerMovement>().MaxVelocity /= 0.5f;
                    break;
                case SpecialFloorType.Lava:
                    break;
                case SpecialFloorType.Sand:
                    break;
                case SpecialFloorType.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}