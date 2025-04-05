using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class UpgradeData
{
    public string upgradeName;
    public bool HideSelling;
    public Texture UpgradeIcon;
    public Sprite SellingIcon;
    public Sprite BuyingIcon;
    public Texture FullUpgradeItemIcon;
    public Texture EmptyUpgradeItemIcon;
    public UnityEvent onBuy;
    public UnityEvent onSell;
    public int UpgradeCost;
    public int MaxUpgradeAmount;
}

public class UpgradeSystemController : MonoBehaviour
{
    [Header("Setup")]
    public RectTransform upgradeHolder;
    public GameObject upgradeObjectPrefab;
    public bool UsingExperienceSystem = true;
    public bool UsingEconomicSystem = false;
    public MonoBehaviour requirementCheckerBehaviour;

    [Header("Upgrades")]
    public List<UpgradeData> upgradeDataList = new List<UpgradeData>();

    private List<UpgradeController> spawnedUpgrades = new List<UpgradeController>();

    private void Start()
    {
        SpawnUpgrades();
    }

    public void SpawnUpgrades()
    {
        foreach (var data in upgradeDataList)
        {
            GameObject upgradeGO = Instantiate(upgradeObjectPrefab, upgradeHolder);
            UpgradeController upgrade = upgradeGO.GetComponent<UpgradeController>();

            if (requirementCheckerBehaviour == null)
            {
                MonoBehaviour[] behaviours = FindObjectsOfType<MonoBehaviour>();

                foreach (var behaviour in behaviours)
                {
                    if (behaviour is IUpgradeRequirementChecker)
                    {
                        requirementCheckerBehaviour = behaviour;
                        break;
                    }
                }
            }
            upgrade.requirementCheckerBehaviour = requirementCheckerBehaviour;

            // Link the buy/sell from data
            if (data.onBuy != null)
                upgrade.onBuyUpgrade = data.onBuy;
            if (data.onSell != null)
                upgrade.onSellUpgrade = data.onSell;

            upgrade.hideSelling = data.HideSelling;
            upgrade.UpgradeCost = data.UpgradeCost;
            upgrade.MaxUpgradeAmount = data.MaxUpgradeAmount;

            if (data.UpgradeIcon != null)
                upgrade.UpgradeIconRawImage.texture = data.UpgradeIcon;
            if (data.BuyingIcon != null)
                upgrade.BuyingIconRawImage.sprite = data.BuyingIcon;
            if (data.FullUpgradeItemIcon != null)
                upgrade.FullUpgradeItemTexture = data.FullUpgradeItemIcon;
            if (data.EmptyUpgradeItemIcon != null)
                upgrade.EmptyUpgradeItemTexture = data.EmptyUpgradeItemIcon;
            if (data.SellingIcon != null)
                upgrade.SellingIconRawImage.sprite = data.SellingIcon;


            spawnedUpgrades.Add(upgrade);
        }
    }
}
