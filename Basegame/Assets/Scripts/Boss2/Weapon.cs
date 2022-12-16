using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPrefab;
    
    public float fireRate;
    private float timeRate;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && Time.time > timeRate)
        {
            timeRate = Time.time + fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
    }
}
