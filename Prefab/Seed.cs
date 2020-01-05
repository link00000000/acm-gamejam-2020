using Godot;
using System;

namespace GameLogic
{
    public enum OriginatingTeam
    {
        TeamA,
        TeamB
    }

    public class Seed : RigidBody2D
    {
        [Export] public OriginatingTeam team;
        
        public void _on_Seed_body_entered(Node body)
        {
            // This is disgusting
            this.Visible = false;
            Hide();
            this.GetParent().GetNode(this.Name);
            this.QueueFree();
        }
        
    }
}
    
