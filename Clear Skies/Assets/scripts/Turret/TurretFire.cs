using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    public float fireRate = 10; // Shots per second
    public GameObject projectilePrefab;
    private float fireCooldown = 1;
    public GameObject Muzzle;
    
    private void Update()
    {
        // Update the fire cooldown
        fireCooldown -= Time.deltaTime;

        // Check if it's time to fire
        if (Input.GetMouseButton(0) && fireCooldown <= 0)
        {
            Fire();
            fireCooldown = 1 / fireRate; // Set the cooldown based on the fire rate
        }
    }

    private void Fire()
    {
        Debug.Log("Fired");
        // Instantiate and fire a projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Projectile projectileComponent = projectile.GetComponent<Projectile>();

        if (projectileComponent != null)
        {
            projectileComponent.Init(Muzzle.transform);
        }
    }
}