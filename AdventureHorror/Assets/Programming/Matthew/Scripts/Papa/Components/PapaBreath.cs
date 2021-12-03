using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapaBreath : MonoBehaviour
{
    public Papa papa;

    public AudioSource s1;
    public AudioSource s2;
    public AudioSource s3;
    AudioClip currentSound;
    public List<SoundStruct> soundList;
    bool clipPlaying;
    int index;

    void Start()
    {
        //s1 = GetComponent<AudioSource>();
    }

    void Update()
    {
        switch (papa.ppM.currentState)
        {
            case PP_Movement.State.StartSearch:
                LightBreath();
                break;

            case PP_Movement.State.Search:
                LightBreath();
                break;

            case PP_Movement.State.Chase:
                HeavyBreath();
                break;

            case PP_Movement.State.ResetWires:
                HeavyBreath();
                break;
        }

    }
    public void LightBreath()
    {
        currentSound = soundList[0].clip;
        if (!s1.isPlaying)
        {
            s1.clip = currentSound;
            s1.time = .2f;
            s1.Play();
        }
    }
    public void HeavyBreath()
    {
        currentSound = soundList[1].clip;
        if (!s2.isPlaying)
        {
            s2.clip = currentSound;
            s2.time = .2f;
            s2.Play();
        }
    }
}

