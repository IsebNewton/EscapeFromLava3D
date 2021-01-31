using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{


    public bool eventCooldown = false;
    public Light playerLight;
    public GameObject playerLightUI;



    public float duration = 0.4f;


    // Start is called before the first frame update
    void Start()
    {
        playerLightUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (eventCooldown == false)
        {
            float rand = Random.Range(0, 10000);
    
            if (rand >= 9999)
            {

                float eventRand =Random.Range(0, 2);
                if(eventRand == 0)
                {
                    playerLightUI.SetActive(true);
                    playerLight.intensity = 0.1f;

                    float counter = 0;
                    CanvasGroup canvgroup = playerLightUI.GetComponent<CanvasGroup>();
                    while(counter < duration)
                    {
                        counter += Time.deltaTime;
                        canvgroup.alpha = Mathf.Lerp(canvgroup.alpha, 1 , counter / duration);
                    }

                    Invoke("LightEventFadeout", 3);
                    Invoke("LightEventReset", 15);


                }
                if(eventRand == 1)
                {

                }




                eventCooldown = true;
                Invoke("StopEventCooldown", 30);
            }
        }



    }


    public void StopEventCooldown()
    {
        eventCooldown = false;
    }

    public void LightEventReset()
    {
        playerLight.intensity = 1.5f;
    }

    public void LightEventFadeout()
    {
        float counter = 0;
        CanvasGroup canvgroup = playerLightUI.GetComponent<CanvasGroup>();
        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvgroup.alpha = Mathf.Lerp(canvgroup.alpha, 0, counter / duration);
        }
        playerLightUI.SetActive(false);
    }


}
