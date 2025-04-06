# Upgrade System Component  

Easily integrate a fully customizable **upgrade system** into your game with this package, designed for flexibility and ease of use.  

## Features  

- Dynamic **Expandable & Retractable Panel** for seamless user experience  
- Configurable **Upgrade Buttons** to enhance specific abilities  
- Set **Upgrade Limits** to balance progression  
- Optional **Sell Buttons** to refund upgrades  
- Adjustable **Upgrade Scaling Factors** for tailored progression curves  
- Customizable **Sell Price Factors** for strategic decision-making  
- Integrated **Currency System** for upgrade transactions  
- Fine-tune **Currency Cost Scaling** to fit your game's economy  

## Guide
- After Opening the Project. We will see the Guide Scene with a Canvas.
    - In the Project folders look for the UpgradeSystem Folder and open the Prefab Folder within it.
![Guide](./Guide%20Files/Unity1.png)
- After opening the Prefab folder you should be able to see two Prefabs.
    - A Panel Prefab and a Upgrade Prefab
![Guide](./Guide%20Files/Unity2.png)
- Drag and drop the Panel Prefab as a child of the Canvas
    - The Panel should appear in the scene, you are able to move it anywhere comfortable to you.
![Guide](./Guide%20Files/Unity3.png)
- Drag and drop the Upgrade Prefab as a child of the Panel Object
    - The Upgrade should appear within the panel object. you are able to move it anywhere within the panel object.
![Guide](./Guide%20Files/Unity4.png)
- Within the Prefabs folder there should be a Player object. Drag and drop it within the Scene Hierarchy
    - Select the Upgrade object such as it appears in the Inspector View
![Guide](./Guide%20Files/Unity5.png)
- In the Upgrade Game Object Inspector View, There should be a Serialized Field Where you can drag a Game Object into
    - From the Hierarchy View, Drag and drop the Player Game Object into the Serialized Field of in the Upgrade Game Object Inspector
![Guide](./Guide%20Files/Unity6.png)
- A List of public variables from the Player's public variables will appear, pick one of the variables to be avaialble to upgrade during the game.
![Guide](./Guide%20Files/Unity7.png)

Run the game. Press the + button on the upgrade game object in the game and see the Player variable you picked beforehand rise as + is clicked.
## Installation
Work in Progress
https://github.com/itcOnlineGaming/GA_25_P3_Adrian_Sokolowski.git?path=/UpgradeSystemComponent/Packages/ie.setu.upgradesystem#(CurrentTagVersion)

1. Import the package into your project
2. Drag the **UpgradePanel** prefab into your scene
3. Link the **Currency Manager** to your player or economy system
4. Customize upgrade abilities in the **Inspector**

## Credits  

Developed by **Adrian Sokolowski**  

