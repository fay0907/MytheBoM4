using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoSlider : MonoBehaviour
{
    public Image displayImage;
    public Sprite[] photos;
    private int currentIndex = 0;

    void Start()
    {
        if (photos.Length > 0)
        {
            displayImage.sprite = photos[currentIndex];
        }
    }
    public void ShowNextPhoto()
    {
        currentIndex++;
        if (currentIndex >= photos.Length)
        {
            currentIndex = 0;
        }
        displayImage.sprite = photos[currentIndex];
    }
    public void ShowPreviousPhoto()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = photos.Length - 1;
        }
        displayImage.sprite = photos[currentIndex];
    }
}
