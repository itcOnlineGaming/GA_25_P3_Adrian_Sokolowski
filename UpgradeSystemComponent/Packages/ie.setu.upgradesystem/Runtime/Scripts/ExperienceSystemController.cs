using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceSystemController : MonoBehaviour, IUpgradeRequirementChecker
{
    // Single Instance of the System to use in other Scripts
    public static ExperienceSystemController Instance { get; private set; }

    // Add How Many Possible Levels Are There
    public int MaxLevel = 10;

    private int CurrentLevel = 1;
    private int levelsUsed = 1;
    public Slider ExperienceSlider;
    
    public TMP_Text LevelText;
    // Current Experience
    public float Experience = 0;
    // Current Amount of Experience necessary to Level Up
    public float CurrentExperienceNeeded = 0;

    public int StartingExperienceNeededForLevelUp = 1000;
    // Increase Experience Amount required for each level by this float
    public float ExperienceAmountMultiplier = 1.5f;
    // If you use the List of the standard Multiplier for Experience Amounts
    public bool UseListOfExperienceThreshHolds = false;
    // Add How many Levels are in the game and what are the thresholds for each level manually
    public List<int> ListOfExperienceNeededForEachLevel = new List<int>();

    void Awake()
    {
        if (Instance == null)
        {
            EventManager.Instance.Subscribe("AddExperience", AddExperience);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        LevelText.text = CurrentLevel.ToString();
        if (!UseListOfExperienceThreshHolds)
        {
            CurrentExperienceNeeded = StartingExperienceNeededForLevelUp;
        }
        else
        {
            if (CurrentLevel <= ListOfExperienceNeededForEachLevel.Count)
            {
                CurrentExperienceNeeded = ListOfExperienceNeededForEachLevel[CurrentLevel - 1];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExperience(int experience)
    {
        if(CurrentLevel >= MaxLevel)
        {
            ExperienceSlider.SetValueWithoutNotify(100);
            return;
        }

        Experience += experience;
        if (Experience >= CurrentExperienceNeeded)
        {
            CurrentLevel++;
            LevelText.text = CurrentLevel.ToString();
            // Add Overflow Experience to the next level
            Experience = Experience - CurrentExperienceNeeded;

            if(!UseListOfExperienceThreshHolds)
            {
                // Increase Experience needed by Multiplier
                CurrentExperienceNeeded *= ExperienceAmountMultiplier;
            }
            else
            {
                if (CurrentLevel <= ListOfExperienceNeededForEachLevel.Count)
                {
                    // Place the next threshhold as the current needed experience amount
                    CurrentExperienceNeeded = ListOfExperienceNeededForEachLevel[CurrentLevel - 1];
                }
                else
                {
                    // If you want to increase by a multiplier after a certain level
                    CurrentExperienceNeeded *= ExperienceAmountMultiplier; 
                }
            }
            // Limit amount of Overflow Available
            if (Experience >= CurrentExperienceNeeded)
            {
                Experience = CurrentExperienceNeeded;
            }
        }
        // Give the silder an appropriate percantage
        float experiencePercentage = (Experience / CurrentExperienceNeeded) * 100f;
        ExperienceSlider.SetValueWithoutNotify(experiencePercentage);

    }
    public bool CanBuyOrSellUpgrade(int upgradeCost, bool isBuying)
    {
        if (isBuying)
        {
            // When buying, you must NOT exceed CurrentLevel
            if (levelsUsed + upgradeCost > CurrentLevel)
            {
                return false;
            }
        }
        else
        {
            // When selling, you must NOT go below zero
            if (levelsUsed - upgradeCost < 0)
            {
                return false;
            }
        }

        return true;
    }

    public void OnUpgradeBought(int upgradeCost)
    {
        levelsUsed += upgradeCost;
        Debug.Log(levelsUsed);
    }

    public void OnUpgradeSold(int upgradeCost)
    {
        levelsUsed -= upgradeCost;
        Debug.Log(levelsUsed);
    }
}
