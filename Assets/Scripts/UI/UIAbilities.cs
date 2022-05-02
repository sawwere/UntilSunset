using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIAbilities : MonoBehaviour
{
    public static UIAbilities instance { get; private set; }
    public Image mask1;
    public Image mask2;
    float originalSize1;
    float originalSize2;
    void Start()
    {
        instance = this;
        originalSize1 = mask1.rectTransform.rect.height;
        originalSize2 = mask2.rectTransform.rect.height;
        mask1.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, mask1.rectTransform.rect.height);
        mask2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, mask2.rectTransform.rect.height);
    }

    public void SetValue1(float value)
    {
        if(mask1 != null)
        mask1.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSize1 * value);
    }

    public void SetValue2(float value)
    {
        if (mask2 != null)
            mask2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSize2 * value);
    }

}
