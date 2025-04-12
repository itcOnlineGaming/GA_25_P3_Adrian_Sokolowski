using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    public List<UpgradeObjectController> upgrades = new List<UpgradeObjectController>();
    public UnityEvent onBuyUpgrade;
    public UnityEvent onSellUpgrade;
    public bool hideSelling = false;

    public RawImage UpgradeIconRawImage;
    public Image SellingIconRawImage;
    public Image BuyingIconRawImage;
    public Texture FullUpgradeItemTexture;
    public Texture EmptyUpgradeItemTexture;
    public int UpgradeCost = 1;
    public int MaxUpgradeAmount = 1;
    public float UpgradeCostMultiplier = 1.0f;
    public float SellingCostDevaluation = 1.0f;
    private int upgradeBase = 0;

    public Button buyingButton;
    public Button sellingButton;

    public MonoBehaviour requirementCheckerBehaviour; 
    private IUpgradeRequirementChecker requirementChecker;

    private List<int> upgradeCostsHistory = new List<int>();

    private void Start()
    {
        if (requirementCheckerBehaviour != null)
        {
            requirementChecker = requirementCheckerBehaviour as IUpgradeRequirementChecker;
        }

        if (requirementChecker == null)
        {
            MonoBehaviour[] behaviours = FindObjectsOfType<MonoBehaviour>();

            foreach (var behaviour in behaviours)
            {
                if (behaviour is IUpgradeRequirementChecker)
                {
                    requirementCheckerBehaviour = behaviour;
                    requirementChecker = behaviour as IUpgradeRequirementChecker;
                    break;
                }
            }
        }


        if (hideSelling)
        {
            sellingButton.gameObject.SetActive(false);
        }
        upgrades.Clear();
        
        GetComponent<UpgradeObjectSpawner>().fullItem = FullUpgradeItemTexture;
        GetComponent<UpgradeObjectSpawner>().emptyItem = EmptyUpgradeItemTexture;
        GetComponent<UpgradeObjectSpawner>().totalUpgrades = MaxUpgradeAmount;
        foreach (var upgrade in upgrades)
        {
            upgrade.emptyTexture = EmptyUpgradeItemTexture;
            upgrade.fullTexture = FullUpgradeItemTexture;
        }
        upgrades.AddRange(GetComponentsInChildren<UpgradeObjectController>());
        upgradeBase = UpgradeCost;
    }

    public void BuyUpgrade()
    {
        Debug.Log(requirementChecker);

        if (requirementChecker != null)
        {
            Debug.Log("Buy");
            if (!requirementChecker.CanBuyOrSellUpgrade(UpgradeCost, true))
            {
                Debug.Log("Cannot buy upgrade: requirements not met.");
                return;
            }
        }

        foreach (var upgrade in upgrades)
        {
            if (!upgrade.isBought)
            {
                upgrade.SetFull();
                requirementChecker?.OnUpgradeBought(UpgradeCost);
                upgradeCostsHistory.Add(UpgradeCost);
                float newUpgradeCost = UpgradeCost * UpgradeCostMultiplier;
                UpgradeCost = (int)newUpgradeCost;
                onBuyUpgrade?.Invoke();
                break;
            }
        }
    }

    public void SellUpgrade()
    {
        Debug.Log("Sell");
        if (requirementChecker != null)
        {
            if (!requirementChecker.CanBuyOrSellUpgrade(UpgradeCost, false))
            {
                Debug.Log("Cannot buy upgrade: requirements not met.");
                return;
            }
        }

        for (int i = upgrades.Count - 1; i >= 0; i--)
        {
            if (upgrades[i].isBought)
            {
                upgrades[i].SetEmpty();
                int refundAmount = (int)(GetLastUpgradeCost() * SellingCostDevaluation);
                requirementChecker?.OnUpgradeSold(refundAmount);
                upgradeCostsHistory.RemoveAt(upgradeCostsHistory.Count - 1);

                if (upgradeCostsHistory.Count > 0)
                {
                    UpgradeCost = (int)(upgradeCostsHistory[upgradeCostsHistory.Count - 1] * UpgradeCostMultiplier);
                }
                else
                {
                    UpgradeCost = upgradeBase; 
                }
                onSellUpgrade?.Invoke();
                break;
            }
        }
    }
    private int GetLastUpgradeCost()
    {
        if (upgradeCostsHistory.Count > 0)
        {
            return upgradeCostsHistory[upgradeCostsHistory.Count - 1];
        }
        return 0;
    }
}
