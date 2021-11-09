using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePoster : MonoBehaviour
{
    public Queue<int> colorOrder = new Queue<int>();
    public int[] colorOrderArray;
    private int numberOfWireBoxes = 4;
    // Start is called before the first frame update
    void Awake()
    {
        //colorOrder.CopyTo(colorOrderArray, 4);
        int r = Random.Range(1, numberOfWireBoxes);
        Debug.Log(r);
        switch (r) // Red = 1, Blue = 2, Green = 3, Yellow = 4
        {
            case 1:
                colorOrder.Enqueue(4); //Yellow
                colorOrder.Enqueue(3); //Green
                colorOrder.Enqueue(1); //Red
                colorOrder.Enqueue(2); //Blue
                break;
            case 2:
                colorOrder.Enqueue(1); //Red
                colorOrder.Enqueue(2); //Blue
                colorOrder.Enqueue(3); //Green
                colorOrder.Enqueue(4); //Yellow
                break;
            case 3:
                colorOrder.Enqueue(3); //Green
                colorOrder.Enqueue(2); //Blue
                colorOrder.Enqueue(4); //Yellow
                colorOrder.Enqueue(1); //Red
                break;
            case 4:
                colorOrder.Enqueue(2); //Blue
                colorOrder.Enqueue(4); //Yellow
                colorOrder.Enqueue(1); //Red
                colorOrder.Enqueue(3); //Green
                break;
        }
        Debug.Log(colorOrder);
    }
    public int NextWireColor()
    {
        if (colorOrder.Count != 0)
            return colorOrder.Dequeue();
        else return 0;
    }
}
