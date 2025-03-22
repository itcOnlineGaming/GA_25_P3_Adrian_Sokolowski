using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EconomicSystemController : MonoBehaviour
{
    // Single Instance of the System to use in other Scripts
    public static EconomicSystemController Instance { get; private set; }

    public float MaxEconomicValue = 10000.99f;
    public float CurrentEconomicValue = 0;
    public TMP_Text CurrentEconomicValueText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        CurrentEconomicValueText.text = CurrentEconomicValue.ToString();
    }

    public void AddEconomicValue(float value)
    {
        CurrentEconomicValue += value;

        if(CurrentEconomicValue > MaxEconomicValue)
        {
            CurrentEconomicValue = MaxEconomicValue;
        }

        CurrentEconomicValueText.text = CurrentEconomicValue.ToString();
    }

    public bool SpendEconomicValue(float value)
    {
        if(value >= CurrentEconomicValue)
        {
            CurrentEconomicValue -= value;
            CurrentEconomicValueText.text = CurrentEconomicValue.ToString();
            return true;
        }

        return false;
    }

}
