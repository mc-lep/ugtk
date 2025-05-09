using Foster.Framework;
using System.Numerics;

namespace Ugtk.Foster.Graphics;

/// <summary>
/// Provides extension methods for the <see cref="Batcher"/> class to simplify sprite rendering.
/// </summary>
public static class BatcherExtensions
{
    /// <summary>
    /// Draws a sprite with specified position, scale, rotation, and color.
    /// </summary>
    /// <param name="batcher">The batcher used for rendering.</param>
    /// <param name="sprite">The sprite to render.</param>
    /// <param name="position">The position to render the sprite at.</param>
    /// <param name="scale">The scale of the sprite.</param>
    /// <param name="rotation">The rotation of the sprite in radians.</param>
    /// <param name="color">The color to apply to the sprite.</param>
    public static void Sprite(this Batcher batcher, Sprite sprite, Vector2 position, Vector2 scale, float rotation, Color color)
    {
        batcher.Image(sprite.Texture, position, sprite.Origin, scale, rotation, color);
    }

    /// <summary>
    /// Draws a sprite with specified position and color, using default scale and rotation.
    /// </summary>
    /// <param name="batcher">The batcher used for rendering.</param>
    /// <param name="sprite">The sprite to render.</param>
    /// <param name="position">The position to render the sprite at.</param>
    /// <param name="color">The color to apply to the sprite.</param>
    public static void Sprite(this Batcher batcher, Sprite sprite, Vector2 position, Color color)
    {
        batcher.Image(sprite.Texture, position, sprite.Origin, Vector2.One, 0f, color);
    }

    /// <summary>
    /// Draws a sprite with specified position, color, and opacity.
    /// </summary>
    /// <param name="batcher">The batcher used for rendering.</param>
    /// <param name="sprite">The sprite to render.</param>
    /// <param name="position">The position to render the sprite at.</param>
    /// <param name="color">The color to apply to the sprite.</param>
    /// <param name="opacity">The opacity of the sprite (0.0 to 1.0).</param>
    public static void Sprite(this Batcher batcher, Sprite sprite, Vector2 position, Color color, float opacity)
    {
        color.A = (byte)(color.A * opacity);
        batcher.Image(sprite.Texture, position, sprite.Origin, Vector2.One, 0f, color);
    }
}
