public class TurretConstants
{
    // Default Turret Rotation values
    private const float DEFAULT_HORIZONTAL_ROT_SPEED_VALUE = 10f;
    private const float DEFAULT_VERTICAL_ROT_SPEED_VALUE = 10f;
    private const float DEFAULT_HORIZONTAL_CLAMP_MIN_VALUE = float.MinValue;
    private const float DEFAULT_HORIZONTAL_CLAMP_MAX_VALUE = float.MaxValue;
    private const float DEFAULT_VERTICAL_CLAMP_MIN_VALUE = -80f;
    private const float DEFAULT_VERTICAL_CLAMP_MAX_VALUE = 5;
    
    // Default Firing mechanism values
    private const float DEFAULT_FIRERATE_VALUE = 10f;
    private const float DEFAULT_FIRERATE_SLOWDOWN_VALUE = 20f;
    private const float DEFAULT_FIRERATE_COOLDOWN_VALUE = 30f;
    private const float DEFAULT_MAX_HEAT_BEFORE_FORCED_COOLDOWN_VALUE = 70;
    private const float DEFAULT_HEAT_LOW_END_VALUE = 20;
    

    public static float DEFAULT_HORIZONTAL_ROT_SPEED => DEFAULT_HORIZONTAL_ROT_SPEED_VALUE;
    public static float DEFAULT_VERTICAL_ROT_SPEED => DEFAULT_VERTICAL_ROT_SPEED_VALUE;
    public static float DEFAULT_HORIZONTAL_CLAMP_MIN => DEFAULT_HORIZONTAL_CLAMP_MIN_VALUE;
    public static float DEFAULT_HORIZONTAL_CLAMP_MAX => DEFAULT_HORIZONTAL_CLAMP_MAX_VALUE;
    public static float DEFAULT_VERTICAL_CLAMP_MIN => DEFAULT_VERTICAL_CLAMP_MIN_VALUE;
    public static float DEFAULT_VERTICAL_CLAMP_MAX => DEFAULT_VERTICAL_CLAMP_MAX_VALUE;
    
    public static float DEFAULT_FIRERATE => DEFAULT_FIRERATE_VALUE;
    public static float DefaultFirerateSlowdown => DEFAULT_FIRERATE_SLOWDOWN_VALUE;
    public static float DEFAULT_FIRERATE_COOLDOWN => DEFAULT_FIRERATE_COOLDOWN_VALUE;
    public static float DEFAULT_MAX_HEAT_BEFORE_FORCED_COOLDOWN => DEFAULT_MAX_HEAT_BEFORE_FORCED_COOLDOWN_VALUE;
    public static float DEFAULT_HEAT_LOW_END => DEFAULT_HEAT_LOW_END_VALUE;
}
