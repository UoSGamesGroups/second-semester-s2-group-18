using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO: Consider using singleton design pattern.
/// <summary>
/// Controller for the current level.
/// </summary>
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


    // TODO: Refactor this code and clean.
    public static bool BestOf5;

    public static int MaxRounds;
    public static int CurrentRound;

    public static int Player1Rounds;
    public static int Player2Rounds;

    // Use this for initialization
    void Start()
    {
        GetComponent<Timer>().ResetTimer();
        MatchActive = true;
        CurrentPlayers = GameObject.FindGameObjectsWithTag("Player").ToList();
        MaxRounds = BestOf5 ? 3 : 2;
        CurrentRound = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }

        if (GetComponent<Timer>().GetSecondsRemaining() <= float.Epsilon)
        {
            MatchActive = false;
            ProcessRound();
        }
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
        ProcessRound(player);
    }

    private static void ProcessRound(GameObject deadPlayer)
    {
        if (deadPlayer.gameObject.name.Contains("1"))
        {
            print("Increasing Player 2 Rounds");
            Player2Rounds++;
        }
        else
        {
            print("Increasing Player 1 Rounds");
            Player1Rounds++;
        }

        print("Increasing Current Round");
        CurrentRound++;

        if (Player1Rounds == MaxRounds)
        {
            print("Player 1 wins!");
            MatchEndScreen.WinningPlayer = "Player 1";
            SceneManager.LoadScene("MatchEndScene");
            return;
        }
        if (Player2Rounds == MaxRounds)
        {
            print("Player 2 wins!");
            MatchEndScreen.WinningPlayer = "Player 2";
            SceneManager.LoadScene("MatchEndScene");
            return;
        }
        // Reset the arena.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Ends the game with a draw.
    /// </summary>
    private static void ProcessRound()
    {
        Player1Rounds++;
        Player2Rounds++;
        CurrentRound++;
        if (Player1Rounds == MaxRounds || Player2Rounds == MaxRounds)
        {
            if (Player1Rounds == Player2Rounds)
            {
                print("Draw!");
                MatchEndScreen.WinningPlayer = "Both";
                SceneManager.LoadScene("MatchEndScene");
                return;
            }
            else
            {
                if (Player1Rounds > Player2Rounds)
                {
                    print("Player 1 wins!");
                    MatchEndScreen.WinningPlayer = "Player 1";
                    SceneManager.LoadScene("MatchEndScene");
                    return;
                }
                else
                {
                    print("Player 2 wins!");
                    MatchEndScreen.WinningPlayer = "Player 2";
                    SceneManager.LoadScene("MatchEndScene");
                    return;
                }
            }
        }
        // Reset the arena.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}