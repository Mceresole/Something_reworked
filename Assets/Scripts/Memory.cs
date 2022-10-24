using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Memory : MonoBehaviour
{
    private enum CardID
    {
        SUN,
        ASTEROID,
        BANANA,
        SATELLITE,
        MOON,
        ALIENSHIP,
        CARDBACK, // face arriere
    }

    // game variables
    private static int ERRORS_MAX = 5;
    public static int errors = 0;
    private static bool flag = false;
    private static List<Image> carteTirees = new List<Image>();
    private static List<CardID> spritesName = new List<CardID>();
    // card variables
    public Sprite sun, asteroid, banana, satellite, moon, alien_ship_alt, card_back, erreur1, erreur2, erreur3, erreur4, erreur0;
    public int nb_cards = 12;
    public Image err;
    private Dictionary<int, bool> isFacingCard = new Dictionary<int, bool>();
    public Button card_1, card_2, card_3, card_4, card_5, card_6, card_7, card_8, card_9, card_10, card_11, card_12;
    public Canvas canvas;



    // Start is called before the first frame update
    void Start()
    {
        if (!flag)
        {
            spritesName.Add(CardID.SUN);
            spritesName.Add(CardID.SUN);
            spritesName.Add(CardID.ASTEROID);
            spritesName.Add(CardID.ASTEROID);
            spritesName.Add(CardID.BANANA);
            spritesName.Add(CardID.BANANA);
            spritesName.Add(CardID.SATELLITE);
            spritesName.Add(CardID.SATELLITE);
            spritesName.Add(CardID.MOON);
            spritesName.Add(CardID.MOON);
            spritesName.Add(CardID.ALIENSHIP);
            spritesName.Add(CardID.ALIENSHIP);
            spritesName = spritesName.OrderBy(card => Guid.NewGuid()).ToList(); // aleatoire

            for(int i = 1; i <= 12; i++)
            {
                isFacingCard.Add(i, false);
            }

            float width = canvas.transform.GetComponent<RectTransform>().sizeDelta.x;
            float height = canvas.transform.GetComponent<RectTransform>().sizeDelta.y;
            float divWidth = width / (float)1125.2;
            float divHeight = height / (float)598.4;

            //card_1
            card_1.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 119);
            card_1.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 217);
            card_1.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)79.5, -divHeight * (float)128.5);

            //card_2
            card_2.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 119);
            card_2.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 217);
            card_2.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)119.5, -divHeight * (float)368.5);

            //card_3
            card_3.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 119);
            card_3.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 217);
            card_3.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)179.5, -divHeight * (float)188.5);

            //card_4
            card_4.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 119);
            card_4.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 217);
            card_4.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)259.5, -divHeight * (float)408.5);

            //card_5
            card_5.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 119);
            card_5.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 217);
            card_5.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)359.5, -divHeight * (float)168.5);

            //card_6
            card_6.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 119);
            card_6.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 217);
            card_6.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)499.5, -divHeight * (float)388.5);

            //card_7
            card_7.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 119);
            card_7.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 217);
            card_7.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)499.5, -divHeight * (float)148.5);

            //card_8
            card_8.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 119);
            card_8.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 217);
            card_8.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)639.5, -divHeight * (float)128.5);

            //card_9
            card_9.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 119);
            card_9.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 217);
            card_9.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)699.5, -divHeight * (float)468.5);

            //card_10
            card_10.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 119);
            card_10.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 217);
            card_10.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)759.5, -divHeight * (float)228.5);

            //card_11
            card_11.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 119);
            card_11.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 217);
            card_11.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)899.5, -divHeight * (float)368.5);

            //card_12
            card_12.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 119);
            card_12.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 217);
            card_12.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)1019.5, -divHeight * (float)228.5);

            //error
            err.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, divWidth * 239);
            err.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, divHeight * 57);
            err.GetComponent<RectTransform>().anchoredPosition = new Vector2(divWidth * (float)1019.5, -divHeight * (float)28.5);


            flag = true;
        }
    }

    void UpdateError()
    {
        switch (errors)
        {
            case 1:
                err.GetComponent<Image>().sprite = erreur4;
                break;
            case 2:
                err.GetComponent<Image>().sprite = erreur3;
                break;
            case 3:
                err.GetComponent<Image>().sprite = erreur2;
                break;
            case 4:
                err.GetComponent<Image>().sprite = erreur1;
                break;
            case 5:
                err.GetComponent<Image>().sprite = erreur0;
                break;
        }
    }


    public void OnSelection(Image card)
    {
        Debug.LogError(card.name);
        string[] names = card.name.Split('_');
        int nb = int.Parse(names[1]);
        if (!isFacingCard[nb] && CompareLastTwoCards())
        {
            isFacingCard[nb] = true;
            ChangeSide(spritesName[nb-1], card);
            Debug.LogError("entre");
        }
    }

    void ChangeSide(CardID cardID, Image card)
    {
        switch (cardID)
        {
            case CardID.SUN:
                card.sprite = sun;
                carteTirees.Add(card);
                break;
            case CardID.ASTEROID:
                card.sprite = asteroid;
                carteTirees.Add(card);
                break;
            case CardID.BANANA:
                card.sprite = banana;
                carteTirees.Add(card);
                break;
            case CardID.SATELLITE:
                card.sprite = satellite;
                carteTirees.Add(card);
                break;
            case CardID.MOON:
                card.sprite = moon;
                carteTirees.Add(card);
                break;
            case CardID.ALIENSHIP:
                card.sprite = alien_ship_alt;
                carteTirees.Add(card);
                break;
            case CardID.CARDBACK:
                card.sprite = card_back;
                break;
        }
        if (carteTirees.Count % 2 == 0 && carteTirees.Count != 0)
        { // vérification
            if (carteTirees[carteTirees.Count - 2].sprite.name == carteTirees[carteTirees.Count - 1].sprite.name)
            { // victoire
                if (carteTirees.Count == 12)
                {
                    SceneManager.LoadScene("Corridor_AA");
                }
            }
            else
            {
                errors++;
                UpdateError();
                if (errors == ERRORS_MAX)
                { // défaite
                    SceneManager.LoadScene("Hangar_AB");
                }
                StartCoroutine(Reset());
            }
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);
        string[] names = carteTirees[carteTirees.Count - 2].name.Split('_');
        int nb = int.Parse(names[1]);
        carteTirees[carteTirees.Count - 2].sprite = card_back;
        isFacingCard[nb] = false;
        names = carteTirees[carteTirees.Count - 1].name.Split('_');
        nb = int.Parse(names[1]);
        carteTirees[carteTirees.Count - 1].sprite = card_back;
        isFacingCard[nb] = false;
        carteTirees.RemoveAt(carteTirees.Count - 1);
        carteTirees.RemoveAt(carteTirees.Count - 1);
        yield return null;
    }

    /// <summary>
    /// Retourne vrai si les 2 dernieres cartes sont == ou si il n'y a pas 2 cartes.
    /// </summary>
    /// <returns></returns>
    bool CompareLastTwoCards()
    {
        if (carteTirees.Count >= 2 && carteTirees.Count % 2 == 0)
        {
            return carteTirees[carteTirees.Count - 2].sprite.name == carteTirees[carteTirees.Count - 1].sprite.name;
        }
        else
        {
            return true;
        }
    }

    public void restart()
    {
        errors = 0;
        flag = false;
        carteTirees = new List<Image>();
        new List<CardID>();
        // card variables
        nb_cards = 12;
        isFacingCard = new Dictionary<int, bool>();
        spritesName.Add(CardID.SUN);
        spritesName.Add(CardID.SUN);
        spritesName.Add(CardID.ASTEROID);
        spritesName.Add(CardID.ASTEROID);
        spritesName.Add(CardID.BANANA);
        spritesName.Add(CardID.BANANA);
        spritesName.Add(CardID.SATELLITE);
        spritesName.Add(CardID.SATELLITE);
        spritesName.Add(CardID.MOON);
        spritesName.Add(CardID.MOON);
        spritesName.Add(CardID.ALIENSHIP);
        spritesName.Add(CardID.ALIENSHIP);
        spritesName = spritesName.OrderBy(card => Guid.NewGuid()).ToList(); // aleatoire

        for (int i = 1; i <= 12; i++)
        {
            isFacingCard.Add(i, false);
        }
    }
}