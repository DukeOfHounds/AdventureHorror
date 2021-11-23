using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    public Transform hidingSpot;
    public Transform exitSpot;
    private Vector3 exitposition;
    private Vector3 hidingposition;
    public AudioSource heartBeat;
    public AudioSource activeBreath;
    public AudioSource inactiveBreath;

    private PlayerData PD;
    float timeMultiplier = 0.4f;

    private Door door;
    public bool isHiding;

    private void Awake()
    {
        door = GetComponent<Door>();
        exitposition = exitSpot.position;
        hidingposition = hidingSpot.position;
    }



    public void interactWith(PlayerData PD)
    {
        this.PD = PD;

        if (!isHiding)
        {
            PlayHideSounds();
            StartCoroutine(Hide());
            if (PD.player.ppD.canSeeTarget)
            {
                PD.player.ppD.sawHiding = true;
            }
        }
        else
        {
            StartCoroutine(Unhide());
            StartCoroutine(StopHideSounds());

            if (PD.player.ppD.canSeeTarget)
            {
                PD.player.ppD.sawHiding = false;
            }
        }
    }
    IEnumerator Unhide()
    {
        float duration;
        door.Open();//Open Door
        yield return new WaitForSeconds(.2f);
        duration = (exitposition - PD.player.gameObject.transform.position).magnitude * timeMultiplier;
        StartCoroutine(LerpPosition(exitposition, duration));// Lerp player.transform out of hidingPlace.transform
        //re-enable wasd  
        yield return new WaitForSeconds(1f);
        door.Close();//door closes
        isHiding = false;
        PD.isHiding = isHiding;

    }
    IEnumerator Hide()
    {
        float duration;
        isHiding = true;
        PD.isHiding = isHiding;
        door.Open();//Door Opens
        yield return new WaitForSeconds(.2f);
        duration = (exitposition - PD.player.gameObject.transform.position).magnitude * timeMultiplier;
        StartCoroutine(LerpPosition(exitposition, duration));//Lerp player.transform to hidingPlace.transform
        yield return new WaitForSeconds(duration);
        duration = (hidingposition - PD.player.gameObject.transform.position).magnitude * timeMultiplier;
        StartCoroutine(LerpPosition(hidingposition, duration));//Lerp player.transform to hidingPlace.transform
        yield return new WaitForSeconds(1f);
        door.Close();//door closes
        yield return new WaitForSeconds(1f);

    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = PD.player.gameObject.transform.position;

        while (time < duration)
        {
            PD.player.gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
            yield return null;
        }
        PD.player.gameObject.transform.position = targetPosition;
    }
    public void PlayHideSounds()
    {

        door.PlaySound();
        activeBreath.loop = true;
        heartBeat.loop = true;
        Debug.Log("active Breathing exercies is: " + activeBreath.isPlaying);
        if (!activeBreath.isPlaying)
            activeBreath.Play();
        Debug.Log("active Breathing exercies is: " + activeBreath.isPlaying);
        if (!heartBeat.isPlaying)
            heartBeat.Play();

    }
    IEnumerator StopHideSounds()
    {

        door.PlaySound();
        activeBreath.loop = false;
        heartBeat.loop = false;
        activeBreath.Stop();
        inactiveBreath.Play();
        yield return new WaitForSeconds(0f);
    }
}