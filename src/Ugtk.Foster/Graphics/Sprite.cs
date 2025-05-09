using Foster.Framework;
using System;
using System.Numerics;

namespace Ugtk.Foster.Graphics;

/// <summary>
/// Represents a sprite with a texture and an origin point.
/// </summary>
public readonly struct Sprite
{
    /// <summary>
    /// Gets the subtexture of the sprite.
    /// </summary>
    public readonly Subtexture Texture;

    /// <summary>
    /// Gets the origin point of the sprite.
    /// </summary>
    public readonly Vector2 Origin;

    private Sprite(Subtexture texture, Vector2 origin)
    {
        Texture = texture;
        Origin = origin;
    }

    /// <summary>
    /// Creates a sprite from a subtexture with no origin offset.
    /// </summary>
    /// <param name="texture">The subtexture to use.</param>
    /// <returns>A new sprite instance.</returns>
    public static Sprite FromTexture(Subtexture texture)
    {
        return new Sprite(texture, Vector2.Zero);
    }

    /// <summary>
    /// Creates a sprite from a texture with no origin offset.
    /// </summary>
    /// <param name="texture">The texture to use.</param>
    /// <returns>A new sprite instance.</returns>
    public static Sprite FromTexture(Texture texture)
    {
        if (texture == null)
            throw new ArgumentNullException(nameof(texture), "Texture cannot be null.");

        return FromTexture(texture, new Rect(0, 0, texture.Width, texture.Height));
    }

    /// <summary>
    /// Creates a sprite from a texture and a specified rectangle with no origin offset.
    /// </summary>
    /// <param name="texture">The texture to use.</param>
    /// <param name="rect">The rectangle defining the subtexture.</param>
    /// <returns>A new sprite instance.</returns>
    public static Sprite FromTexture(Texture texture, Rect rect)
    {
        if (texture == null)
            throw new ArgumentNullException(nameof(texture), "Texture cannot be null.");

        return new Sprite(new Subtexture(texture, rect), Vector2.Zero);
    }

    /// <summary>
    /// Creates a sprite from a subtexture with the origin set to the center.
    /// </summary>
    /// <param name="texture">The subtexture to use.</param>
    /// <returns>A new sprite instance.</returns>
    public static Sprite FromTextureCentered(Subtexture texture)
    {
        return new Sprite(texture, new Vector2(texture.Width, texture.Height) * 0.5f);
    }

    /// <summary>
    /// Creates a sprite from a texture with the origin set to the center.
    /// </summary>
    /// <param name="texture">The texture to use.</param>
    /// <returns>A new sprite instance.</returns>
    public static Sprite FromTextureCentered(Texture texture)
    {
        if (texture == null)
            throw new ArgumentNullException(nameof(texture), "Texture cannot be null.");

        var rect = new Rect(0, 0, texture.Width, texture.Height);
        return FromTextureCentered(texture, rect);
    }

    /// <summary>
    /// Creates a sprite from a texture and a specified rectangle with the origin set to the center.
    /// </summary>
    /// <param name="texture">The texture to use.</param>
    /// <param name="rect">The rectangle defining the subtexture.</param>
    /// <returns>A new sprite instance.</returns>
    public static Sprite FromTextureCentered(Texture texture, Rect rect)
    {
        if (texture == null)
            throw new ArgumentNullException(nameof(texture), "Texture cannot be null.");

        return new Sprite(new Subtexture(texture, rect), new Vector2(rect.Width, rect.Height) * 0.5f);
    }
}
