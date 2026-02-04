using Microsoft.Xna.Framework.Graphics;
using PhysicsLibrary.Interfaces;
using Microsoft.Xna.Framework;


namespace PhysicsLibrary.Commands
{
    public class DrawLine : ICommand
    {
        private SpriteBatch _spriteBatch;
        private Vector2 _start;
        private Vector2 _end;
        private Color _color;

        public DrawLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color)
        {
            _spriteBatch = spriteBatch;
            _start = start;
            _end = end;
            _color = color;
        }

        public void Execute()
        {
            Vector2 direction = _end - _start;
            int steps = (int)direction.Length();
            Vector2 step = Vector2.Normalize(direction);

            for (int i = 0; i <= steps; i += 15)
            {
                Vector2 pos = _start + step * i;
                new DrawPixel(_spriteBatch, pos, _color).Execute();
                /*new DrawPixel(_spriteBatch, new Vector2(pos.X - 1, pos.Y), _color).Execute();
                new DrawPixel(_spriteBatch, new Vector2(pos.X - 1, pos.Y + 1), _color).Execute();
                new DrawPixel(_spriteBatch, new Vector2(pos.X, pos.Y + 1), _color).Execute();*/
            }
        }
    }
}