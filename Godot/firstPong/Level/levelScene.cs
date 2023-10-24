using Godot;
using System;

public partial class levelScene : Node
{
    [Export]
    public CharacterBody2D ball;

    public override void _Ready()
    {
        base._Ready();

        if(ball == null){
            ball = GetNode<CharacterBody2D>("Ball");
        } 
    }


    public void _on_goal_left_body_entered(Node2D body){
        
        ball.Position = new Vector2(640,360);
    }

    public void _on_goal_right_body_entered(Node2D body){
        ball.Position = new Vector2(640,360);
    }
}
