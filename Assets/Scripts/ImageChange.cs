using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private UnityEngine.UI.Image _image;

    [SerializeField] private Sprite defaultSprite, pressedSprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = pressedSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = defaultSprite;
    }
}
