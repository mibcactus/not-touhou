using System;
using System.Numerics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using nottouhou.Content;

namespace nottouhou;

public class Player : entity{

    public void GetInput(float elapsedGameTime)
    {
        float distance = speed * elapsedGameTime;
        if (Keyboard.GetState().IsKeyDown(Keys.A))
        {
            position.X -= distance;
        } 
        if (Keyboard.GetState().IsKeyDown(Keys.D))
        {
            position.X += distance;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.W))
        {
            position.Y -= distance;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            position.Y += distance;
        }
        
        checkPosition();
        
        if ( Keyboard.GetState().IsKeyDown(Keys.Space))
        {
            Attack();
        }

    }

    public void Attack()
    {
        Console.WriteLine("Attack!");
    }

    public Player(int newscreenWidth, int newscreenHeight, Vector2 newPosition, float newSpeed) : base(newscreenWidth, newscreenHeight, newPosition, newSpeed)
    {
    }
}