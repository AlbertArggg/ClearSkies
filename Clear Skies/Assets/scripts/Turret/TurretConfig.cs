using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Serialization;

public class TurretConfig : MonoBehaviour
{
    [Header("Turret Rotation Configuration")] 
    [SerializeField] private float turretRotationSpeedHorizontal;
    [SerializeField] private float turretRotationSpeedVertical;
    [SerializeField] private float[] rotationalClampValuesHorizontal = new float[2];
    [SerializeField] private float[] rotationalClampValuesVertical= new float[2];
    
    private void Awake()
    {
        ValidateTurretRotationalValues();
    }

    #region Turret Value Getters
    public float TurretRotationSpeedHorizontal => turretRotationSpeedHorizontal;
    public float TurretRotationSpeedVertical => turretRotationSpeedVertical;
    public float[] RotationalClampValuesHorizontal => (float[])rotationalClampValuesHorizontal.Clone();
    public float[] RotationalClampValuesVertical => (float[])rotationalClampValuesVertical.Clone();
    #endregion
    
    #region Initialization && Configuration
    private void ValidateTurretRotationalValues()
    {
        // Set horizontal rotation speed to default if uninitialized
        SetValue(ref turretRotationSpeedHorizontal, TurretConstants.DEFAULT_HORIZONTAL_ROT_SPEED,
            "turretRotationSpeed_Horizontal");

        // Set vertical rotation speed to default if uninitialized
        SetValue(ref turretRotationSpeedVertical, TurretConstants.DEFAULT_VERTICAL_ROT_SPEED,
            "turretRotationSpeed_Vertical");

        // Set horizontal rotational clamp values to default if uninitialized
        SetValue(ref rotationalClampValuesHorizontal[0], TurretConstants.DEFAULT_HORIZONTAL_CLAMP_MIN,
            "RotationalClampValues_Horizontal[0]");
        SetValue(ref rotationalClampValuesHorizontal[1], TurretConstants.DEFAULT_HORIZONTAL_CLAMP_MAX,
            "RotationalClampValues_Horizontal[1]");

        // Set vertical rotational clamp values to default if uninitialized
        SetValue(ref rotationalClampValuesVertical[0], TurretConstants.DEFAULT_VERTICAL_CLAMP_MIN,
            "RotationalClampValues_Vertical[0]");
        SetValue(ref rotationalClampValuesVertical[1], TurretConstants.DEFAULT_VERTICAL_CLAMP_MAX,
            "RotationalClampValues_Vertical[1]");
    }
    private void SetValue(ref float value, float defaultValue, string label)
    {
        // if value is not initialized, use default values from Turret Constants
        if (value == 0)
        {
            value = defaultValue;
            Debug.LogWarning($"{label} not initialized, value set to default {value.ToString(CultureInfo.CurrentCulture)}");
        }
        else
        {
            Debug.Log($"{label} value: {value.ToString(CultureInfo.CurrentCulture)}");
        }
    }
    #endregion
}
