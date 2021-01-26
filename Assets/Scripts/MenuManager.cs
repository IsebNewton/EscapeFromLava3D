using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public float generalCoins;
    public float maxLevel;

    public Image mediumButtonCover;
    public Image hardButtonCover;
    public Image nightmareButtonCover;

    public Button beeBuy;
    public Button beeEquip;
    public Button starsBuy;
    public Button starsEquip;
    public Button golemBuy;
    public Button golemEquip;
    public Button astralBuy;
    public Button astralEquip;

    public Text beeText;
    public Text starsText;
    public Text golemText;
    public Text astralText;

    // Start is called before the first frame update
    void Start()
    {
        generalCoins = PlayerPrefs.GetFloat("GeneralCoins");
        maxLevel = PlayerPrefs.GetFloat("MaxLevel");

   

        if (maxLevel > 0.9)//Medium freigeschaltet
        {
            mediumButtonCover.enabled = false;
            hardButtonCover.enabled = true;
            nightmareButtonCover.enabled = true;
        }
        if (maxLevel > 1.2)//Hard freigeschaltet
        {
            mediumButtonCover.enabled = false;
            hardButtonCover.enabled = false;
            nightmareButtonCover.enabled = true;
        }
        if (maxLevel > 1.4)//Nightmare Freigeschaltet
        {
            mediumButtonCover.enabled = false;
            hardButtonCover.enabled = false;
            nightmareButtonCover.enabled = false;
        }

        float beeBaught = PlayerPrefs.GetFloat("BeeBaught");
        float starsBaught = PlayerPrefs.GetFloat("StarsBaught");
        float golemBaught = PlayerPrefs.GetFloat("GolemBaught");
        float AstralBaught = PlayerPrefs.GetFloat("AstralBaught");
        if (beeBaught >= 1)
        {
            beeEquip.enabled = true;
            beeBuy.enabled = false;
            beeText.text = "Baught";
        }
        else
        {
            beeEquip.enabled = false;
            beeBuy.enabled = true;
            beeText.text = "1000";
        }






    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuyBee()
    {
        PlayerPrefs.SetFloat("BeeBaught", 1);
        beeEquip.enabled = true;
        beeBuy.enabled = false;
        beeText.text = "Baught";
    }







    //ShopMenu
    //
    //
    //
    //
    //
    //
    //
    //
    //--------










}
