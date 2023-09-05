using System;
using System.Collections;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    private TurretConfig _turretConfig;
    private float _originalFireRate;
    private float _currentFireRate;
    private float _fireCooldown;
    private float _fireRateCoolDownSpeed;
    private float _fireRateSlowDownSpeed;
    private float _maxValBeforeForcedCoolDown;
    private float _heatLowEnd;
    
    private float _gunHeat = 0f;
    private float _maxGunHeat = 100f;
    
    private int _fireRateCheck = 0;
    private bool _isFiring = false;
    private bool _isCooling = false;
    
    [Header("Game Objects")]
    public GameObject projectilePrefab;
    public GameObject muzzle;

    [Header("Dev Mode")]
    public bool Debugging = false;
    public float CheckTimer = 1;
    
    private void Start()
    {
        InitializeTurretConfig();
    }
    
    private void InitializeTurretConfig()
    {
        _turretConfig = GetComponent<TurretConfig>();
        _originalFireRate = _turretConfig.FireRate;
        _currentFireRate = _originalFireRate;
        _fireRateSlowDownSpeed = _turretConfig.FireRateSlowDown;
        _fireRateCoolDownSpeed = _turretConfig.FireRateCoolDownSpeed;
        _maxValBeforeForcedCoolDown = _turretConfig.MaxValBeforeForcedCooldown;
        _heatLowEnd = _turretConfig.HeatLowEnd;
        StartCoroutine(FireRateCheck());
    }

    private void Update()
    {
        UpdateCooldownAndFireRate();
        UpdateFiringState();
        if (_isFiring) { HandleFiring(); } else { HandleCooling(); }
        _gunHeat = Mathf.Clamp(_gunHeat, 0f, _maxGunHeat);
    }

    private void UpdateCooldownAndFireRate()
    {
        _fireCooldown -= Time.deltaTime;
        CalculateCurrentFireRate();
    }

    private void UpdateFiringState()
    {
        _isFiring = Input.GetMouseButton(0) && !_isCooling;
    }

    private void HandleFiring()
    {
        if (_gunHeat > _maxValBeforeForcedCoolDown)
        {
            _isCooling = true;
        }

        if (_fireCooldown <= 0)
        {
            FireProjectile();
            _fireCooldown = 1 / _currentFireRate;
            _gunHeat += _fireRateCoolDownSpeed * Time.deltaTime;
        }
    }

    private void HandleCooling()
    {
        _gunHeat -= _fireRateSlowDownSpeed * Time.deltaTime;
        if (_gunHeat < _heatLowEnd)
        {
            _isCooling = false;
        }
    }

    private void CalculateCurrentFireRate()
    {
        float heatPercentage = _gunHeat / _maxGunHeat;
        _currentFireRate = Mathf.Lerp(_originalFireRate, 0f, heatPercentage);
    }

    private void FireProjectile()
    {
        _fireRateCheck++;
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Projectile projectileComponent = projectile.GetComponent<Projectile>();

        if (projectileComponent != null)
        {
            projectileComponent.Init(muzzle.transform);
        }
    }

    IEnumerator FireRateCheck()
    {
        while (Debugging)
        {
            yield return new WaitForSecondsRealtime(CheckTimer);
            Debug.Log($"Base Fire Rate: {_originalFireRate} | Current Fire Rate: {_currentFireRate} | Heat Level: {_gunHeat}" );
        }
    }
}