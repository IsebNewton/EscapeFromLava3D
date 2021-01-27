using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private GameObject player;
    private PlayerController playerController;
    public int playerLevel = 1;
    public GameObject[] levels;
    public GameObject[] levelsAlternative;
    public float levelPosition = 200;
    public float difLevel;
    public float hardLevel = 1;
    public SplitManager splitManager;

    public GameObject musicObject;
    public AudioSource musicAudio;
    public bool musicPlaying = false;

    public bool mushroom = false;
    public bool stopMushroom = false;
    public float savedPitch;

    public bool alternateLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        splitManager = GameObject.Find("SplitManager").GetComponent<SplitManager>();
        Debug.Log(splitManager);
        playerLevel = 1;
        Debug.Log(levels[28]);

       

        
    }

    // Update is called once per frame
    void Update()
    {

        //if(playerController.playerMovementSpeed > 5 && musicPlaying == false)
        //{
        //    musicAudio.Play();
        //}
         
        if(player.transform.position.z >= levelPosition)
        {
            Debug.Log("Level vorher =" + playerLevel);
            playerLevel++;
            if(mushroom == true)
            {
                stopMushroom = true;
            }
            Debug.Log("Level danach =" + playerLevel);
            Debug.Log(levels.Length);
            Debug.Log(playerLevel - 2);
            Debug.Log(levels[playerLevel - 2]);

            float rand = Random.Range(0, 5);
            if (rand < 3)
            {
                Object.Instantiate(levels[playerLevel - 2], new Vector3(0, 0, (levelPosition + 100)), levels[playerLevel - 2].transform.rotation);
                alternateLevel = false;
            }
            else if (rand >= 3)
            {
                Object.Instantiate(levelsAlternative[playerLevel - 2], new Vector3(0, 0, (levelPosition + 100)), levelsAlternative[playerLevel - 2].transform.rotation);
                alternateLevel = true;
            }
            levelPosition += 200;
            Debug.Log(playerLevel);
            splitManager.increased = false;
            Invoke("ActivateDirtParticle", 1);
        }

        if (playerLevel == 17 || playerLevel == 18 || playerLevel == 19)
        {
            Debug.Log("Sollte kommen für music");
            if (mushroom == false)
            {
                savedPitch = musicAudio.pitch;
            }
            Debug.Log(savedPitch);
            mushroom = true;
            musicAudio.pitch = -1;
        }
        if (stopMushroom == true)
        {
            musicAudio.pitch = savedPitch;
        }

        if (difLevel == 4)
        {
            musicAudio.pitch = 1.04f;
        }
        if (difLevel == 6)
        {
            musicAudio.pitch = 1.08f;
        }
        if (difLevel == 8)
        {
            musicAudio.pitch = 1.12f;
        }



        switch (playerLevel)
        {
            case 1:
                difLevel = 1;
                hardLevel = 1;
                break;
            case 2:
                difLevel = 2;
                hardLevel = 1;
                break;
            case 3:
                difLevel = 2;
                hardLevel = 1;
                break;
            case 4:
                difLevel = 3;
                hardLevel = 2;
                break;
            case 5:
                difLevel = 3;
                hardLevel = 1;
                break;
            case 6:
                difLevel = 3;
                hardLevel = 1;
                break;
            case 7:
                difLevel = 4;
                hardLevel = 1;
                break;
            case 8:
                difLevel = 4;
                hardLevel = 1;
                break;
            case 9:
                difLevel = 4;
                hardLevel = 1;
                break;
            case 10:
                difLevel = 5;
                hardLevel = 2;
                break;
            case 11:
                difLevel = 5;
                hardLevel = 1;
                break;
            case 12:
                difLevel = 5;
                hardLevel = 2;
                break;
            case 13:
                difLevel = 5;
                hardLevel = 1;
                break;
            case 14:
                difLevel = 6;
                hardLevel = 1;
                break;
            case 15:
                difLevel = 6;
                hardLevel = 1;
                break;
            case 16:
                difLevel = 6;
                hardLevel = 1;
                break;
            case 17:
                difLevel = 7;
                hardLevel = 1;
                break;
            case 18:
                difLevel = 7;
                hardLevel = 1;
                break;
            case 19:
                difLevel = 7;
                hardLevel = 1;
                break;
            case 20:
                difLevel = 8;
                hardLevel = 1;
                break;
            case 21:
                difLevel = 8;
                hardLevel = 1;
                break;
            case 22:
                difLevel = 8;
                hardLevel = 2;
                break;
            case 23:
                difLevel = 8;
                hardLevel = 1;
                break;
            case 24:
                difLevel = 9;
                hardLevel = 1;
                break;
            case 25:
                difLevel = 9;
                hardLevel = 1;
                break;
            case 26:
                difLevel = 9;
                hardLevel = 1;
                break;
            case 27:
                difLevel = 10;
                hardLevel = 1;
                break;
            case 28:
                difLevel = 10;
                hardLevel = 1;
                break;
            case 29:
                difLevel = 10;
                hardLevel = 1;
                break;
            case 30:
                difLevel = 10;
                hardLevel = 1;
                break;
        }







    }

    public void ActivateDirtParticle()
    {
        playerController.dirtParticle.Play();
    }
}
