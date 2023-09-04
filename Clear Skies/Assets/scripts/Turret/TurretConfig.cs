using System.Globalization;
using UnityEngine;

public class TurretConfig : MonoBehaviour
{
    [Header("Turret Rotation Configuration")] 
    [SerializeField] private float turretRotationSpeedHorizontal;
    [SerializeField] private float turretRotationSpeedVertical;
    [SerializeField] private float[] rotationalClampValuesHorizontal = new float[2];
    [SerializeField] private float[] rotationalClampValuesVertical= new float[2];

    [Header("Turret Firing Configuration")] 
    [SerializeField] private float fireRate;
    [SerializeField] private float fireRateSlowDown;
    [SerializeField] private float fireRateCoolDownSpeed;
    [SerializeField] private float maxValBeforeForcedCooldown;
    [SerializeField] private float heatLowEnd;
    
    private void Awake()
    {
        ValidateTurretRotationalValues();
    }
    
    public float TurretRotationSpeedHorizontal => turretRotationSpeedHorizontal;
    public float TurretRotationSpeedVertical => turretRotationSpeedVertical;
    public float[] RotationalClampValuesHorizontal => (float[])rotationalClampValuesHorizontal.Clone();
    public float[] RotationalClampValuesVertical => (float[])rotationalClampValuesVertical.Clone();
    public float FireRate => fireRate;
    public float FireRateSlowDown => fireRateSlowDown;
    public float FireRateCoolDownSpeed => fireRateCoolDownSpeed;
    public float MaxValBeforeForcedCooldown => maxValBeforeForcedCooldown;

    public float HeatLowEnd => heatLowEnd;
    
    private void ValidateTurretRotationalValues()
    {
        // Set rotation speed to default if uninitialized
        SetValue(ref turretRotationSpeedHorizontal, TurretConstants.DEFAULT_HORIZONTAL_ROT_SPEED, "turretRotationSpeed_Horizontal");
        SetValue(ref turretRotationSpeedVertical, TurretConstants.DEFAULT_VERTICAL_ROT_SPEED, "turretRotationSpeed_Vertical");

        // Set rotational clamp values to default if uninitialized
        SetValue(ref rotationalClampValuesHorizontal[0], TurretConstants.DEFAULT_HORIZONTAL_CLAMP_MIN, "RotationalClampValues_Horizontal[0]");
        SetValue(ref rotationalClampValuesHorizontal[1], TurretConstants.DEFAULT_HORIZONTAL_CLAMP_MAX, "RotationalClampValues_Horizontal[1]");
        SetValue(ref rotationalClampValuesVertical[0], TurretConstants.DEFAULT_VERTICAL_CLAMP_MIN, "RotationalClampValues_Vertical[0]");
        SetValue(ref rotationalClampValuesVertical[1], TurretConstants.DEFAULT_VERTICAL_CLAMP_MAX, "RotationalClampValues_Vertical[1]");
        
        // Set Fire variables to default if uninitialized
        SetValue(ref fireRate, TurretConstants.DEFAULT_FIRERATE, "fireRate");
        SetValue(ref fireRateSlowDown, TurretConstants.DefaultFirerateSlowdown, "fireRateSlowDown");
        SetValue(ref fireRateCoolDownSpeed, TurretConstants.DEFAULT_FIRERATE_COOLDOWN, "fireRateCoolDownSpeed");
        SetValue(ref maxValBeforeForcedCooldown, TurretConstants.DEFAULT_MAX_HEAT_BEFORE_FORCED_COOLDOWN, "maxValBeforeForcedCooldown");
        SetValue(ref heatLowEnd, TurretConstants.DEFAULT_HEAT_LOW_END, "heatLowEnd");
    }
    
    private void SetValue(ref float value, float defaultValue, string label)
    {
        if (value == 0)
        {
            value = defaultValue;
            //ErrorLogs.LogErrorInConsole($"{label} not initialized, value set to default {value.ToString(CultureInfo.CurrentCulture)}", LogTypes.Warning);
        }
        else
        {
            //ErrorLogs.LogErrorInConsole($"{label} value: {value.ToString(CultureInfo.CurrentCulture)}",LogTypes.Log);
        }
    }
}

