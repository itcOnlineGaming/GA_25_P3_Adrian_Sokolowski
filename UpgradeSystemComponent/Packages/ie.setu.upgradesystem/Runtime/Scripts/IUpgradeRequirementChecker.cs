using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradeRequirementChecker
{
    bool CanBuyOrSellUpgrade(int upgradeCost, bool isBuying); // return true if allowed to buy or sell
    void OnUpgradeBought(int upgradeCost); // deduct after buying
    void OnUpgradeSold(int upgradeCost);   // refund after selling
}