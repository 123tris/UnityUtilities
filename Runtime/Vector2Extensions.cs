using System;
using UnityEngine;
using static UnityEngine.Vector2;

public static class Vector2Extensions
{
    public static Vector3 ToVector3(this Vector2 vec) => new Vector3(vec.x, vec.y);

    public static Vector2 SnapTo(this Vector2 vec, float snapAngle)
    {
        float snap = Mathf.Round(vec.Angle() / snapAngle) * snapAngle;
        snap *= Mathf.Deg2Rad;


        return new Vector2(Mathf.Sin(snap), Mathf.Cos(snap));
    }

    public static float Angle(this Vector2 vec)
    {
        if (Dot(right, vec) < 0)
        {
            return 360 - Vector2.Angle(up, vec);
        }
        return Vector2.Angle(up, vec);
    }

    public static bool Same(this Vector2 a, Vector2 b)
    {
        const float TOLERANCE = 0.001f;
        return Math.Abs(a.x - b.x) < TOLERANCE && Math.Abs(b.x - a.x) < TOLERANCE;
    }
}
