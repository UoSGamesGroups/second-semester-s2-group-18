using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// TODO: Consider using singleton design pattern.
/// <summary>
/// Controller for the current level.
/// </summary>
[RequireComponent(typeof(CircleCollider2D))]
public class LevelController : MonoBehaviour
{
    /// <summary>
    /// A list of current players in the match.
    /// </summary>
    public static List<GameObject> CurrentPlayers;

    /// <summary>
    /// The current running state of the match.
    /// </summary>
    public static bool MatchActive;

    // Use this for initialization
    void Start()
    {
        MatchActive = true;
        CurrentPlayers = GameObject.FindGameObjectsWithTag("Player").ToList();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Kill(coll.gameObject);
        }
    }

    /// <summary>
    /// Should be called when a player should be removed from the game.
    /// </summary>
    /// <param name="player">The player to kill.</param>
    public static void Kill(GameObject player)
    {
        if (player.transform.childCount > 0)
        {
            player.transform.DetachChildren();
        }
        Destroy(player.gameObject);
        CurrentPlayers.Remove(player.gameObject);
        MatchActive = false;
    }
}