using System;
using System.Numerics;

namespace Ugtk.Types;

/// <summary>
/// Provides extension methods for the <see cref="Vector2"/> struct.
/// </summary>
public static class Vector2Extensions
{
    private const float DegreesToRadians = MathF.PI / 180f;

    /// <summary>
    /// Determines whether the vector is diagonal (both X and Y components are non-zero).
    /// </summary>
    /// <param name="vector">The vector to check.</param>
    /// <returns><c>true</c> if the vector is diagonal; otherwise, <c>false</c>.</returns>
    public static bool IsDiagonal(this Vector2 vector)
    {
        return vector.X != 0 && vector.Y != 0;
    }

    /// <summary>
    /// Calculates the magnitude (length) of the vector.
    /// </summary>
    /// <param name="vector">The vector to calculate the magnitude for.</param>
    /// <returns>The magnitude of the vector.</returns>
    public static float Magnitude(this Vector2 vector)
    {
        return MathF.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
    }


    /// <summary>
    /// Checks if the vector is approximately zero, within a small tolerance.
    /// </summary>
    /// <param name="vector">The vector to check.</param>
    /// <param name="tolerance">The tolerance value. Default is 0.0001.</param>
    /// <returns><c>true</c> if the vector is approximately zero; otherwise, <c>false</c>.</returns>
    public static bool IsApproximatelyZero(this Vector2 vector, float tolerance = 0.0001f)
    {
        return MathF.Abs(vector.X) < tolerance && MathF.Abs(vector.Y) < tolerance;
    }

    /// <summary>
    /// Rotates the vector by a specified angle in radians.
    /// </summary>
    /// <param name="vector">The vector to rotate.</param>
    /// <param name="radians">The angle in radians to rotate the vector.</param>
    /// <returns>The rotated vector.</returns>
    public static Vector2 RotateByRadians(this Vector2 vector, float radians)
    {
        float cos = MathF.Cos(radians);
        float sin = MathF.Sin(radians);

        return new Vector2(
            vector.X * cos - vector.Y * sin,
            vector.X * sin + vector.Y * cos
        );
    }

    /// <summary>
    /// Rotates the vector by a specified angle in radians.
    /// </summary>
    /// <param name="vector">The vector to rotate.</param>
    /// <param name="degrees">The angle in radians to rotate the vector.</param>
    /// <returns>The rotated vector.</returns>
    public static Vector2 RotateByDegrees(this Vector2 vector, float degrees)
    {
        float cos = MathF.Cos(degrees * DegreesToRadians);
        float sin = MathF.Sin(degrees * DegreesToRadians);

        return new Vector2(
            vector.X * cos - vector.Y * sin,
            vector.X * sin + vector.Y * cos
        );
    }
}
