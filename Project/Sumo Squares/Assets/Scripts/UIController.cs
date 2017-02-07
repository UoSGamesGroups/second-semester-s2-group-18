using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject Player1;
    public GameObject Player2;
    public Slider[] PlayerSliders = new Slider[2];
    private PlayerStats ps1, ps2;

	// Use this for initialization
	void Start () {
        ps1 = Player1.GetComponent<PlayerStats>();
        ps2 = Player2.GetComponent<PlayerStats>();

        foreach(var slider in PlayerSliders)
        {
            slider.maxValue = PlayerStats.MaxStamina;
            slider.value = slider.maxValue;
        }
	}
	
	// Update is called once per frame
	void Update () {
        PlayerSliders[0].value = ps1.GetStamina();
        PlayerSliders[1].value = ps2.GetStamina();
    }
}
