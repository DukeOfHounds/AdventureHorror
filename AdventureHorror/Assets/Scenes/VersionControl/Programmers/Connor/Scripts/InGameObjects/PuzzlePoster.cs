using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePoster : MonoBehaviour
{
    public WireData WD;
    public Color[] colorOrderArray;

    // Start is called before the first frame update
    void Start()
    {
        
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
            wire.setColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
            WD.WireOrder.Add(wire);
            WD.Wires.RemoveAt(r);
        }
    }
}
