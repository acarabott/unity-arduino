public class Map
{
    public static float LinLin(float value, float inMin, float inMax, float outMin, float outMax, bool clamp = true)
    {
        if (clamp)
        {
            if (value <= inMin) { return outMin; }
            if (value >= inMax) { return outMax; }
        }

        return outMin + (value - inMin) / (inMax - inMin) * (outMax - outMin);
    }
}