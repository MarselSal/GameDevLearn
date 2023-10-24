using Godot;
using System;

public partial class levelScene : Node
{
    [Export]
    public CharacterBody2D ball;
    public int playerScoreNumber = 0;
    public int opponentScoreNumber = 0;

    [Export]
    public Label playerScoreLabel;
    [Export]
    public Label opponentScoreLabel;

    public override void _Ready()
    {
        base._Ready();

        if(ball == null){
            ball = GetNode<CharacterBody2D>("Ball");
        }

        // mesma coisa do comando acima
        playerScoreLabel ??= GetNode<Label>("PlayerScore");

        opponentScoreLabel ??= GetNode<Label>("OpponentScore");



    }

    public override void _Process(double delta)
    {
        
    }


    // signal do Label que avisa pro level q a boal entrou
    public void _on_goal_left_body_entered(Node2D body){
        number_to_label(opponentScoreLabel, opponentScoreNumber);
        ball.Position = new Vector2(640,360);
    }

    public void _on_goal_right_body_entered(Node2D body){
        number_to_label(playerScoreLabel, playerScoreNumber);
        ball.Position = new Vector2(640,360);
    }

    public void number_to_label(Label label, int number){
        number++;
        label.Text = number.ToString();
    }
}
