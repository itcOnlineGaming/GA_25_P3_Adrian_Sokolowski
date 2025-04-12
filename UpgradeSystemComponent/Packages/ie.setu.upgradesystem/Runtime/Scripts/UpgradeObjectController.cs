using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeObjectController : MonoBehaviour
{
    public int upgradeIndex;
    public bool isBought = false;

    public RawImage rawImage;
    public Texture emptyTexture;
    public Texture fullTexture;

    public void SetFull()
    {
        isBought = true;
        if (rawImage != null && fullTexture != null)
            rawImage.texture = fullTexture;
    }

    public void SetEmpty()
    {
        isBought = false;
        if (rawImage != null && emptyTexture != null)
            rawImage.texture = emptyTexture;
    }

    public void SetIndex(int index)
    {
        upgradeIndex = index;
    }
}
