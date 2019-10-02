using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    private Renderer rend;

    public Color hoverColor;
    private Color startColor;
    public Color NotEnoughMoneyColor;

    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgrade = false;
 
    BuildManager buildManager;
    

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    //click
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

       
        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild) return;

        BuildTurret(buildManager.GetTurretToBuild() );
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStatus.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }
        PlayerStatus.Money -= blueprint.cost;

        GameObject turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        turretBlueprint = blueprint;

        GameObject effect = Instantiate(blueprint.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret Build! Money Left : " + PlayerStatus.Money);
    }

    public void UpgadeTurret()
    {
        if (PlayerStatus.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgade!");
            return;
        }
        PlayerStatus.Money -= turretBlueprint.upgradeCost;

        // destroy old one
        Destroy(this.turret);

        //create new
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        this.turret = _turret;

        GameObject effect = Instantiate(turretBlueprint.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgrade = true;
        Debug.Log("Turret upGade " + PlayerStatus.Money);
    }

    //hover
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = NotEnoughMoneyColor;
        }

        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void SellTurret()
    {
        PlayerStatus.Money += turretBlueprint.GetSellAmount();

        GameObject effect = Instantiate(turretBlueprint.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

}
