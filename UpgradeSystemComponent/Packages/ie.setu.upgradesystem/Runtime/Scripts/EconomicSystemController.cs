using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EconomicSystemController : MonoBehaviour, IUpgradeRequirementChecker
{
    // Single Instance of the System to use in other Scripts
    public static EconomicSystemController Instance { get; private set; }

    public float MaxEconomicValue = 10000.99f;
    public float CurrentEconomicValue = 0;
    public TMP_Text CurrentEconomicValueText;



    void Awake()
    {
        if (Instance == null)
        {
            EventManager.Instance.Subscribe("AddValue", AddEconomicValue);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        CurrentEconomicValueText.text = CurrentEconomicValue.ToString();
    }

    public void AddEconomicValue(int value)
    {
        CurrentEconomicValue += value;

        if(CurrentEconomicValue > MaxEconomicValue)
        {
            CurrentEconomicValue = MaxEconomicValue;
        }

        CurrentEconomicValueText.text = CurrentEconomicValue.ToString();
    }

    public bool SpendEconomicValue(int value)
    {
        if(value >= CurrentEconomicValue)
        {
            CurrentEconomicValue -= value;
            CurrentEconomicValueText.text = CurrentEconomicValue.ToString();
            return true;
        }

        return false;
    }

    public bool CanBuyOrSellUpgrade(int upgradeCost, bool isBuying)
    {
        if (isBuying)
        {
            // When buying, you must NOT exceed CurrentLevel
            if (upgradeCost > CurrentEconomicValue)
            {
                return false;
            }
        }

        return true;
    }

    public void OnUpgradeBought(int upgradeCost)
    {
        CurrentEconomicValue -= upgradeCost;
        CurrentEconomicValueText.text = CurrentEconomicValue.ToString();
    }

    public void OnUpgradeSold(int upgradeCost)
    {
        if (CurrentEconomicValue + upgradeCost > MaxEconomicValue)
        {
            CurrentEconomicValue = MaxEconomicValue;
            CurrentEconomicValueText.text = CurrentEconomicValue.ToString();
        }
        else
        {
            CurrentEconomicValue += upgradeCost;
            CurrentEconomicValueText.text = CurrentEconomicValue.ToString();
        }
    }
}
