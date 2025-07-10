using Godot;
using System;

public partial class BattleManager : Node
{
    [Export] public Node2D[] Allies { get; set; } = new Node2D[5];
    [Export] public Node2D[] Enemies { get; set; } = new Node2D[5];

    private Timer turnTimer;

    public override void _Ready()
    {
        turnTimer = GetNode<Timer>("%TurnTimer");
    }

    public void OnTurnTimerTimeout()
    {
        Abilities ally = Allies[0].GetNode<Abilities>("%AbilityController");
        ally.BasicAttack(Allies[0], Enemies);
    }
}
