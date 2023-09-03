using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class ProjectileConfig : MonoBehaviour
{
    [Header("Projectile Values")] 
    [SerializeField] private float damagePoints;
    [SerializeField] private float velocity;
    [SerializeField] private float mass;
    [SerializeField] private int predictionStepsPerFrame;
    [SerializeField] private ProjectileType projectileType;
    [SerializeField] private GameObject impactGameObject;

    
    private void Awake()
    {
        ValidateProjectileValues();
    }

    public float DamagePoints => damagePoints;
    public float Velocity => velocity;
    public float Mass => mass;
    
    public int PredictionStepsPerFrame;
    public ProjectileType ProjectileType => projectileType;

    public GameObject ImpactGameObject => impactGameObject;
    
    private void ValidateProjectileValues()
    {
        // Set damage to default if uninitialized
        SetValue(ref damagePoints, ProjectileConstants.DEAFULT_DAMAGE_POINTS, "damagePoints");

        // Set velocity to default if uninitialized
        SetValue(ref velocity, ProjectileConstants.DEFAULT_PROJECTILE_VELOCITY, "velocity");

        // Set mass value to default if uninitialized
        SetValue(ref mass, ProjectileConstants.DEFAULT_PROJECTILE_MASS, "mass");
        
        // Set prediction steps per frame to default if uninitialized
        SetValue(ref predictionStepsPerFrame, ProjectileConstants.DEFAULT_PREDICTION_STEPS_PER_FRAME, "predictionStepsPerFrame");

        // Set projectile type to default if uninitialized
        SetValue(ref projectileType, ProjectileConstants.DEFAULT_PROJECTILE_TYPE, "projectileType" );
        
        // Set impactGameObject to null if uninitialized
        SetValue(ref impactGameObject, null, "impactGameObject");
    }
    
    private void SetValue<T>(ref T value, T defaultValue, string label)
    {
        if (EqualityComparer<T>.Default.Equals(value, default(T)))
        {
            value = defaultValue;
            ErrorLogs.LogErrorInConsole($"{label} not initialized, value set to default {value}", LogTypes.Warning);
        }
        else
        {
            ErrorLogs.LogErrorInConsole($"{label} value: {value}", LogTypes.Log);
        }
    }
}
