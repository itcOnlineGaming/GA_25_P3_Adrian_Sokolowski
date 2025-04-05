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

    public Button buyingButton;
    public Button sellingButton;

    private void Start()
    {
        if(hideSelling)
        {
            sellingButton.gameObject.SetActive(false);
        }
        upgrades.Clear();
        GetComponent<UpgradeObjectSpawner>().fullItem = FullUpgradeItemTexture;
        GetComponent<UpgradeObjectSpawner>().emptyItem = EmptyUpgradeItemTexture;
        foreach(var upgrade in upgrades)
        {
            upgrade.emptyTexture = EmptyUpgradeItemTexture;
            upgrade.fullTexture = FullUpgradeItemTexture;
        }
        upgrades.AddRange(GetComponentsInChildren<UpgradeObjectController>());
    }

    public void BuyUpgrade()
    {
        foreach (var upgrade in upgrades)
        {
            if (!upgrade.isBought)
            {
                upgrade.SetFull();
                onBuyUpgrade?.Invoke();
                break;
            }
        }
    }

    public void SellUpgrade()
    {
        for (int i = upgrades.Count - 1; i >= 0; i--)
        {
            if (upgrades[i].isBought)
            {
                upgrades[i].SetEmpty();
                onSellUpgrade?.Invoke();
                break;
            }
        }
    }
}
