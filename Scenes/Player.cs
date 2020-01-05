using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export] public float MaxSpeed = 800f;

    [Export] public float Inertia = .005f;

    [Export] public float Friction = 8f;

    [Export] public float Weight = 100f;

    [Export] public float MaxFallSpeed = 1000f;

    [Export] public float Jump = 1500f;

    private Vector2 _velocity = new Vector2();

    public override void _Process(float delta)
    {
        var acceleration = new Vector2();

        if (Input.IsActionPressed("ui_left"))
        {
            acceleration.x -= 1;
        }
        if (Input.IsActionPressed("ui_right"))
        {
            acceleration.x += 1;
        }
        if (Input.IsActionPressed("ui_select") && IsOnFloor())
        {
            _velocity.y = -Jump;
        }
        else
        {
            acceleration.y = Weight;
        }
        acceleration.x *= (1 / Inertia);

        _velocity = new Vector2(
            x: Mathf.Clamp(_velocity.x + acceleration.x, -MaxSpeed, MaxSpeed),
            y: Mathf.Min(_velocity.y + acceleration.y, MaxFallSpeed)
        );

        // TODO: Apply friction only when no keys are pressed
        var speed = _velocity.x;
        if (speed != 0)
        {
            var newSpeed = speed - (speed * delta * Friction);
            newSpeed = Mathf.Clamp(newSpeed, -MaxSpeed, MaxSpeed);

            var newSpeedRatio = newSpeed / speed;
            _velocity.x *= newSpeedRatio;
        }

        _velocity = MoveAndSlide(_velocity, new Vector2(x: 0, y: -1));
    }
}
