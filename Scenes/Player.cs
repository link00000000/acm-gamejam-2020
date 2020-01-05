using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 _velocity = new Vector2();
    [Export] public float MaxSpeed = 200f;

    [Export] public float Inertia = 10f;
    [Export] public float Friction = 10f;

    [Export] public float gravity = 9.8f;

    [Export] public float jump = 100f;

    public override void _Process(float delta)
    {
        var acceleration = new Vector2();
        var horizontal = new Vector2();

        acceleration.y = gravity;
        if (Input.IsActionPressed("ui_left"))
        {
            acceleration.x -= 1;
        }
        if (Input.IsActionPressed("ui_right"))
        {
            acceleration.x += 1;
        }
        if(Input.IsActionPressed("ui_select"))
        {
            horizontal.y -= jump;
        }
        else
            horizontal.y += gravity;
        acceleration = acceleration.Normalized() * Inertia;

        _velocity = new Vector2(
            x: Mathf.Clamp(_velocity.x + acceleration.x, -MaxSpeed, MaxSpeed),
            y: Mathf.Clamp(_velocity.y + horizontal.y, -MaxSpeed, MaxSpeed)
        );
        
        // if( !IsOnFloor() )
        // {
        //     if( Input.IsActionPressed("ui_select") ) //Jump
        //     {
        //         _velocity.y -= jump;
        //     }
        // }
        // else
        //     _velocity.y += gravity;
        // TODO: Apply friction only when no keys are pressed
        var speed = _velocity.Length();
        if (_velocity.Length() != 0)
        {
            var newSpeed = speed - (speed * delta * Friction);
            newSpeed = Mathf.Clamp(newSpeed, 0f, MaxSpeed);

            var newSpeedRatio = newSpeed / speed;
            _velocity *= newSpeedRatio;
        }
        
        _velocity = MoveAndSlide( _velocity );

    }
}
