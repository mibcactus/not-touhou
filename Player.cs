using System;
using System.Diagnostics;
using System.Numerics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using nottouhou.Content;

namespace nottouhou;

public class Player : Entity{
    
    public bool[] currentDirections = new bool[4];

    public void GetInput(float elapsedGameTime)
    {
        float distance = speed * elapsedGameTime;

        for (int i = 0; i < 4; i++)
            currentDirections[i] = false;

        if (Keyboard.GetState().IsKeyDown(Keys.A)) {
            position.X -= distance;
            currentDirections[0] = true;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.D)) {
            position.X += distance;
            currentDirections[1] = true;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.W)) {
            position.Y -= distance;
            currentDirections[2] = true;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.S)) {
            position.Y += distance;
            currentDirections[3] = true;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Space))
            Attack();
                
        CheckPosition();
        
        

    }

    public void Attack()
    {
        Console.WriteLine("Attack!");
    }

    public Player(int newscreenWidth, int newscreenHeight, Vector2 newPosition, float newSpeed) : base(newscreenWidth, newscreenHeight, newPosition, newSpeed)
    {
    }
}