using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsLibrary.Interfaces
{
    public interface ISprite
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        Vector2 Position { get; set; }
    }
}