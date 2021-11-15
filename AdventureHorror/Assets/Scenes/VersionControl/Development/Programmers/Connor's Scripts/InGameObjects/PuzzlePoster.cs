using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePoster : MonoBehaviour
{
    public WireData WD;
    public LightManager lightManager;
    public Material mat;

    private ArrayList colors = new ArrayList { 0, 1, 2, 3 };

    // Start is called before the first frame update
    void Start()
    {
        lightManager = gameObject.GetComponentInChildren<LightManager>();
        WD.puzzlePoster = this;
        StartCoroutine(SetColor());
    }
    IEnumerator SetColor()
    {
        Wire wire;
        yield return new WaitForSeconds(1f);
        while (WD.Wires.Count != 0)
        {
            int r = Random.Range(0, WD.Wires.Count - 1);
            wire = WD.Wires[r];
            SetColor(wire);
            WD.WireOrder.Add(wire);
            WD.Wires.RemoveAt(r);
        }
        yield return new WaitForSeconds(.02f);

        mat.SetColor("Wire1Color", WD.WireOrder[0].color);
        mat.SetColor("Wire2Color", WD.WireOrder[1].color);
        mat.SetColor("Wire3Color", WD.WireOrder[2].color);
        mat.SetColor("Wire4Color", WD.WireOrder[3].color);

    }

    private void SetColor(Wire wire)
    {
       
        //wire.setColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        int r = Random.Range(0, colors.Count);
        //Debug.Log(colors.Count);
        //Debug.Log(r);

        switch (colors[r])
        {
            case 0:
                wire.setColor(Color.red);
                break;
            case 1:
                wire.setColor(Color.blue);
                break;
            case 2:
                wire.setColor(Color.green);
                break;
            case 3:
                wire.setColor(Color.yellow);
                break;
        }
        //Debug.Log(wire.color);
        colors.RemoveAt(r);
    }
}
