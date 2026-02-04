using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Framework.Devices.Sensors;
using PhysicsLibrary.Interfaces;

namespace PhysicsLibrary.Sprites
{
    public class Ball : ISprite, IPositionable, ICircular
    {
        private Peg[] _peg; // for testing will be removed 

        private Texture2D _texture;
        private int _screenHeight;
        private int _screenWidth;
        private float _scale;
        private float _momentumLoss;
        public float Radius { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public Ball(Texture2D texture, Game1 game, Peg[] peg)
        {
            _texture = texture;
            _peg = peg;
            _screenHeight = game.Window.ClientBounds.Height;
            _screenWidth = game.Window.ClientBounds.Width;
            Acceleration = new Vector2(0, 750f);
            _scale = 0.1f;
            Radius = _texture.Height * _scale / 2f;
            _momentumLoss = 0.75f;
        }

        public void Update(GameTime gameTime)
        {
            foreach (Peg p in _peg)
                CheckCollision(p);

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Velocity * dt;
            Velocity += Acceleration * dt;

            if (Position.Y + Radius > _screenHeight) // here to show more of the physics
            {
                Position = new Vector2(Position.X, _screenHeight - Radius);

                if (Math.Abs(Velocity.Y) < 10f)
                    Velocity = Vector2.Zero;
                else
                    Velocity = new Vector2(Velocity.X, -Velocity.Y * _momentumLoss);
            }

            if (Position.X + Radius > _screenWidth)
            {
                Position = new Vector2(_screenWidth - Radius, Position.Y);
                Velocity = new Vector2(-Velocity.X * _momentumLoss, Velocity.Y);
            }
            else if (Position.X - Radius <= 0)
            {
                Position = new Vector2(Radius, Position.Y);
                Velocity = new Vector2(-Velocity.X * _momentumLoss, Velocity.Y);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _texture,
                Position,
                null,
                Color.White, 
                0f, 
                new Vector2(_texture.Width / 2f, _texture.Height / 2f), 
                _scale, 
                SpriteEffects.None, 
                0f
            );
        }

        public void CheckCollision(Peg other)
        {
            Vector2 delta = Position - other.Position;
            float distance = delta.Length();
            float minDistance = Radius + other.Radius;

            if (distance >= minDistance || distance == 0)
                return;
            
            Vector2 normal = delta / distance;
            float penetration = minDistance - distance;
            Position += normal * penetration;

            float normalVelocity = Vector2.Dot(Velocity, normal);

            if (normalVelocity > 0)
                return;

            Velocity -= (1 + _momentumLoss) * normalVelocity * normal;

            other.Hit = true;
        }
    }
}