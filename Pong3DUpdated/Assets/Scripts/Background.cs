using UnityEngine;

public class Background : MonoBehaviour
{
    // Set the default sprite to be used if the player preference is not set
    public Sprite defaultSprite;

    // Create an array of sprites to choose from based on the player preference
    public Sprite[] spriteOptions;

    void Awake()
    {
        // Get the player's preference for the sprite index, default to 0
        int spriteIndex = PlayerPrefs.GetInt("MapIndex", 0);

        // Check if the sprite index is within the range of the sprite options
        if (spriteIndex >= 0 && spriteIndex < spriteOptions.Length)
        {
            // Set the object's sprite based on the player preference
            GetComponent<SpriteRenderer>().sprite = spriteOptions[spriteIndex];
        }
        else
        {
            // Set the object's sprite to the default sprite
            GetComponent<SpriteRenderer>().sprite = defaultSprite;
        }
    }

    // A function to change the sprite based on the player's preference
    public void ChangeSprite(int spriteIndex)
    {
        // Set the player preference for the sprite index
        PlayerPrefs.SetInt("MapIndex", spriteIndex);

        // Set the object's sprite based on the player preference
        GetComponent<SpriteRenderer>().sprite = spriteOptions[spriteIndex];
    }
}
