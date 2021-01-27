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

    float beeBaught;
    float starsBaught;
    float golemBaught;
    float astralBaught;

    public Text coinsText;

    // Start is called before the first frame update
    void Start()
    {
        beeBaught = PlayerPrefs.GetFloat("BeeBaught");
        starsBaught = PlayerPrefs.GetFloat("StarsBaught");
        golemBaught = PlayerPrefs.GetFloat("GolemBaught");
        astralBaught = PlayerPrefs.GetFloat("AstralBaught");




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

        if(starsBaught >= 1)
        {
            starsEquip.enabled = true;
            starsBuy.enabled = false;
            starsText.text = "Baught";
        }
        else
        {
            starsEquip.enabled = false;
            starsBuy.enabled = true;
            starsText.text = "3000";
        }

        if (golemBaught >= 1)
        {
            golemEquip.enabled = true;
            golemBuy.enabled = false;
            golemText.text = "Baught";
        }
        else
        {
            golemEquip.enabled = false;
            golemBuy.enabled = true;
            golemText.text = "5000";
        }

        if (astralBaught >= 1)
        {
            astralEquip.enabled = true;
            astralBuy.enabled = false;
            astralText.text = "Baught";
        }
        else
        {
            astralEquip.enabled = false;
            astralBuy.enabled = true;
            astralText.text = "10000";
        }


    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Your coins: " + generalCoins;
    }


    public void BuyBee()
    {

        if (generalCoins >= 1000)
        {
            PlayerPrefs.SetFloat("BeeBaught", 1);
            beeEquip.enabled = true;
            beeBuy.enabled = false;
            beeText.text = "Baught";
            generalCoins -= 1000;
            PlayerPrefs.SetFloat("GeneralCoins", generalCoins);
        }
    }
    public void EquipBee()
    {
        PlayerPrefs.SetString("Skin", "Bee");
        if (beeBaught >= 1)
        {
            beeText.text = "Equipped";
        }
        if (starsBaught >= 1)
        {
            starsText.text = "Baught";
        }
        if (golemBaught >= 1)
        {
            golemText.text = "Baught";
        }
        if (astralBaught >= 1)
        {
            astralText.text = "Baught";
        }
    }

    public void BuyStars()
    {

        if (generalCoins >= 3000)
        {
            PlayerPrefs.SetFloat("StarsBaught", 1);
            starsEquip.enabled = true;
            starsBuy.enabled = false;
            starsText.text = "Baught";
            generalCoins -= 3000;
            PlayerPrefs.SetFloat("GeneralCoins", generalCoins);
        }
    }
    public void EquipStars()
    {
        PlayerPrefs.SetString("Skin", "Stars");
        if (beeBaught >= 1)
        {
            beeText.text = "Baught";
        }
        if (starsBaught >= 1)
        {
            starsText.text = "Equipped";
        }
        if (golemBaught >= 1)
        {
            golemText.text = "Baught";
        }
        if (astralBaught >= 1)
        {
            astralText.text = "Baught";
        }
    }

    public void BuyGolem()
    {

        if (generalCoins >= 5000)
        {
            PlayerPrefs.SetFloat("GolemBaught", 1);
            golemEquip.enabled = true;
            golemBuy.enabled = false;
            golemText.text = "Baught";
            generalCoins -= 5000;
            PlayerPrefs.SetFloat("GeneralCoins", generalCoins);
        }
    }
    public void EquipGolem()
    {
        PlayerPrefs.SetString("Skin", "Golem");
        if (beeBaught >= 1)
        {
            beeText.text = "Baught";
        }
        if (starsBaught >= 1)
        {
            starsText.text = "Baught";
        }
        if (golemBaught >= 1)
        {
            golemText.text = "Equipped";
        }
        if (astralBaught >= 1)
        {
            astralText.text = "Baught";
        }
    }

    public void BuyAstral()
    {

        if (generalCoins >= 10000)
        {
            PlayerPrefs.SetFloat("AstralBaught", 1);
            astralEquip.enabled = true;
            astralBuy.enabled = false;
            astralText.text = "Baught";
            generalCoins -= 10000;
            PlayerPrefs.SetFloat("GeneralCoins", generalCoins);
        }
    }
    public void EquipAstral()
    {
        PlayerPrefs.SetString("Skin", "Astral");
        if (beeBaught >= 1)
        {
            beeText.text = "Baught";
        }
        if (starsBaught >= 1)
        {
            starsText.text = "Baught";
        }
        if (golemBaught >= 1)
        {
            golemText.text = "Baught";
        }
        if (astralBaught >= 1)
        {
            astralText.text = "Equipped";
        }
    }










}
