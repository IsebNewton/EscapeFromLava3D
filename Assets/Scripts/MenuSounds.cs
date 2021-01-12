using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{

    public GameObject hoverObject;
    public AudioSource hoverAudio;

    // Start is called before the first frame update
    void Start()
    {
        hoverAudio = hoverObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlaySound()
    {
        hoverAudio.Play();
    }


}
