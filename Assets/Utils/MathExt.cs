using UnityEngine;

/// <summary>
///     2D math for unity
/// </summary>
public static class MathExt
{
    /// <summary>
    ///     The most useless const where it's longer than the number it represents. (180)
    /// </summary>
    public const float AngleLine = 180;

    public const float AngleCircle = 360;

    /// <summary>
    ///     Gets the transform-settable rotation from an angle in degrees.
    /// </summary>
    public static Quaternion GetRot(float degrees)
    {
        return Quaternion.Euler(new Vector3(0, 0, degrees));
    }

    /// <summary>
    ///     Working with Vector3s is such a pain in the ass
    /// </summary>
    public static Vector2 Pos2D(this Vector3 position)
    {
        return new Vector2(position.x, position.y);
    }

    /// <summary>
    ///     Preserves the original z position for things like cameras
    ///     Working with Vector3s is such a pain in the ass
    /// </summary>
    public static Vector3 ToPos3D(this Vector3 original, Vector2 newPos)
    {
        return new Vector3(newPos.x, newPos.y, original.z);
    }

    /// <summary>
    ///     Shorthand for subtraction. PS the order matters
    /// </summary>
    public static Vector2 Diff(Vector2 a, Vector2 b)
    {
        return new Vector2(b.x - a.x, b.y - a.y);
    }

    /// <summary>
    ///     Shorthand for subtraction. PS the order matters
    /// </summary>
    public static Vector2 Diff(Vector3 a, Vector3 b)
    {
        return new Vector2(b.x - a.x, b.y - a.y);
    }

    /// <summary>
    ///     Returns degrees between -180 and 180. You usually use this with a difference vector.
    /// </summary>
    public static float Angle(Vector2 diff)
    {
        return Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    }

    /// <summary>
    ///     Let's say you're trying to turn around to point at a target.
    ///     Positive means that you'll get there faster by increasing rotation.
    ///     Negative means you'll get there faster by decreasing rotation.
    ///     Null means the angles are practically the same.
    /// </summary>
    public static bool? GetFasterAngleDir(float selfAngle, float targetAngle)
    {
        if (targetAngle > selfAngle)
            return targetAngle - selfAngle < AngleLine;

        if (targetAngle < selfAngle)
            return selfAngle - targetAngle > AngleLine;

        return null;
    }

    /// <summary>
    ///     Let's say you're trying to turn around to point at a target.
    ///     Positive means that you'll get there faster by increasing rotation.
    ///     Negative means you'll get there faster by decreasing rotation.
    ///     Null means the angles are practically the same.
    /// </summary>
    public static bool? GetFasterAngleDir(float selfAngle, Vector2 selfPos, Vector2 targetPos)
    {
        return GetFasterAngleDir(selfAngle, Angle(Diff(selfPos, targetPos)));
    }

    /// <summary>
    ///     Let's say you're trying to turn around to point at a target with a bit of leeway.
    ///     Positive means that you'll get there faster by increasing rotation.
    ///     Negative means you'll get there faster by decreasing rotation.
    ///     Null means the angles are within the tolerance so you're fine.
    /// </summary>
    public static bool? GetFasterAngleDir(float selfAngle, float targetAngle, float tolerance)
    {
        if (targetAngle > selfAngle)
        {
            if (targetAngle + tolerance - selfAngle > AngleLine)
                return false;
            if (targetAngle + tolerance - selfAngle < AngleLine)
                return true;
        }
        else if (targetAngle < selfAngle)
        {
            if (selfAngle - targetAngle - tolerance > AngleLine)
                return true;
            if (selfAngle - targetAngle - tolerance < AngleLine)
                return false;
        }

        return null;
    }

    /// <summary>
    ///     Let's say you're trying to turn around to point at a target with a bit of leeway.
    ///     Positive means that you'll get there faster by increasing rotation.
    ///     Negative means you'll get there faster by decreasing rotation.
    ///     Null means the angles are within the tolerance so you're fine.
    /// </summary>
    public static bool? GetFasterAngleDir(float selfAngle, Vector2 selfPos, Vector2 targetPos, float tolerance)
    {
        return GetFasterAngleDir(selfAngle, Angle(Diff(selfPos, targetPos)), tolerance);
    }

    /// <summary>
    ///     Returns a unit vector you can multiply by speed and stuff.
    /// </summary>
    public static Vector2 AngleToVec(float angle)
    {
        angle *= Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    /// <summary>
    ///     Returns a coterminal angle within -180 to 180. I think. Let's test that.
    /// </summary>
    public static float NormalizeAngle(float angle)
    {
        angle = angle % AngleCircle;

        if (angle > 180)
            angle -= AngleCircle;
        else if (angle < -180)
            angle += AngleCircle;

        return angle;
    }

    /// <summary>
    ///     An angle adding function where it doesn't overshoot its target.
    /// </summary>
    public static float AddAngleTowards(float self, float target, float delta)
    {
        var initial = GetFasterAngleDir(self, target);
        var terminal = GetFasterAngleDir(self + delta, target);

        if (initial != terminal)
            return target;
        return self + delta;
    }

    /// <summary>
    ///     Checks if a Vector2 is approximately zero.
    /// </summary>
    public static bool ApproximatelyZero(this Vector2 vec)
    {
        return Mathf.Approximately(vec.x, 0) && Mathf.Approximately(vec.y, 0);
    }
}