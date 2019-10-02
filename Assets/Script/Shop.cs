using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missleTurret;
    public TurretBlueprint LaserBeamer;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStardardTurrent()
    {
        Debug.Log("StardardTurrent has been selected");
        buildManager.SelectTurrentToBuild(standardTurret);
    }

    public void SelectMissleTurrent()
    {
        Debug.Log("MissleTurrent has been selected");
        buildManager.SelectTurrentToBuild(missleTurret);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("LaserBeamer has been selected");
        buildManager.SelectTurrentToBuild(LaserBeamer);
    }


}
