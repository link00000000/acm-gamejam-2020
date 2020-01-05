using Godot;
using System;
using GameLogic;


public class Tree : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Export] public bool IsPlanted;
    [Export] public Texture TeamA_Texture;
    [Export] public Texture TeamB_Texture;
    [Export] public OriginatingTeam Team;

    // Called when the node enters the scene tree for the first time.
    public void body_entered ( PhysicsBody2D body ){

        var parentType = body.GetParent();
        if(IsPlanted == false)
        {

        }
        else if( parentType is Seed)
        {
            if(OriginatingTeam.TeamA == OriginatingTeam.TeamA)
            {

            }
        }
        
    }

    public override void _Ready()
    {
       
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
