using System.Collections;
using UnityEngine;

/// <summary>
/// The main player movement controller.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMovement : MonoBehaviour
{
    public KeyCode MoveUp, MoveDown, MoveLeft, MoveRight;
    public KeyCode BoostKey;
    public float PlayerVelocity, MaxVelocity, BoostVelocityMultiplier;

    /// <summary>
    /// The max velocity multiplier whilst boosting is derived from the current max velocity and the boost velocity
    /// multiplier.
    /// </summary>
    private float _boostMaxVelocityMultiplier;

    /// <summary>
    /// The rate at which stamina regenerates passively.
    /// </summary>
    public float StaminaRegenRate;

    /// <summary>
    /// The rate at which stamina drains whilst the player uses the boost key.
    /// </summary>
    public float StaminaBoostDrainRate;

    private Rigidbody2D _rb;
    private PlayerStats _pstats;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pstats = GetComponent<PlayerStats>();
        _boostMaxVelocityMultiplier = BoostVelocityMultiplier * MaxVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (_pstats.GetStamina() < PlayerStats.MaxStamina && !Input.GetKey(BoostKey))
        {
            _pstats.SetStamina(Mathf.Min(_pstats.GetStamina() + StaminaRegenRate, PlayerStats.MaxStamina));
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
        // Problem with below code is that it means that after getting pushed by an opponent, not much really happens
        // if you're not holding any keys. :(
//        if (!Input.GetKey(MoveUp) || !Input.GetKey(MoveDown) || !Input.GetKey(MoveLeft) || !Input.GetKey(MoveRight))
//        {
//            if (_rb.velocity.magnitude > float.Epsilon)
//            {
//                _rb.velocity = _rb.velocity * 0.9f;
//            }
//        }
    }

    /// <summary>
    /// Moves the player in the given direction, whilst making sure the velocity doesn't exceed the max velocity.
    /// </summary>
    /// <param name="direction">Direciton to move the player.</param>
    void Move(Vector2 direction)
    {
        // Multiply forces added by 1000 to make up for the deltatime, since it's such a tiny number.
        if (Input.GetKey(BoostKey) && _pstats.GetStamina() > 0 + float.Epsilon)
        {
            _rb.AddForce(direction * PlayerVelocity * BoostVelocityMultiplier * 1000 * Time.deltaTime, ForceMode2D.Impulse);
            _pstats.SetStamina(_pstats.GetStamina() - StaminaBoostDrainRate);
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, _boostMaxVelocityMultiplier);
        }
        else
        {
            _rb.AddForce(direction * PlayerVelocity * 1000 * Time.deltaTime, ForceMode2D.Impulse);
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, MaxVelocity);
        }
    }

    public void Freeze(float duration)
    {
        StartCoroutine(FreezePlayer(duration));
    }

    /// <summary>
    /// Constrains translation and rotation of the player for the given duration.
    /// </summary>
    /// <param name="player">The player to be constrained</param>
    /// <param name="duration">The duration for the player to be constrained.</param>
    /// <returns></returns>
    private IEnumerator FreezePlayer(float duration)
    {
        Debug.Log("Frozen player: " + name + " at " + Time.time);
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;

        Debug.Log(duration);
        yield return new WaitForSeconds(duration);

        Debug.Log("Unfroze player: " + name + " at " + Time.time);
        _rb.constraints = RigidbodyConstraints2D.None;
    }
}