using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PhysicsLibrary.Interfaces;

namespace PhysicsLibrary.Commands
{
    public class DrawPixel : ICommand
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _pixel;
        private Vector2 _position;
        private Color _color;

        public DrawPixel(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            _spriteBatch = spriteBatch;
            _position = position;
            _color = color;

            _pixel = new Texture2D(_spriteBatch.GraphicsDevice, 1, 1);
            _pixel.SetData([Color.White]);
        }

        public void Execute()
        {
            _spriteBatch.Draw(
                _pixel,
                _position,
                _color
            );
        }
    }
}