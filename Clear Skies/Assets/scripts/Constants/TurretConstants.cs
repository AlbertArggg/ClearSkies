public class TurretConstants
{
    // Default horizontal and vertical speed values for turret rotation
    private const float DEFAULT_HORIZONTAL_ROT_SPEED_VALUE = 10f;
    private const float DEFAULT_VERTICAL_ROT_SPEED_VALUE = 10f;
    
    // Default horizontal and vertical clamp values for turret rotation
    private const float DEFAULT_HORIZONTAL_CLAMP_MIN_VALUE = float.MinValue;
    private const float DEFAULT_HORIZONTAL_CLAMP_MAX_VALUE = float.MaxValue;
    private const float DEFAULT_VERTICAL_CLAMP_MIN_VALUE = -80f;
    private const float DEFAULT_VERTICAL_CLAMP_MAX_VALUE = 5;
    
    
    // Default horizontal and vertical speed value getter functions for turret rotation
    public static float DEFAULT_HORIZONTAL_ROT_SPEED => DEFAULT_HORIZONTAL_ROT_SPEED_VALUE;
    public static float DEFAULT_VERTICAL_ROT_SPEED => DEFAULT_VERTICAL_ROT_SPEED_VALUE;
    
    // Default horizontal and vertical clamp value getter functions for turret rotation
    public static float DEFAULT_HORIZONTAL_CLAMP_MIN => DEFAULT_HORIZONTAL_CLAMP_MIN_VALUE;
    public static float DEFAULT_HORIZONTAL_CLAMP_MAX => DEFAULT_HORIZONTAL_CLAMP_MAX_VALUE;
    public static float DEFAULT_VERTICAL_CLAMP_MIN => DEFAULT_VERTICAL_CLAMP_MIN_VALUE;
    public static float DEFAULT_VERTICAL_CLAMP_MAX => DEFAULT_VERTICAL_CLAMP_MAX_VALUE;
}
