using System.Reflection.Metadata.Ecma335;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using PhysicsLibrary.Interfaces;

namespace PhysicsLibrary.Sprites
{
    public class Peg : ISprite, IPositionable, ICircular
    {
        private TextureRegion _texture;
        private TextureRegion _textureHit;
        private float _scale;
        public bool Hit { get; set; }
        public float Radius { get; set; }
        public Vector2 Position { get; set; }

        public Peg(TextureRegion texture, TextureRegion textureHit)
        {
            _texture = texture;
            _textureHit = textureHit;
            Hit = false;
            _scale = 2f;
            Radius = _texture.Height * _scale / 2f;
        }

        public void Update(GameTime gameTime)
        {
            if (_texture != _textureHit && Hit)
            {
                _texture = _textureHit;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _texture.Draw(
                spriteBatch,
                Position,
                Color.White, 
                0f, 
                new Vector2(_texture.Width / 2f, _texture.Height / 2f), 
                _scale, 
                SpriteEffects.None, 
                0f
            );
        }
    }
}