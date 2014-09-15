using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Practicum1
{
    public interface IGameLoopObject
    {
        void HandleInput();

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        
        void Reset();
    }
}
