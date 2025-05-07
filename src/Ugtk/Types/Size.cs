using System;

namespace Ugtk.Types;

/// <summary>
/// Represents a size with a width and a height.
/// </summary>
public readonly struct Size : IEquatable<Size>
{
    /// <summary>
    /// Gets the width of the size.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Gets the height of the size.
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Size"/> struct.
    /// </summary>
    /// <param name="width">The width of the size.</param>
    /// <param name="height">The height of the size.</param>
    /// <exception cref="ArgumentOutOfRangeException">When width or height is not positive</exception>
    public Size(int width, int height)
    {
        if (width < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), "Width must be non-negative.");
        }

        if (height < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "Height must be non-negative.");
        }

        Width = width;
        Height = height;
    }

    /// <summary>
    /// Determines whether the current instance is equal to another <see cref="Size"/> instance.
    /// </summary>
    /// <param name="other">The other <see cref="Size"/> instance to compare.</param>
    /// <returns>
    /// <c>true</c> if the two instances have the same <see cref="Width"/> and <see cref="Height"/>; otherwise, <c>false</c>.
    /// </returns>
    public bool Equals(Size other) => (Width, Height) == (other.Width, other.Height);

    /// <summary>
    /// Determines whether the current instance is equal to a specified object.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="obj"/> is a <see cref="Size"/> and is equal to the current instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals(object? obj) => obj is Size size && Equals(size);

    /// <summary>
    /// Returns a hash code for the current instance.
    /// </summary>
    /// <returns>A hash code for the current instance.</returns>
    public override int GetHashCode() => HashCode.Combine(Width, Height);

    /// <summary>
    /// Determines whether two <see cref="Size"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="Size"/> instance.</param>
    /// <param name="right">The second <see cref="Size"/> instance.</param>
    /// <returns>
    /// <c>true</c> if the two instances are equal; otherwise, <c>false</c>.
    /// </returns>
    public static bool operator ==(Size left, Size right) => left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="Size"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="Size"/> instance.</param>
    /// <param name="right">The second <see cref="Size"/> instance.</param>
    /// <returns>
    /// <c>true</c> if the two instances are not equal; otherwise, <c>false</c>.
    /// </returns>
    public static bool operator !=(Size left, Size right) => !(left == right);
}