using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poster : MonoBehaviour
{
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(reInitialize());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Initialize(Color wire1, Color wire2, Color wire3, Color wire4)
    {
        Color.Lerp(mat.GetColor("Wire1Color"), Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), Mathf.PingPong(Time.time, 1));
        mat.SetColor("Wire1Color", wire1);
        mat.SetColor("Wire2Color", wire2);
        mat.SetColor("Wire3Color", wire3);
        mat.SetColor("Wire4Color", wire4);
    }

    IEnumerator reInitialize()
    {
        mat.SetColor("Wire1Color", Color.Lerp(mat.GetColor("Wire1Color"), Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 1f));
        mat.SetColor("Wire2Color", Color.Lerp(mat.GetColor("Wire2Color"), Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 1f));
        mat.SetColor("Wire3Color", Color.Lerp(mat.GetColor("Wire3Color"), Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 1f));
        mat.SetColor("Wire4Color", Color.Lerp(mat.GetColor("Wire4Color"), Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 1f));
        yield return new WaitForSeconds(1f);
        StartCoroutine(reInitialize());
    }
}
