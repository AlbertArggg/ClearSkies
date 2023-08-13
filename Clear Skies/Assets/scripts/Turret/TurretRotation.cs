using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    // turret configuration that stores variable values
    private TurretConfig _turretConfig;
    
    // turret rotational values
    private float _turretRotationSpeedHorizontal;
    private float _turretRotationSpeedVertical;
    private float[] _rotationalClampValuesHorizontal;
    private float[] _rotationalClampValuesVertical;
    
    // turret gameobjects 
    [SerializeField] private GameObject TurretRX;
    [SerializeField] private GameObject TurretRY;

    // Store the current rotation around X / Y axis
    private float _rotationX = 0.0f; 
    private float _rotationY = 0.0f; 
    
    private void Start()
    {
        _turretConfig = GetComponent<TurretConfig>();
        _turretRotationSpeedHorizontal = _turretConfig.TurretRotationSpeedHorizontal;
        _turretRotationSpeedVertical = _turretConfig.TurretRotationSpeedVertical;
        _rotationalClampValuesHorizontal = _turretConfig.RotationalClampValuesHorizontal;
        _rotationalClampValuesVertical = _turretConfig.RotationalClampValuesVertical;
    }
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate TurretRX based on the X movement of the mouse
        _rotationX += mouseX * _turretRotationSpeedHorizontal;
        _rotationX = Mathf.Clamp(_rotationX, _rotationalClampValuesHorizontal[0], _rotationalClampValuesHorizontal[1]);
        TurretRX.transform.localRotation = Quaternion.Euler(0, _rotationX, 0);

        // Rotate TurretRY based on the Y movement of the mouse
        _rotationY -= mouseY * _turretRotationSpeedVertical;
        _rotationY = Mathf.Clamp(_rotationY, _rotationalClampValuesVertical[0], _rotationalClampValuesVertical[1]);
        TurretRY.transform.localRotation = Quaternion.Euler(_rotationY, 0, 0);
    }
}
