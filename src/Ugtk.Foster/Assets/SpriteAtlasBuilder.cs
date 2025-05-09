using System;
using Ugtk.Collections;
using Ugtk.Foster.Graphics;

namespace Ugtk.Foster.Assets;

/// <summary>
/// A builder class for creating a <see cref="SpriteAtlas"/> by adding named sprites.
/// </summary>
public sealed class SpriteAtlasBuilder
{
    private readonly NamedBag<Sprite> _sprites = new();
    private bool _isBuilt;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpriteAtlasBuilder"/> class.
    /// </summary>
    public SpriteAtlasBuilder()
    {
        _sprites.BatchBeginAdd();
    }

    /// <summary>
    /// Adds a sprite to the atlas with the specified name.
    /// </summary>
    /// <param name="name">The name of the sprite.</param>
    /// <param name="sprite">The sprite to add.</param>
    /// <returns>The current instance of <see cref="SpriteAtlasBuilder"/> for method chaining.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the atlas has already been built.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is empty or whitespace.</exception>
    public SpriteAtlasBuilder AddSprite(string name, Sprite sprite)
    {
        ThrowIfBuilt();

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Sprite name cannot be null, empty, or whitespace.", nameof(name));
        }

        _sprites.BatchAdd(name, sprite);
        return this;
    }

    /// <summary>
    /// Builds the sprite atlas and prevents further modifications.
    /// </summary>
    /// <returns>A new instance of <see cref="SpriteAtlas"/> containing the added sprites.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the atlas has already been built.</exception>
    public SpriteAtlas Build()
    {
        ThrowIfBuilt();

        _isBuilt = true;
        _sprites.BatchEndAdd();
        return new SpriteAtlas(_sprites);
    }

    /// <summary>
    /// Throws an exception if the atlas has already been built.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the atlas has already been built.</exception>
    private void ThrowIfBuilt()
    {
        if (_isBuilt)
        {
            throw new InvalidOperationException("The sprite atlas has already been built and cannot be modified.");
        }
    }
}
