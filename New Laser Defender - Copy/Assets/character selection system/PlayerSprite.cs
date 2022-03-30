using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{

    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;
    //public GameObject weaponChoice;

    private int selectedOption = 0;


    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
        ActivateWeapon();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    [Header("\b")]
    [Header("Chorus Plug ins")]
    [SerializeField] Sprite CarCar;
    [SerializeField] Sprite Maya;
    [SerializeField] Sprite VanHelsing;
    [SerializeField] GameObject Blue;
    [SerializeField] GameObject Green;
    [SerializeField] GameObject Purple;


    public void ActivateWeapon()
    {
        if (artworkSprite.sprite == CarCar)
        {
            Blue.SetActive(true);
        }
        if (artworkSprite.sprite == Maya)
        {
            Green.SetActive(true);
        }
        if (artworkSprite.sprite == VanHelsing)
        {
            Purple.SetActive(true);
        }

    }


}
