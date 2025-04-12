
**Upgrade System**  
This Unity package allows for the addition of a modular and customizable Upgrade System with example Economic and Experience Systems to accompany it.

**Link To Google Doc of Guide**
[Original Google Doc](https://docs.google.com/document/d/1fZhn5KsKNT8e6PizA5U6HRcDtIpw_rSW6nQ5NydDQGQ/edit?usp=sharing)

[Setup the component](#setup-the-component)

[Quick Start](#quick-start-demo)

[Using the component](#using-the-component)

[Upgrade System Setup](#upgrade-system-setup)

[Creating Upgrade Objects](#creating-upgrade-objects)

[Upgrade Panel](#upgrade-panel)

[Upgrade Object](#upgrade-object)

[Upgrade System using Experience System](#upgrade-system-using-experience-system)

[Features Spec](#features-spec)

[Upgrade System](#upgrade-system)

[Value Requirement Integration](#value-requirement-integration)

[Upgrade Object Behavior](#upgrade-object-behavior)

[Panel & UI Management](#panel-&-ui-management)

[Dynamic and Manual Setup Options](#dynamic-and-manual-setup-options)

#  **Setup the component** {#setup-the-component}

You need to add the component to your project using the Package Manager. Open the Package Manager (Windows \> Package Manager), click on the **\+** icon and select “Add package from git URL...” and enter:  
[https://github.com/itcOnlineGaming/GA\_25\_P3\_Adrian\_Sokolowski.git?path=/UpgradeSystemComponent/Packages/ie.setu.upgradesystem\#v1.0.3](https://github.com/itcOnlineGaming/GA_25_P3_Adrian_Sokolowski.git?path=/UpgradeSystemComponent/Packages/ie.setu.upgradesystem#v1.0.3)  
Note that the URL specifies the complete path to the package and a git tag. The package should now be visible in your project.

## **Quick Start Demo** {#quick-start-demo}

**Upgrade System Demo** 
**Step 1: Turn On the Demo:**  

	Enable DemoGuideUpgradeSystem  

![Guide](./Guide%20Files/1.png)

**Step 2: Try Using the Object and See the Differences Between them:**  

Play the game.  

Using the Economic System I gave you 10000 to play with.  

![Guide](./Guide%20Files/2.png)

There are two different Upgrade Objects in your Scene. They look different and using 
them is different.  

![Guide](./Guide%20Files/3.png)

If you Press Buy on this object.  

![Guide](./Guide%20Files/4.png)

300 Economic Value will go away and an X will become a checkmark.  

![Guide](./Guide%20Files/5.png)

If you press Buy on this object, the Economic Value will Decrease by 100 for the first time.  

This will continue to double as you press Buy again.  

![Guide](./Guide%20Files/6.png)

Unlike the other object, this Upgrade Object has a Sell button. If you click this button, some Economic Value will be refunded to you — but not all.

**Step 3: Change the Objects:**  

These are all options I set in the UpgradeSystem Object in the DemoGuideUpgradeSystem Prefab.

![Guide](./Guide%20Files/7.png)

UpgradeSystem Object has the script Upgrade System Controller. 

![Guide](./Guide%20Files/8.png)

For the sake of the Demo, the Script comes with two predefined Upgrade Objects you saw in Step 2.

For the Arrow Upgrade Object in the Upgrade Data List, try to change these parameters:  
- Max Upgrade Amount → from 5 to 10  
- Upgrade Cost → from 100 to 1000  
- Upgrade Cost Multiplier → from 2 to 1  
- Selling Cost Devaluation → from 0.5 to 1  

Or any combination you desire.  

![Guide](./Guide%20Files/9.png)

Press Play.  

![Guide](./Guide%20Files/10.png)

Now the Arrow Upgrade Object has 5 more Upgrade Items.  
When you press Buy, you are deducted 1000 Economic Value.  
Consecutive Buy presses don't cost more because the Multiplier is 1.

When you press Sell, you receive the full Economic Value of the upgrade cost back.

**Step 4: Add New Functionality To The Object:**  
Try pressing the Buy button for the Gun Upgrade Object.  

![Guide](./Guide%20Files/11.png)

Try moving the player with WASD.  

![Guide](./Guide%20Files/12.png)

As you press Buy more times, you will notice that the player increases in speed.  

![Guide](./Guide%20Files/13.png)

This is because, in the Gun Upgrade Data List Upgrade Object, the OnBuy() event calls `PlayerController.AddSpeed()`.

Now, add a new OnSell() function:
- Drag and drop the Player object into the slot
- Pick the `RemoveSpeed` function from PlayerController

![Guide](./Guide%20Files/14.png)
![Guide](./Guide%20Files/15.png)
![Guide](./Guide%20Files/16.png)

Before testing, make sure you **uncheck Hide Selling** for the Gun Upgrade Object to see the Sell button:

![Guide](./Guide%20Files/17.png)

Play the game again.

Buy Gun upgrades (player speeds up), then sell them (player slows down).  
![Guide](./Guide%20Files/18.png)

You can customize Buy/Sell actions by assigning functions in the inspector.

---
## **Experience System Demo** {#experience-system-demo}

**Step 1: Turn On the Demo:**  

Enable DemoGuideExperienceSystem  

![Guide](./Guide%20Files/19.png)

**Step 2: Try Leveling:**  

Play the game.  
Click this button:  

![Guide](./Guide%20Files/20.png)

Walk into this object:  
![Guide](./Guide%20Files/21.png)

Notice how you are gaining experience and leveling up:  

![Guide](./Guide%20Files/22.png)

This bar and level number will increase:  

![Guide](./Guide%20Files/23.png)

Both systems use the **EventManager** package to Add Experience.

**Step 3: Using Experience:**  

Open the Upgrade Panel:  

![Guide](./Guide%20Files/24.png)

Try buying upgrades:  

![Guide](./Guide%20Files/25.png)

You can’t buy more upgrades than your level allows.

Try selling upgrades:  

![Guide](./Guide%20Files/26.png)

After selling, you can buy again:  

![Guide](./Guide%20Files/27.png)

**Step 4: Modifying the Experience Needed:**  
Change the **Experience Amount Multiplier** in the ExperienceSystemController:  
![Guide](./Guide%20Files/28.png)

Example: changing from 1.5 → 2.

Now your next Experience threshold doubles:  

![Guide](./Guide%20Files/29.png)
![Guide](./Guide%20Files/30.png)
![Guide](./Guide%20Files/31.png)

**Step 5: Setting Your Own Experience Amounts:**  

Turn off the game:  

![Guide](./Guide%20Files/32.png)

Activate **Use List Of Experience Thresholds**:  

![Guide](./Guide%20Files/33.png)

Add values to the list:  

![Guide](./Guide%20Files/34.png)

Play the game:  

![Guide](./Guide%20Files/35.png)

Now your first few levels have custom XP requirements:  

![Guide](./Guide%20Files/36.png)

After the list ends, XP needed increases based on the multiplier:  

![Guide](./Guide%20Files/37.png)

	This way you can tailor make your users experience for the first levels and then let the experience needed for more levels ramp up or slow down in cost.

**Upgrade Object Demo**
--
**Step 1: Turn On The Demo**  

	Enable DemoGuideUpgradeObject  

![Guide](./Guide%20Files/38.png)

**Step 2: Select The Object Too Modify**  

Pick One of the Two UpgradeObjects Assigned in the Demo  

![Guide](./Guide%20Files/39.png)

**Step 3: See Dynamic Inspector Changes**  

Play Around with the Total Upgrades slider in the Upgrade Object Spawner  

![Guide](./Guide%20Files/40.png)

	See how the amount of items in the Upgrade Object is changing dynamically in the Inspector. This way you can see how the Upgrade Object will look in the game without the need of playing.  

![Guide](./Guide%20Files/41.png)

With 6 Total Upgrades  

![Guide](./Guide%20Files/42.png)

With 18 Total Upgrades

**Step 4: Modify The Look Of The Upgrades**  

	Change the Full Item object and Empty item objects 
	
![Guide](./Guide%20Files/43.png)

See how the Upgrade Object Changes its upgrade icons dynamically in the inspector  

![Guide](./Guide%20Files/44.png)
![Guide](./Guide%20Files/45.png)

	Once you pick the Full Item and Empty Item Objects you want to use in game.  

![Guide](./Guide%20Files/46.png)

	Change the Full Upgrade Item Texture and Empty Upgrade Item Texture in the Upgrade Controller Script to the textures you desire.  

**Step 5: Add More Upgrade Objects**  

From the Upgrade System Prefab Folder. Drag a UpgradeObject Prefab into UpgradeHolder Object in your UpgradePanel  

![Guide](./Guide%20Files/47.png)

	This is how you can Manually add more Upgrade Objects into your Upgrade Panel. You will notice that The New Upgrade Object will automatically be seen Underneath the other objects previously added.  

![Guide](./Guide%20Files/48.png)

# **Using the component** {#using-the-component}

1. You have 3 different options for using the component. You are either able to use one of the two premade systems for value gathering ( EconomicSystem or ExperienceSystem ) or you can use the UpgradeSystem on its own and add your own value gathering system.  
2. If you wish to use one of the premade systems go to **UpgradeSystem \-\> Runtime \-\> Prefabs \-\> EconomicSystem / Experience System** and drag them into the scene Hierarchy and go to **UpgradeSystem \-\> Runtime \-\> Prefabs \-\> UpgradeSystem** and add it to the canvas in your scene.!![Guide](./Guide%20Files/Guide1.png)

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

**Hide Selling \-** Used to hide the sell button if you don't desire it to be an option with your Value System.  
**Upgrade Icon \-** Used to identify which upgrade this Upgrade Object corresponds with ( Bow In the Image )  
**Selling Icon \-** Used to change the look of the selling button.  
**Buying Icon \-** Used to change the look of the buying button.  
**Full Upgrade Item Icon \-** Used to change the look of all upgraded Upgrade Items in the Upgrade Object ( Yellow Star in the Image )  
**Empty Upgrade Item Icon \-** Used to change the look of all empty Upgrade Items in the Upgrade Object ( White Star in the Image )  
**OnBuy() \-** Assign what function you wish to run when the buy button is clicked ( This is what determines what is being upgraded )  
**OnSell() \-** Assign what function you wish to run when the sell button is clicked ( This is what determines what is being downgraded )  
![Guide](./Guide%20Files/Guide5.png)

By changing the Upgrade Icon in the Inspector.  
![Guide](./Guide%20Files/Guide6.png)
I am able to change what the Upgrade Icon looks like in the game, inside of my Upgrade Object from the default ( Bow Icon ) to the updated Sword Icon.  
![Guide](./Guide%20Files/Guide7.png)
**Max Upgrade Amount \-** The Amount of Upgrades possible for this Upgrade Object ( This is what determines the amount of Upgrade Items ( Default Stars ) Inside of the Upgrade Object during runtime.  
**Upgrade Cost \-** The Amount of Value it costs for a single Upgrade to be bought.  
**Upgrade Cost Multiplier \-** The Cost Multiplier of consecutive upgrades in this Upgrade Object.

## **Upgrade Panel** {#upgrade-panel}

**Upgrade Panel Open \-** This holds the Upgrade Scroll Controller Script. Here you are able to specify the height of the Visible Area where the Upgrade Objects reside and the Content Height, the height where Upgrade Objects are.  
![Guide](./Guide%20Files/Guide8.png)

Using this You are able to limit the height of the Upgrade Panel in the game. While adding more Upgrade Objects then the height of the panel allows.  
![Guide](./Guide%20Files/Guide9.png)
I have 3 Upgrade Objects. While only 2 are visible.  
![Guide](./Guide%20Files/Guide10.png)
When I use the Slider on the side I am able to see the other Upgrade Object which is in the Scene.

Using this you are able to have more Upgrade Objects while maintaining how much space the Upgrade Panel takes in your game.

In the UpgradeHolder GameObject you will see the UpgradeObjects which you created beforehand.  
![Guide](./Guide%20Files/Guide11.png)

## **Upgrade Object** {#upgrade-object}

If you wish to Manually Add Upgrade Objects Into the Scene.  
Add the Upgrade System into the Scene as beforehand and leave the Upgrade Data List empty.  
Go to **UpgradeSystem \-\> Runtime \-\> Prefabs \-\> Upgrade System Prefabs \-\>**   
Folder where you will find the **UpgradeObject** prefab.  
**Drag and Drop** this prefab as a child into the UpgradeHolder object. Your Upgrade Object prefab should appear in the Upgrade Panel, in the scene.

In the UpgradeObject prefab you are dragged into the scene. You are able to dynamically change the amount of Upgrade Items In the Scene which will update in the Inspector. This allows you to gauge the look of the Upgrade Object during Runtime.  
![Guide](./Guide%20Files/Guide12.png)
This happens by using the slider **Total Upgrades** in the Upgrade Object Spawner Script, in the Upgrade Object prefab

**When not using the Upgrade System to dynamically add Upgrade Objects. You need to assign the Requirement Checker Behaviour script to the Upgrade Objects Manually.**  
![Guide](./Guide%20Files/Guide13.png)

## **Upgrade System using Experience System** {#upgrade-system-using-experience-system}

From **UpgradeSystem \-\> Runtime \-\> Prefabs** Drag the **ExperienceSystem** prefab into the scene. Using the Experience System, in the ExperienceSystem Prefab Object You will see the Experience System Controller Script which will allow you to specify and modify the following. 

1. Using the premade Experience System you are able to specify the maximum level you want possible in your game.   
2. A starting Experience amount needed to level up.  
3. Experience Amount Multiplier which will increase the experience needed to level up each level.  
4. Use a List of Experience Thresholds needed to level up. By stating exact experience necessary for each level ( If you wish to do this for only the first couple levels. The experience amount multiplier will take over for the rest of the levels until the max level is achieved )  
5. You can add your own slider to use for showcasing how much experience the player currently has by dragging it into the Experience Slider variable slot.  
![Guide](./Guide%20Files/Guide14.png)

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