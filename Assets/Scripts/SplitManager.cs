using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitManager : MonoBehaviour
{
    private GameObject player;
    private LevelManager levelManager;
    public float grenze = 0;
    public GameObject split;
    public bool increased = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.z > grenze)
        {
            if (levelManager.playerLevel != 29 && levelManager.playerLevel != 28)
            {
                Instantiate(split, new Vector3(0, 5, grenze + 195), split.transform.rotation);
                grenze += 200;
            }
        }


    }



    public void SetNextLevel(Collider other)
    {

        if (increased == false)
        {

            if (levelManager.playerLevel == 1)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 1;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 2;
                    increased = true;

                }
            }
            //--------------------------------------



            else if (levelManager.playerLevel == 2)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 3;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 4;
                    increased = true;
                }
            }
            //--------------------------------------


            else if (levelManager.playerLevel == 3)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 4;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 5;
                    increased = true;
                }
            }
            //--------------------------------------



            else if (levelManager.playerLevel == 4)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 10;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 10;
                    increased = true;
                }
            }
            //--------------------------------------



            else if (levelManager.playerLevel == 5)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 6;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 7;
                    increased = true;
                }
            }
            //--------------------------------------






            else if (levelManager.playerLevel == 6)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 7;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 8;
                    increased = true;
                }
            }
            //--------------------------------------




            else if (levelManager.playerLevel == 7)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 8;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 9;
                    increased = true;
                }
            }
            //--------------------------------------




            else if (levelManager.playerLevel == 8)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 10;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 12;
                    increased = true;
                }
            }
            //--------------------------------------




            else if (levelManager.playerLevel == 9)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 11;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 12;
                    increased = true;
                }
            }
            //--------------------------------------







            else if (levelManager.playerLevel == 10)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 16;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 16;
                    increased = true;
                }
            }
            //--------------------------------------






            else if (levelManager.playerLevel == 11)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 13;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 14;
                    increased = true;
                }
            }
            //--------------------------------------






            else if (levelManager.playerLevel == 12)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 18;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 18;
                    increased = true;
                }
            }
            //--------------------------------------









            else if (levelManager.playerLevel == 13)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 14;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 15;
                    increased = true;
                }
            }
            //--------------------------------------







            else if (levelManager.playerLevel == 14)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 16;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 17;
                    increased = true;
                }
            }
            //--------------------------------------










            else if (levelManager.playerLevel == 15)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 16;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 18;
                    increased = true;
                }
            }
            //--------------------------------------










            else if (levelManager.playerLevel == 16)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 17;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 18;
                    increased = true;
                }
            }
            //--------------------------------------









            else if (levelManager.playerLevel == 17)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 19;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 20;
                    increased = true;
                }
            }
            //--------------------------------------











            else if (levelManager.playerLevel == 18)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 20;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 21;
                    increased = true;
                }
            }
            //--------------------------------------






            else if (levelManager.playerLevel == 19)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 20;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 22;
                    increased = true;
                }
            }
            //--------------------------------------



            else if (levelManager.playerLevel == 20)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 23;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 24;
                    increased = true;
                }
            }
            //--------------------------------------



            else if (levelManager.playerLevel == 21)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 24;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 25;
                    increased = true;
                }
            }
            //--------------------------------------




            else if (levelManager.playerLevel == 22)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 27;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 27;
                    increased = true;
                }
            }
            //--------------------------------------



            else if (levelManager.playerLevel == 23)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 24;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 25;
                    increased = true;
                }
            }
            //--------------------------------------




            else if (levelManager.playerLevel == 24)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 26;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 26;
                    increased = true;
                    Debug.Log("23");
                }
            }
            //--------------------------------------




            else if (levelManager.playerLevel == 25)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 26;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 27;
                    increased = true;
                    Debug.Log("24");
                }
            }
            //--------------------------------------







            else if (levelManager.playerLevel == 26)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 27;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 27;
                    increased = true;
                    Debug.Log("25");
                }
            }
            //--------------------------------------







            else if (levelManager.playerLevel == 27)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 28;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 29;
                    increased = true;
                    Debug.Log("26");
                }
            }
            //--------------------------------------





            else if (levelManager.playerLevel == 28)
            {

                if (other.tag == "SplitLeft")
                {
                    levelManager.playerLevel = 28;
                    increased = true;
                }


                if (other.tag == "SplitRight")
                {
                    levelManager.playerLevel = 29;
                    increased = true;
                    Debug.Log("27");
                }
            }
            //--------------------------------------

        }
    }






}
    
