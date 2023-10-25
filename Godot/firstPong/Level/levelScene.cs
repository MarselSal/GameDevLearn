using Godot;
using System;

public partial class levelScene : Node
{
    [Export]
    public CharacterBody2D ball;
    public int playerScoreNumber;
    public int opponentScoreNumber;

    [Export]
    public Label playerScoreLabel;
    [Export]
    public Label opponentScoreLabel;

    [Export]
    public Timer timer;

    public override void _Ready()
    {
        base._Ready();

        if(ball == null){
            ball = GetNode<CharacterBody2D>("Ball");
        }

        // mesma coisa do comando acima
        playerScoreLabel ??= GetNode<Label>("PlayerScore");

        opponentScoreLabel ??= GetNode<Label>("OpponentScore");

        timer ??= GetNode<Timer>("CountdownTimer");

    }

    public override void _Process(double delta)
    {
        
    }


    // signal do Label que avisa pro level q a boal entrou
    public void _on_goal_left_body_entered(Node2D body){
        opponentScoreNumber++;
        Label_and_reset(opponentScoreLabel, opponentScoreNumber, ball);
       
    }

    public void _on_goal_right_body_entered(Node2D body){
        playerScoreNumber++;
        Label_and_reset(playerScoreLabel, playerScoreNumber, ball);
        
    }

    public void Label_and_reset(Label label, int number, CharacterBody2D ball){
        label.Text = number.ToString();
        ball.Position = new Vector2(640,360);
        GetTree().CallGroup("BallGroup", "Stop_ball");
        timer.Start();
    }

    public void _on_countdown_timer_timeout(){
        GetTree().CallGroup("BallGroup", "Restart_ball");
    }

}
