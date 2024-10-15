using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;
    //gunn
    [Header("General")]
    public float range = 15f;

    [Header("Use Bullet")]
    public GameObject bulletprefab;
    public float firerate = 1f;
    private float fireCountdown = 0f;

    [Header("Laser Setup")]
    public bool uselaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactlight;
    public int damageOverTime = 30;


    [Header("unity Setup")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    
    public Transform firepoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }

    // Update is called once per frame
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);       
            if(distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if(target == null)
        {
            if (uselaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactlight.enabled = false;
                }
                   
            }

            return;
        }
            

        LockOnTarget();

        //check is Laser?
        if (uselaser)
        {
            Laser();
        }
        else
        {
            //gun
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / firerate;
            }
            fireCountdown -= Time.deltaTime;
        }
       
    
    }

    void LockOnTarget()
    {
        //target mons
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactlight.enabled = true;
        }
           
        lineRenderer.SetPosition(0, firepoint.position);
        lineRenderer.SetPosition(1,target.position);


        Vector3 dir = firepoint.position - target.position;
        //vector
        impactEffect.transform.position = target.position + dir.normalized * .5f;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate (bulletprefab,firepoint.position,firepoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}
