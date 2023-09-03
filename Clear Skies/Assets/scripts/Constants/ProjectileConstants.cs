public enum ProjectileType
{
    Default, Incendiary, Explosive, ArmorPiercing, ElectroMagneticPulse
}

public class ProjectileConstants
{
    private const float DEAFULT_DAMAGE_POINTS_VAL = 20;
    private const float DEFAULT_PROJECTILE_VELOCITY_VAL = 1000f;
    private const float DEFAULT_PROJECTILE_MASS_VAL = 1.0f;
    private const int DEFAULT_PREDICTION_STEPS_PER_FRAME_VAL = 20;
    private const ProjectileType DEFAULT_PROJECTILE_TYPE_VAL = ProjectileType.Default;
    
    public static float DEAFULT_DAMAGE_POINTS => DEAFULT_DAMAGE_POINTS_VAL;
    public static float DEFAULT_PROJECTILE_VELOCITY => DEFAULT_PROJECTILE_VELOCITY_VAL;
    public static float DEFAULT_PROJECTILE_MASS => DEFAULT_PROJECTILE_MASS_VAL;
    public static int DEFAULT_PREDICTION_STEPS_PER_FRAME => DEFAULT_PREDICTION_STEPS_PER_FRAME_VAL;
    public static ProjectileType DEFAULT_PROJECTILE_TYPE => DEFAULT_PROJECTILE_TYPE_VAL;
    
}
