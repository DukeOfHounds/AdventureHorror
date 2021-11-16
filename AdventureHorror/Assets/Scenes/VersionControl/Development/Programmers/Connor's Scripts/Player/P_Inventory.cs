using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class P_Inventory
{
    private PlayerData PD;
    private Player player;
    private List<GameObject> tools = new List<GameObject>();
    private Vector3 rotation = new Vector3(0, 0, 0);
    private MeshRenderer mr;
    private bool toolHidden = true;

    public P_Inventory(PlayerData PD)
    {
        this.PD = PD;
        this.player = PD.player;
        PD.inventory = this;
    }

    public void ThrowObj()
    {
        GameObject obj = PD.inHand;

    }

    public void AddTool(GameObject tool)
    {  
            tools.Add(tool);
    }
    public void DisplayTool(string toolName)
    {
        foreach(GameObject tool in tools)
        {
            Tools t = tool.GetComponent<Tools>();
            if (t.IsTool().Equals(toolName))
            {
                mr = tool.GetComponentInChildren<MeshRenderer>();
                PD.inToolHand = tool;
                mr.enabled = true;
                toolHidden = false;
            }
        }
    }
    public void HideTool()
    {
        if (!toolHidden)
        {
            mr.enabled = false;
            PD.inToolHand = null;
            toolHidden = true;
        }
    }

    public bool hasTool(string toolName)
    {
        foreach (GameObject tool in tools)
        {
            Tools t = tool.GetComponent<Tools>();
            if (t.IsTool().Equals(toolName))
            {
                return true;
                
            }
        }
        return false;
    }
}
