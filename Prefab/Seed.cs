using Godot;
using System;

namespace GameLogic
{
    public enum OriginatingTeam
    {
        TeamA,
        TeamB
    }

    public class Seed : Node2D
    {
        [Export] public OriginatingTeam team;
    }
}
    
