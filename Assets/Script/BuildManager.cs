using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private TurretBlueprint turretToBuild;
    private Node selectNode;   

    public NodeUI nodeUI;

    //instance
    void Awake () {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public void SelectNode(Node node)
    {
        if (selectNode == node)
        {
            DeselectNode();
            return;
        }

        selectNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectNode = null;
        nodeUI.Hide();
    }

    //shop clicked call this
    public void SelectTurrentToBuild(TurretBlueprint Turret)
    {
        turretToBuild = Turret;
        DeselectNode();
    }  

    // is there can build
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStatus.Money >= turretToBuild.cost; } }

    public TurretBlueprint GetTurretToBuild ()
    {
        return turretToBuild;
    }

  
}
