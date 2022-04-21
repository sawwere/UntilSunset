using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemies : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Vector3 _offset;

    public static UIEnemies instance { get; private set; }
    public Image mask;
    float originalSize;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
    void Update()
    {
        _image.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);
    }
}
