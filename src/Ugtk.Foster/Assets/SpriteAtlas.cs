using Ugtk.Collections;
using Ugtk.Foster.Graphics;

namespace Ugtk.Foster.Assets;

/// <summary>
/// Represents a collection of sprites that can be accessed by name.
/// </summary>
public sealed class SpriteAtlas
{
    private readonly NamedBag<Sprite> _sprites = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="SpriteAtlas"/> class with the specified sprites.
    /// </summary>
    /// <param name="sprites">The collection of sprites to include in the atlas.</param>
    internal SpriteAtlas(NamedBag<Sprite> sprites)
    {
        _sprites = sprites;
    }

    /// <summary>
    /// Retrieves a sprite by its name.
    /// </summary>
    /// <param name="name">The name of the sprite to retrieve.</param>
    /// <returns>The sprite associated with the specified name.</returns>
    public Sprite GetSprite(string name)
    {
        return _sprites.GetValue(name);
    }
}
