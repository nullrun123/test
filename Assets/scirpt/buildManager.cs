using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class buildManager : MonoBehaviour
{

    public static buildManager instance;
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }


  

   
    public GameObject standardTurretPrefab;
    public GameObject RocketStandardTurret;
    public GameObject BuildEffect;
    private TurretBlueprint turretToBuild;

    //Canbuild buy
    public bool CanBuild {  get {  return turretToBuild != null; } }    

    //merge not use
    public bool HasMoney {  get { return PlayerState.money >= turretToBuild.cost; } }
    public void BuildTurretOn(Node node)
    {
        //buy (not use to merge)
        if(PlayerState.money < turretToBuild.cost)
        {
            Debug.Log("Not enough");
            return;
        }
        //buy (not use to merge)
        PlayerState.money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetbuildPosition(), Quaternion.identity);
        node.turret = turret;
          

        //effect build
        GameObject effect = (GameObject)Instantiate(BuildEffect, node.GetbuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }
    //buy
    public void SelectTurretTobuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
