using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradeRequirementChecker
{
    bool CanBuyOrSellUpgrade(int levelCost, bool isBuying); // return true if allowed to buy
    void OnUpgradeBought(int levelCost); // deduct after buying
    void OnUpgradeSold(int levelCost);   // refund after selling
}