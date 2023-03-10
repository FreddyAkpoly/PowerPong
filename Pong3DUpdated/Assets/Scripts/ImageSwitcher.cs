using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ImageSwitcher : MonoBehaviour
{
    public Image imageDisplay;
    public TMP_Text imageNameDisplay;
    public Sprite[] images;
    public string[] imageNames;
    private int currentImageIndex = 0;


    private void Start()
    {
        imageDisplay.sprite = images[currentImageIndex];
        imageNameDisplay.text = imageNames[currentImageIndex];
    }
    public void SwitchImageForward()
    {
        currentImageIndex++;
        if (currentImageIndex >= images.Length)
        {
            currentImageIndex = 0;
        }
        imageDisplay.sprite = images[currentImageIndex];
        imageNameDisplay.text = imageNames[currentImageIndex];
    }

    public void SwitchImageBackward()
    {
        currentImageIndex--;
        if (currentImageIndex < 0)
        {
            currentImageIndex = images.Length - 1;
        }
        imageDisplay.sprite = images[currentImageIndex];
        imageNameDisplay.text = imageNames[currentImageIndex];
    }
}
