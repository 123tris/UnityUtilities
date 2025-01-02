using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Vector3Extensions
{
    private static readonly char[] defaultSeparators = { ',' };

    public static Vector3 Direction(Vector3 @from, Vector3 to)
    {
        return (to - @from).normalized;
    }

    public static Vector3 Parse(string s, IFormatProvider provider, char[] separators = null)
    {
        string[] parts = s.Split(separators ?? defaultSeparators);

        if (parts.Length != 3)
        {
            throw new ArgumentException();
        }

        parts[0] = parts[0].Remove(0, 1);
        parts[2] = parts[2].Remove(parts[2].Length - 1, 1);

        return new Vector3(
            float.Parse(parts[0].Trim(), provider),
            float.Parse(parts[1].Trim(), provider),
            float.Parse(parts[2].Trim(), provider));
    }

    public static string ToString(this Vector3 vector, string format, IFormatProvider provider)
    {
        return $"({vector.x.ToString(format, provider)}, {vector.y.ToString(format, provider)}, {vector.z.ToString(format, provider)})";
    }

    public static string ToString(this Vector3 vector, IFormatProvider provider)
    {
        return $"({vector.x.ToString(provider)}, {vector.y.ToString(provider)}, {vector.z.ToString(provider)})";
    }

    public static Vector3 ClampMagnitude(this Vector3 vector, float minMagnitude, float maxMagnitude)
    {
        return vector.normalized * Mathf.Clamp(vector.magnitude, minMagnitude, maxMagnitude);
    }

    public static Vector3 FlattenX(this Vector3 vector) => new Vector3(0, vector.y, vector.z);

    public static Vector3 FlattenY(this Vector3 vector) => new Vector3(vector.x, 0, vector.z);

    public static Vector3 FlattenZ(this Vector3 vector) => new Vector3(vector.x, vector.y, 0);

    public static float[] ToArray(this Vector3 vector3) => new[] { vector3.x, vector3.y, vector3.z };

    public static float Min(this Vector3 vector3) => Mathf.Min(vector3.ToArray());

    public static float Max(this Vector3 vector3) => Mathf.Max(vector3.ToArray());

    public static Vector3 Abs(this Vector3 vector3) => new Vector3(Mathf.Abs(vector3.x), Mathf.Abs(vector3.y), Mathf.Abs(vector3.z));

    public static float ManhattanLength(this Vector3 vector3) => Mathf.Abs(vector3.x) + Mathf.Abs(vector3.y) + Mathf.Abs(vector3.z);

    public static Vector3Int ToVector3Int(this Vector3 vector) => new Vector3Int((int) vector.x, (int) vector.y, (int) vector.z);

    public static Vector3 ToVector3(this Vector3Int v) => new Vector3(v.x, v.y, v.z);

    public static Vector2 ToVector2(this Vector3 v) => new Vector2(v.x, v.y);

    public static IEnumerable<Vector3> MultiplyPoints(this Matrix4x4 matrix, IEnumerable<Vector3> points) => points.Select(x => (Vector3) (matrix * x));

    //public static Vector3 SnapTo(this Vector3 v3, float snapAngle)
    //{
    //    float angle = Vector3.Angle(v3, Vector3.up);
    //    if (angle < snapAngle / 2.0f)          // Cannot do cross product 
    //        return Vector3.up * v3.magnitude;  //   with angles 0 & 180
    //    if (angle > 180.0f - snapAngle / 2.0f)
    //        return Vector3.down * v3.magnitude;

    //    float t = Mathf.Round(angle / snapAngle);
    //    float deltaAngle = (t * snapAngle) - angle;

    //    Vector3 axis = Vector3.Cross(Vector3.up, v3);
    //    Quaternion q = Quaternion.AngleAxis(deltaAngle, axis);
    //    return q * v3;
    //}
}