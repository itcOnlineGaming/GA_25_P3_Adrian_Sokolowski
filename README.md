# Upgrade System

This Unity package allows for the addition of a modular and customizable Upgrade System with example Economic and Experience Systems to accompany it.

**Link To Google Doc of Guide**  
[Original Google Doc](https://docs.google.com/document/d/1fZhn5KsKNT8e6PizA5U6HRcDtIpw_rSW6nQ5NydDQGQ/edit?usp=sharing)

## Table of Contents
- [Setup the Component](#setup-the-component)
- [Quick Start](#quick-start)
- [Using the Component](#using-the-component)
- [Upgrade System Setup](#upgrade-system-setup)
- [Creating Upgrade Objects](#creating-upgrade-objects)
- [Upgrade Panel](#upgrade-panel)
- [Upgrade Object](#upgrade-object)
- [Upgrade System using Experience System](#upgrade-system-using-experience-system)
- [Features Spec](#features-spec)
  - [Upgrade System](#upgrade-system-1)
  - [Value Requirement Integration](#value-requirement-integration)
  - [Upgrade Object Behavior](#upgrade-object-behavior)
  - [Panel & UI Management](#panel--ui-management)
  - [Dynamic and Manual Setup Options](#dynamic-and-manual-setup-options)

---
#  **Setup the component** {#setup-the-component}

You need to add the component to your project using the Package Manager. Open the Package Manager (Windows \> Package Manager), click on the **\+** icon and select “Add package from git URL...” and enter:  
[https://github.com/itcOnlineGaming/GA\_25\_P3\_Adrian\_Sokolowski.git?path=/UpgradeSystemComponent/Packages/ie.setu.upgradesystem\#v1.0.3](https://github.com/itcOnlineGaming/GA_25_P3_Adrian_Sokolowski.git?path=/UpgradeSystemComponent/Packages/ie.setu.upgradesystem#v1.0.3)  
Note that the URL specifies the complete path to the package and a git tag. The package should now be visible in your project.

## **Quick Start** {#quick-start}

Add `UpgradeSystem` prefab into your Canvas.

Add `ExperienceSystem` prefab if using levels.

Configure `UpgradeSystemController`:

* Add Upgrade Data List entries (specify icons, costs, actions).

Press Play\!

# **Using the component** {#using-the-component}

1. You have 3 different options for using the component. You are either able to use one of the two premade systems for value gathering ( EconomicSystem or ExperienceSystem ) or you can use the UpgradeSystem on its own and add your own value gathering system.  
2. If you wish to use one of the premade systems go to **UpgradeSystem \-\> Runtime \-\> Prefabs \-\> EconomicSystem / Experience System** and drag them into the scene Hierarchy and go to **UpgradeSystem \-\> Runtime \-\> Prefabs \-\> UpgradeSystem** and add it to the canvas in your scene.

![Guide](./Guide%20Files/Guide1.png)

## **Upgrade System Setup** {#upgrade-system-setup}

Add the **UpgradeSystem** Prefab from **UpgradeSystem \-\> Runtime \-\> Prefabs** into your Canvas Object in your scene.

You are required to have a Value System Script using the IUpgradeRequirementChecker

( If You add the ExperienceSystemPrefab or the EconomySystem Prefab. They come with a script, with a fully implemented IUpgradeRequirementChecker )

public interface IUpgradeRequirementChecker  
{  
	bool CanBuyOrSellUpgrade(int upgradeCost, bool isBuying);  
	void OnUpgradeBought(int upgradeCost);   
	void OnUpgradeSold(int upgradeCost);   
}

Implement your Value System with these functions in mind.  
They Control how your upgrade objects interact when adding or removing upgrades during gameplay.

**Example Implementation from ExperienceSystemController**  
public bool CanBuyOrSellUpgrade(int upgradeCost, bool isBuying)  
	if (isBuying)  
	{  
    	if (levelsUsed \+ upgradeCost \> CurrentLevel)  
        		return false;  
	}  
	else  
	{  
    	if (levelsUsed \- upgradeCost \< 0\)  
        	return false;  
}  
	return true;

public void OnUpgradeBought(int upgradeCost)  
	levelsUsed \+= (int)upgradeCost;

public void OnUpgradeSold(int upgradeCost)  
	levelsUsed \-= (int)upgradeCost;

The UpgradeSystemController Script in the UpgradeSystem Prefab will find and assign the Requirement Checker Behaviour in the Scene if one is assigned. You may assign it yourself.  

![Guide](./Guide%20Files/Guide2.png)

In order to add your first Upgrade Item into the game. Press the \+ button on “Upgrades” in the Upgrade System Controller in the Inspector  

![Guide](./Guide%20Files/Guide3.png)

This is your first Upgrade Object Element. Which will be created when you run the game.  

![Guide](./Guide%20Files/Guide4.png)

![Guide](./Guide%20Files/Guide5.png)

Without assigning your own Icons / Sprites this is how the default Upgrade object looks like.

## **Creating Upgrade Objects** {#creating-upgrade-objects}

**Hide Selling \-** Used to hide the sell button if you dont desire it to be an option with your Value System.  
**Upgrade Icon \-** Used to identify which upgrade this Upgrade Object corresponds with ( Bow In the Image )  
**Selling Icon \-** Used to change the look of the selling button.  
**Buying Icon \-** Used to change the look of the buying button.  
**Full Upgrade Item Icon \-** Used to change the look of all upgraded Upgrade Items in the Upgrade Object ( Yellow Star in the Image )  
**Empty Upgrade Item Icon \-** Used to change the look of all empty Upgrade Items in the Upgrade Object ( White Star in the Image )  
**OnBuy() \-** Assign what function you wish to run when the buy button is clicked ( This is what determines what is being upgraded )  
**OnSell() \-** Assign what function you wish to run when the sell button is clicked ( This is what determines what is being downgraded )  

![Guide](./Guide%20Files/Guide6.png)

By changing the Upgrade Icon in the Inspector.  

![Guide](./Guide%20Files/Guide7.png)

I am able to change what the Upgrade Icon looks like in the game, inside of my Upgrade Object from the default ( Bow Icon ) to the updated Sword Icon.  

![Guide](./Guide%20Files/Guide8.png)

**Max Upgrade Amount \-** The Amount of Upgrades possible for this Upgrade Object ( This is what determines the amount of Upgrade Items ( Default Stars ) Inside of the Upgrade Object during runtime.  
**Upgrade Cost \-** The Amount of Value it costs for a single Upgrade to be bought.  
**Upgrade Cost Multiplier \-** The Cost Multiplier of consecutive upgrades in this Upgrade Object.

## **Upgrade Panel** {#upgrade-panel}

**Upgrade Panel Open \-** This holds the Upgrade Scroll Controller Script. Here you are able to specify the height of the Visible Area where the Upgrade Objects reside and the Content Height, the height where Upgrade Objects are.  

![Guide](./Guide%20Files/Guide9.png)

Using this You are able to limit the height of the Upgrade Panel in the game. While adding more Upgrade Objects then the height of the panel allows. 

![Guide](./Guide%20Files/Guide10.png)

I have 3 Upgrade Objects. While only 2 are visible.  

![Guide](./Guide%20Files/Guide11.png)

When I use the Slider on the side I am able to see the other Upgrade Object which is in the Scene.

Using this you are able to have more Upgrade Objects while maintaining how much space the Upgrade Panel takes in your game.

In the UpgradeHolder GameObject you will see the UpgradeObjects which you created beforehand.  

![Guide](./Guide%20Files/Guide12.png)

## **Upgrade Object** {#upgrade-object}

If you wish to Manually Add Upgrade Objects Into the Scene.  
Add the Upgrade System into the Scene as beforehand and leave the Upgrade Data List empty.  
Go to **UpgradeSystem \-\> Runtime \-\> Prefabs \-\> Upgrade System Prefabs \-\>**   
Folder where you will find the **UpgradeObject** prefab.  
**Drag and Drop** this prefab as a child into the UpgradeHolder object. Your Upgrade Object prefab should appear in the Upgrade Panel, in the scene.

In the UpgradeObject prefab you are dragged into the scene. You are able to dynamically change the amount of Upgrade Items In the Scene which will update in the Inspector. This allows you to gauge the look of the Upgrade Object during Runtime.  

![Guide](./Guide%20Files/Guide13.png)
This happens by using the slider **Total Upgrades** in the Upgrade Object Spawner Script, in the Upgrade Object prefab

**When not using the Upgrade System to dynamically add Upgrade Objects. You need to assign the Requirement Checker Behaviour script to the Upgrade Objects Manually.**  

![Guide](./Guide%20Files/Guide14.png)

## **Upgrade System using Experience System** {#upgrade-system-using-experience-system}

From **UpgradeSystem \-\> Runtime \-\> Prefabs** Drag the **ExperienceSystem** prefab into the scene. Using the Experience System, in the ExperienceSystem Prefab Object You will see the Experience System Controller Script which will allow you to specify and modify the following. 

1. Using the premade Experience System you are able to specify the maximum level you want possible in your game.   
2. A starting Experience amount needed to level up.  
3. Experience Amount Multiplier which will increase the experience needed to level up each level.  
4. Use a List of Experience Thresholds needed to level up. By stating exact experience necessary for each level ( If you wish to do this for only the first couple levels. The experience amount multiplier will take over for the rest of the levels until the max level is achieved )  
5. You can add your own slider to use for showcasing how much experience the player currently has by dragging it into the Experience Slider variable slot.  

![Guide](./Guide%20Files/Guide15.png)

# **Features Spec** {#features-spec}

## **Upgrade System** {#upgrade-system}

* Allows adding customizable Upgrade Objects into the game dynamically or manually.

* Each Upgrade Object can represent an upgradeable feature in the game (e.g., Weapon upgrades, Abilities, Skills).

## **Value Requirement Integration** {#value-requirement-integration}

* Works with any value system (like Experience Points, Currency, etc.) through the `IUpgradeRequirementChecker` interface.

* Premade support for Experience System and Economic System included.

* Requirement checking happens before upgrades or downgrades are allowed.

## **Upgrade Object Behavior** {#upgrade-object-behavior}

* Each Upgrade Object can have multiple Upgrade Items (e.g., stars) showing upgrade progress.

* Upgrade Items update visually between Full and Empty based on upgrades bought/sold.

* Upgrades and downgrades trigger customizable Unity Events (`OnBuy`, `OnSell`).

## **Panel & UI Management** {#panel-&-ui-management}

* Upgrade Panel can scroll dynamically if Upgrade Objects overflow the visible area.

* Visual customization for:

  * Upgrade Icon

  * Buy Button Icon

  * Sell Button Icon

  * Full Upgrade Item Icon

  * Empty Upgrade Item Icon

* Sell Button visibility can be toggled off for specific upgrades.

## **Dynamic and Manual Setup Options** {#dynamic-and-manual-setup-options}

* Dynamically create Upgrade Objects through the Upgrade System Controller.

* Alternatively, manually place Upgrade Objects under the Upgrade Holder for full manual control.

* Manual objects require manual assignment of requirement checkers.