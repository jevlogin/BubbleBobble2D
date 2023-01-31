using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public static class Extentions
    {
        public static Vector3 Change(this Vector3 value, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x == default ? value.x : (float)x, 
                y == default ? value.y : (float)y, 
                z == default ? value.z : (float)z);
        }

        public static Vector2 Change(this Vector2 value, float? x = null, float? y = null)
        {
            return new Vector2(x == default ? value.x : (float)x, 
                                y == default ? value.y : (float)y);
        }
    }
}