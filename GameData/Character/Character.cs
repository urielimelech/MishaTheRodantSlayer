// using System;
// using System.Collections.Generic;
// using GameData.ControlSystem;
// using GameData.Utils;
// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Graphics;
// using Microsoft.Xna.Framework.Input;

// namespace GameData.Character;
// public class Character : IObserver<bool>
// {
//     Vector2 characterPosition;
//     private Animation movementAnimation;
//     private Texture2D standingTexture;
//     private bool isMoving;
//     private readonly ControlSystem2D controlSystem2D;
//     private readonly float scale = 0.5f;

//     public Character()
//     {
//         characterPosition = Vector2.Zero;
//         controlSystem2D = new ControlSystem2D(characterPosition);
//         controlSystem2D.AddMovementObserver(this);
//         movementAnimation = null;
//     }

//     public void SetCharacterPosition(Vector2 characterPosition)
//     {
//         this.characterPosition = characterPosition;
//     }
//     public void SetCharacterTexture(Texture2D standingTexture)
//     {
//         this.standingTexture = standingTexture;
//     }

//     public void Update(KeyboardState kState, GameTime gameTime)
//     {
//         characterPosition = controlSystem2D.KeyboardContorlSystem(kState, gameTime);
//         if (isMoving)
//         {
//             movementAnimation.Update(gameTime);
//         }
//     }

//     public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
//     {
//         Vector2 screenCenter = new(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2);
//         Vector2 characterOrigin = new(standingTexture.Width / 2, standingTexture.Height / 2);
//         Vector2 characterPosition = screenCenter - characterOrigin;
//         if (isMoving)
//         {
//             movementAnimation.Draw(spriteBatch, characterPosition);
//         }
//         else
//         {
//             // spriteBatch.Draw(standingTexture, characterPosition, Color.White);
//             spriteBatch.Draw(standingTexture, characterPosition, null, Color.White, 0f, characterOrigin, scale, SpriteEffects.None, 0f);
//         }
//     }
//     public Vector2 GetCharacterPosition()
//     {
//         return characterPosition;
//     }

//     public void OnCompleted()
//     {
//         throw new NotImplementedException();
//     }

//     public void OnError(Exception error)
//     {
//         Console.WriteLine(error.Message);
//         throw new NotImplementedException();
//     }

//     public void OnNext(bool value)
//     {
//         isMoving = value;
//     }

//     public void SetAnimationTextures(List<Texture2D> movementFrames)
//     {
//         movementAnimation = new Animation(movementFrames, 0.2);
//     }
// }