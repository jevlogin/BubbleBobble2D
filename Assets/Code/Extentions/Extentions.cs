using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public static class Extentions
    {
        public static Vector3 Change(this Vector3 value, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x == null ? value.x : (float)x, y == null ? value.y : (float)y, z == null ? value.z : (float)z);
        }
    }
}