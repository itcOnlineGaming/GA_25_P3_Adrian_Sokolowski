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
    public bool hideSelling = true;

    public RawImage UpgradeIconRawImage;
    public Image SellingIconRawImage;
    public Image BuyingIconRawImage;
    public Texture FullUpgradeItemTexture;
    public Texture EmptyUpgradeItemTexture;
    public int UpgradeCost = 1;
    public int MaxUpgradeAmount = 1;

    public Button buyingButton;
    public Button sellingButton;

    public MonoBehaviour requirementCheckerBehaviour; 
    private IUpgradeRequirementChecker requirementChecker;

    private void Start()
    {
        if (requirementCheckerBehaviour != null)  // <<< not requirementChecker
        {
            requirementChecker = requirementCheckerBehaviour as IUpgradeRequirementChecker;
            if (requirementChecker == null)
            {
                Debug.LogError("Assigned object does not implement IUpgradeRequirementChecker!");
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
                requirementChecker?.OnUpgradeSold(UpgradeCost);

                onSellUpgrade?.Invoke();
                break;
            }
        }
    }
}
