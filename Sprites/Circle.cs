using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PhysicsLibrary.Commands;
using PhysicsLibrary.Interfaces;

namespace PhysicsLibrary.Sprites
{
    public class Circle : ISprite, IPositionable
    {
        private float _radius;
        private int _segments;
        private Vector2[] _points;
        public Vector2 Position { get; set; }
        private Vector2 _velocity;

        private bool _hitLeft;
        private bool _hitRight;
        private bool _hitTop;
        private bool _hitBottom;
        private int _screenWidth;
        private int _screenHeight;

        public Circle(Vector2 position, float radius, int segments, int screenWidth, int screenHeight)
        {
            Position = position;
            _radius = radius;
            _segments = segments;
            _velocity = new Vector2(150f, 150f);
            _points = new Vector2[_segments];
            
            UpdatePoints();

            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }

        public void Update(GameTime gameTime)
        {
            _hitLeft = Position.X - _radius < 0;
            _hitRight = Position.X + _radius > _screenWidth;
            _hitTop = Position.Y - _radius < 0;
            _hitBottom = Position.Y + _radius > _screenHeight;
            
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += _velocity * dt;

            if (_hitLeft)
            {
                Position = new Vector2(_radius, Position.Y);
                _velocity = Vector2.Reflect(_velocity, Vector2.UnitX);
            }
            else if (_hitRight)
            {
                Position = new Vector2(_screenWidth - _radius, Position.Y);
                _velocity = Vector2.Reflect(_velocity, -Vector2.UnitX);
            }

            if (_hitTop)
            {
                Position = new Vector2(Position.X, _radius);
                _velocity = Vector2.Reflect(_velocity, Vector2.UnitY);
            }
            else if (_hitBottom)
            {
                Position = new Vector2(Position.X, _screenHeight - _radius);
                _velocity = Vector2.Reflect(_velocity, -Vector2.UnitY);
            }

            UpdatePoints();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _segments; i++)
            {
                Vector2 start = _points[i];
                Vector2 end = _points[(i + 1) % _segments];
                new DrawLine(spriteBatch, start, end, Color.White).Execute();
            }
        }

        public void UpdatePoints()
        {
            float increment = 2 * (float)Math.PI / _segments;

            for (int i = 0; i < _segments; i++)
            {
                float angle = i * increment;
                _points[i] = Position + _radius * new Vector2(
                    (float)Math.Cos(angle),
                    (float)Math.Sin(angle));
            }
        }
    }
}