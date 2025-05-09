using Foster.Framework;
using Ugtk.Types;

namespace Ugtk.Foster.Types;

/// <summary>
/// Provides extension methods for the <see cref="Size"/> struct.
/// </summary>
public static class SizeExtensions
{
    /// <summary>
    /// Converts a <see cref="Size"/> object to a <see cref="Point2"/> object.
    /// </summary>
    /// <param name="size">The <see cref="Size"/> instance to convert.</param>
    /// <returns>
    /// A <see cref="Point2"/> object with the same width and height as the <see cref="Size"/> instance.
    /// </returns>
    public static Point2 ToPoint2(this Size size)
    {
        return new Point2(size.Width, size.Height);
    }
}