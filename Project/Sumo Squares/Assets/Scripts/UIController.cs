using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// The main UI controller.
/// </summary>
public class UIController : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public Slider[] PlayerStaminaSliders = new Slider[2];

    public GameObject[] RoundCounterBlue = new GameObject[3];
    public GameObject[] RoundCounterRed = new GameObject[3];

    public Text RoundTimeLeftText;

    // Used to access each of the players stats.
    private PlayerStats _ps1, _ps2;

    private Timer _roundTimer;

    // Use this for initialization
    void Start()
    {
        _ps1 = Player1.GetComponent<PlayerStats>();
        _ps2 = Player2.GetComponent<PlayerStats>();
        _roundTimer = GetComponent<Timer>();

        foreach (var slider in PlayerStaminaSliders)
        {
            slider.maxValue = PlayerStats.MaxStamina;
            slider.value = slider.maxValue;
        }

        // TODO: Refactor this code and clean.
        if (!LevelController.BestOf5)
        {
            RoundCounterBlue[2].SetActive(false);
            RoundCounterRed[2].SetActive(false);
        }

        RoundTimeLeftText.text = _roundTimer.Seconds.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStaminaSliders[0].value = _ps1.GetStamina();
        PlayerStaminaSliders[1].value = _ps2.GetStamina();

        // TODO: Refactor this code and clean.
        if (LevelController.Player1Rounds >= 1)
        {
            RoundCounterBlue[0].transform.FindChild("Foreground").gameObject.SetActive(true);
        }
        if (LevelController.Player1Rounds >= 2)
        {
            RoundCounterBlue[1].transform.FindChild("Foreground").gameObject.SetActive(true);
        }
        if (LevelController.Player1Rounds >= 3)
        {
            RoundCounterBlue[2].transform.FindChild("Foreground").gameObject.SetActive(true);
        }
        if (LevelController.Player2Rounds >= 1)
        {
            RoundCounterRed[0].transform.FindChild("Foreground").gameObject.SetActive(true);
        }
        if (LevelController.Player2Rounds >= 2)
        {
            RoundCounterRed[1].transform.FindChild("Foreground").gameObject.SetActive(true);
        }
        if (LevelController.Player2Rounds >= 3)
        {
            RoundCounterRed[2].transform.FindChild("Foreground").gameObject.SetActive(true);
        }

        RoundTimeLeftText.text = _roundTimer.GetSecondsRemaining().ToString("F0");
    }
}