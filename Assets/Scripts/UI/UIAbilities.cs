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
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        originalSize1 = mask1.rectTransform.rect.height;
        originalSize2 = mask2.rectTransform.rect.height;
    }

    public void SetValue1(float value)
    {
        mask1.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSize1 * value);
    }

    public void SetValue2(float value)
    {
        mask2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSize2 * value);
    }

}
