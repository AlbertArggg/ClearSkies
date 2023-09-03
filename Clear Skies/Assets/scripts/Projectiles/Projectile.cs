using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private ProjectileConfig _projectileConfig;

    private float _damagePoints;
    private float _velocity;
    private float _mass;
    private int _predictionStepsPerFrame;
    private ProjectileType _projectileType;
    private GameObject _impactGameObject;

    private bool _init = false;
    private bool _hit = false;
    private Vector3 _projectileVelocity;
    
    public void Init(Transform muzzle)
    {
        // Set variable values
        _projectileConfig = GetComponent<ProjectileConfig>();
        _damagePoints = _projectileConfig.DamagePoints;
        _velocity = _projectileConfig.Velocity;
        _mass = _projectileConfig.Mass;
        _predictionStepsPerFrame = _projectileConfig.PredictionStepsPerFrame;
        _projectileType = _projectileConfig.ProjectileType;
        _impactGameObject = _projectileConfig.ImpactGameObject;
        
        // Transform operations
        var t = transform;
        var mt = muzzle.transform;
        t.position = mt.position;
        t.rotation = mt.rotation;
        
        // set projectile velocity values
        _projectileVelocity = mt.forward * _velocity;

        // fix race condition
        _init = true;

        // TEMP (Replace with Max Range)
        StartCoroutine(TempTimeToDestroy());
    }

    private void Update()
    {
        if (!_init || _hit)
            return;
        
        SimulateProjectileMovement();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void SimulateProjectileMovement()
    {
        Vector3 currentPosition = transform.position;
        float stepSize = 1.0f / _predictionStepsPerFrame;
    
        for (float step = 0; step < 1; step += stepSize)
        {
            if (!_hit)
            {
                UpdateProjectileVelocity(stepSize);

                Vector3 nextPosition = currentPosition + _projectileVelocity * (stepSize * Time.deltaTime);

                if (CheckCollision(currentPosition, nextPosition))
                {
                    HandleProjectileCollision(currentPosition);
                    return;
                }

                currentPosition = nextPosition;
                transform.position = nextPosition;
            }
        }
    }

    private void UpdateProjectileVelocity(float stepSize)
    {
        _projectileVelocity += Physics.gravity * stepSize * _mass * Time.deltaTime;
    }

    private bool CheckCollision(Vector3 fromPosition, Vector3 toPosition)
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(fromPosition, toPosition - fromPosition);
        return Physics.Raycast(ray, out hitInfo, (toPosition - fromPosition).magnitude);
    }

    private void HandleProjectileCollision(Vector3 impactPosition)
    {
        _hit = true;
        Debug.Log("Projectile hit something: " + transform.name);
    }

    IEnumerator TempTimeToDestroy()
    {
        yield return new WaitForSecondsRealtime(5);
        Destroy(gameObject);
    }
}
