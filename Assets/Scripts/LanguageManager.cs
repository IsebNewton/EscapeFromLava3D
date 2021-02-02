using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    //MainMenu
    public Text mainPlayButton;
    public Text mainOptionsButton;
    public Text mainQuitButton;
    public Text mainHelpButton;
    public Text mainShopButton;
    //OptionsMenu
    public Text optionsHeader;
    public Text optionsbackButton;
    public Text optionsEasyButton;
    public Text optionsMediumButton;
    public Text optionsHardButton;
    public Text optionsNightmareButton;
    public Text optionsDifficultyExplantion;
    public Text optionsLanguageGermanButton;
    public Text optionsLanguageEnglishButton;
    //HelpMenu
    public Text helpBackButton;
    public Text helpheader;
    public Text helpPCExplanation;
    public Text helpAndroidExplantion;
    public Text helpMiddelexplanation;
    //ShopMenu
    public Text shopBackButton;
    public Text shopHeader;
    public Text shopBeesDescription;
    public Text shopStarsDescription;
    public Text shopGolemDescription;
    public Text shopAstralDescription;
    public Text shopBeeBuyButton;
    public Text shopBeeEquipButton;
    public Text shopStarsBuyButton;
    public Text shopStarsEquipButton;
    public Text shopGolemBuyButton;
    public Text shopGolemEquipButton;
    public Text shopAstralBuyButton;
    public Text shopAstralEquipButton;
    public Text shopCoinDisplay;



    // Start is called before the first frame update
    void Start()
    {
        
        if(PlayerPrefs.GetString("Language") == "German")
        {
            SetLanguageGerman();
        }
        else if(PlayerPrefs.GetString("Language") == "English")
        {
            SetLanguageEnglish();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetLanguageEnglish()
    {

        PlayerPrefs.SetString("Language", "English");




        mainPlayButton.text = "Play";
        mainOptionsButton.text = "Options";
        mainQuitButton.text = "Quit";
        mainHelpButton.text = "Help";
        mainShopButton.text = "Shop";

        optionsHeader.text = "Options";
        optionsbackButton.text = "Back";
        optionsEasyButton.text = "Easy";
        optionsMediumButton.text = "Medium";
        optionsHardButton.text = "Hard";
        optionsNightmareButton.text = "Nightmare";
        optionsDifficultyExplantion.text = "Unlock harder difficulties by completing the previous one";
        optionsLanguageGermanButton.text = "German";
        optionsLanguageEnglishButton.text = "English";

        helpBackButton.text = "Back";
        helpheader.text = "Help";
        helpPCExplanation.text = "Use either A and D or the arrow keys to move from left to right. Press space to make a little jump and hold space for a big jump. Use those movements to avoid incoming obstacles. ";
        helpAndroidExplantion.text = "Press the left or the right side of your screen to move from left to right. Press the screen with two fingers to make a little jump and hold longer to make a big jump. Use those movements to avoid incoming obstacles.";
        helpMiddelexplanation.text = "The Arrow makes you jump higher. \n\nUse the thunderbolt to speed up. \n\nUse the angelwings to become invincible. ";
         



        shopBackButton.text = "Back";
        shopHeader.text = "Shop";
        shopBeesDescription.text = "BEEEEEES";
        shopStarsDescription.text = "Bring stars into your life";
        shopGolemDescription.text = "Awaken your inner golem";
        shopAstralDescription.text = "Am i the only ghost here?";
        shopBeeBuyButton.text = "Buy";
        shopBeeEquipButton.text = "Equip";
        shopStarsBuyButton.text = "Buy";
        shopStarsEquipButton.text = "Equip";
        shopGolemBuyButton.text = "Buy";
        shopGolemEquipButton.text = "Equip";
        shopAstralBuyButton.text = "Buy";
        shopAstralEquipButton.text = "Equip";
        shopCoinDisplay.text = "Your Coins : ";



    }





    public void SetLanguageGerman()
    {

        PlayerPrefs.SetString("Language", "German");




        mainPlayButton.text = "Spielen";
        mainOptionsButton.text = "Optionen";
        mainQuitButton.text = "Beenden";
        mainHelpButton.text = "Hilfe";
        mainShopButton.text = "Shop";

        optionsHeader.text = "Optionen";
        optionsbackButton.text = "Zurück";
        optionsEasyButton.text = "Leicht";
        optionsMediumButton.text = "Mittel";
        optionsHardButton.text = "Schwer";
        optionsNightmareButton.text = "Albtraum";
        optionsDifficultyExplantion.text = "Schalte schwerere Schwierigkeiten durch beenden des vorherigen";
        optionsLanguageGermanButton.text = "Deutsch";
        optionsLanguageEnglishButton.text = "Englisch";

        helpBackButton.text = "Zurück";
        helpheader.text = "Hilfe";
        helpPCExplanation.text = "Nutze entweder A und D oder die Pfeiltasten um dich von links nach rechts zu bewegen. Presse die Leertaste kurz um einen kleinen Sprung zu machen und halte sie für einen Großen Sprung. Nutze diese Bewegungen um den kommenden Hindernissen auszuweichen";
        helpAndroidExplantion.text = "Tippe auf die linke oder rechte Seite des Bildschirms um dich von links nach rechts zu bewegen. Berühre den Bildschirm kurz mit beiden Fingern um einen kleinen Sprung zu machen und halte ihn um einen großen Sprung zu machen. Nutze diese Bewegungen um den Hindernissen auszuweichen";
        helpMiddelexplanation.text = "Der Pfeil lässt dich höher springen. \n\nBenutze den Blitz um schneller zu werden. \n\nBenutze die Engelsflügel um Unverwundbar zu werden";

        shopBackButton.text = "Zurück";
        shopHeader.text = "Shop";
        shopBeesDescription.text = "Biiiieeeenen";
        shopStarsDescription.text = "Bringe Sterne in dein Leben";
        shopGolemDescription.text = "Erwecke deinen inneren Golem";
        shopAstralDescription.text = "Bin ich hier der einzige Geist?";
        shopBeeBuyButton.text = "Kaufen";
        shopBeeEquipButton.text = "Ausrüsten";
        shopStarsBuyButton.text = "Kaufen";
        shopStarsEquipButton.text = "Ausrüsten";
        shopGolemBuyButton.text = "Kaufen";
        shopGolemEquipButton.text = "Ausrüsten";
        shopAstralBuyButton.text = "Kaufen";
        shopAstralEquipButton.text = "Ausrüsten";
        shopCoinDisplay.text = "Deine Münzen : ";



    }


}
