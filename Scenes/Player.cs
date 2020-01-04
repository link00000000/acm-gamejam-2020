using Godot;
using System;

public class Player : Area2D
{
    private Vector2 _velocity = new Vector2();
    [Export] public float MaxSpeed = 200f;

    [Export] public float Inertia = 10f;

    [Export] public float Friction = 10f;

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
        if (Input.IsActionPressed("ui_up"))
        {
            acceleration.y -= 1;
        }
        if (Input.IsActionPressed("ui_down"))
        {
            acceleration.y += 1;
        }
        acceleration = acceleration.Normalized() * Inertia;

        _velocity = new Vector2(
            x: Mathf.Clamp(_velocity.x + acceleration.x * delta, -MaxSpeed, MaxSpeed),
            y: Mathf.Clamp(_velocity.y + acceleration.y * delta, -MaxSpeed, MaxSpeed)
        );

        // TODO: Apply friction only when no keys are pressed
        var speed = _velocity.Length();
        if (_velocity.Length() != 0)
        {
            var newSpeed = speed - (speed * delta * Friction);
            newSpeed = Mathf.Clamp(newSpeed, 0f, MaxSpeed);

            var newSpeedRatio = newSpeed / speed;
            _velocity *= newSpeedRatio;
        }

        Position += _velocity;
    }
}
