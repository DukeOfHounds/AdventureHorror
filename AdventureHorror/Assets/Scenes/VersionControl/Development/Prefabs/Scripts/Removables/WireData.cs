using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WireData", menuName = "WireData/Generic")]
public class WireData : ScriptableObject
{
    [SerializeField]
    [Header("Ignore all")]
    public int count = 0;
    public List<Wire> WireOrder = new List<Wire>();
    public List<Wire> Wires = new List<Wire>();
    public Door door;
    public PuzzlePoster puzzlePoster;
}
