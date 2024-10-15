using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    //sell
    public TurretBlueprint StandardTurret;
    public TurretBlueprint RocketStandardTurret;
    public TurretBlueprint laserTurret;
    buildManager buildManager;

    void Start()
    {
        buildManager = buildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("You got Turret");
        buildManager.SelectTurretTobuild(StandardTurret);
    }
    public void SelectRocketStandardTurret()
    {
        Debug.Log("You got Rocket");
        buildManager.SelectTurretTobuild(RocketStandardTurret);
    }
    public void SelectLaserStandardTurret()
    {
        Debug.Log("You got Laser");
        buildManager.SelectTurretTobuild(laserTurret);
    }
}
