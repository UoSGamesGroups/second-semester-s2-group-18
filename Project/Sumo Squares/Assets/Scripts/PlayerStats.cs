using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float _stamina;
    private float _exampleStat;
    private float _exampleStat2;

    public const float MaxStamina = 100;

    // Use t    his for initialization
    void Start()
    {
        SetStamina(MaxStamina);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public float GetStamina()
    {
        return _stamina;
    }

    public void SetStamina(float stamina)
    {
        _stamina = stamina;
    }
}