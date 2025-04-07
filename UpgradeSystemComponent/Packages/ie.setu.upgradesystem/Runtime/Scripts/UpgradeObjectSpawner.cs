using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class UpgradeObjectSpawner: MonoBehaviour
{
    [Range(1, 24)]
    public int totalUpgrades = 10;

    private UpgradeController upgradeController;

    public GameObject upgradePrefab;
    public RectTransform panel;
    public Texture fullItem;
    public Texture emptyItem;
    private GridLayoutGroup grid;
    private int lastUpgradeCount = -1;
    private void Awake()
    {
        upgradeController = GetComponent<UpgradeController>();
        upgradeController.MaxUpgradeAmount = totalUpgrades;
    }

#if UNITY_EDITOR
    private bool scheduledRefresh = false;
#endif

    private void OnValidate()
    {
#if UNITY_EDITOR

        if (gameObject.scene.name == null || gameObject.scene.name == "")
            return;

        if (upgradeController == null)
            upgradeController = GetComponent<UpgradeController>();

        if (!Application.isPlaying)
        {
            if (panel == null || upgradePrefab == null)
                return;

            if (!scheduledRefresh)
            {
                scheduledRefresh = true;
                UnityEditor.EditorApplication.delayCall += () =>
                {
                    if (this == null || panel == null || upgradePrefab == null)
                        return;

                    scheduledRefresh = false;
                    RefreshUpgrades();
                };
            }
        }
#endif
    }

    private void Update()
    {
        if (totalUpgrades != lastUpgradeCount)
        {
            lastUpgradeCount = totalUpgrades;
            RefreshUpgrades();
        }
    }

    void ConfigureGrid(int upgradeCount)
    {
        if (upgradeCount >= 10)
        {
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = 8;
            grid.cellSize = new Vector2(5f, 5f);
        }
        else if (upgradeCount >= 6)
        {
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = 5;
            grid.cellSize = new Vector2(10f, 10f);
        }
        else if (upgradeCount >= 4)
        {
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = 5;
            grid.cellSize = new Vector2(12f, 12f);
        }
        else
        {
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = 3;
            grid.cellSize = new Vector2(20f, 20f);
        }

        grid.spacing = new Vector2(5f, 5f);
    }

    void SpawnUpgrades()
    {
        // Clear existing upgrades
        foreach (Transform child in panel)
        {
        #if UNITY_EDITOR
            // Destroy immediatly if using the inspector
            if (!Application.isPlaying)
                UnityEditor.EditorApplication.delayCall += () => { if (child) DestroyImmediate(child.gameObject); };
            else
                Destroy(child.gameObject);
        #else
            Destroy(child.gameObject);
        #endif
        }

        // Spawn new upgrades
        for (int i = 0; i < totalUpgrades; i++)
        {
            GameObject upgrade = Instantiate(upgradePrefab, panel);
            upgrade.transform.localScale = Vector3.one;
            upgrade.GetComponent<UpgradeObjectController>().SetIndex(i+1);
            upgrade.name = $"Upgrade Item {i + 1}";

            upgrade.GetComponent<UpgradeObjectController>().emptyTexture = emptyItem;
            upgrade.GetComponent<UpgradeObjectController>().fullTexture = fullItem;
            upgrade.GetComponent<UpgradeObjectController>().SetEmpty();
        }
    }
    private void RefreshUpgrades()
    {
        grid = panel.GetComponent<GridLayoutGroup>();
        if (grid == null)
        {
            Debug.LogWarning("GridLayoutGroup is missing on panel!");
            return;
        }

        ConfigureGrid(totalUpgrades);
        ClearUpgrades();
        SpawnUpgrades();

        upgradeController.upgrades.Clear();
        upgradeController.upgrades.AddRange(GetComponentsInChildren<UpgradeObjectController>());
    }

    private void ClearUpgrades()
    {
        var children = new System.Collections.Generic.List<Transform>();

        foreach (Transform child in panel)
        {
            children.Add(child);
        }

    #if UNITY_EDITOR
        foreach (var child in children)
        {
            if (child != null)
                DestroyImmediate(child.gameObject);
        }
    #else
        foreach (var child in children)
        {
            if (child != null)
                Destroy(child.gameObject);
        }
    #endif
    }
}
