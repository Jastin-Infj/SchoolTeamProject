using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    private AudioSource[] audioSource;
	// Use this for initialization
	void Start ()
    {
        this.audioSource = this.gameObject.GetComponents<AudioSource>();
        for(int i = 0; i < this.audioSource.Length;++i)
        {
            this.audioSource[i].enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void SoundPlay()
    {
        for(int i = 0; i < this.audioSource.Length;++i)
        {
            if(this.audioSource[i].enabled)
            {
                this.audioSource[i].Play();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.audioSource[0].enabled = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        this.audioSource[0].enabled = false;
    }
    public void SoundStateChange(int Sound)
    {
        this.audioSource[Sound].enabled = true;
    }
}
