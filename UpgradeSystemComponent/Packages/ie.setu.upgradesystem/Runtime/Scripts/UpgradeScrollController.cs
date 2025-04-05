using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScrollController : MonoBehaviour
{
    public RectTransform holder; 
    public Slider scrollSlider; 

    public float visibleAreaHeight = 200; 
    public float contentHeight = 800f; 

    private void Update()
    {
        if (holder == null || scrollSlider == null)
            return;

        float maxScroll = Mathf.Max(0f, contentHeight - visibleAreaHeight);
        float newY = scrollSlider.value * maxScroll;

        Vector2 newPos = holder.anchoredPosition;
        newPos.y = newY;
        holder.anchoredPosition = newPos;
    }
}