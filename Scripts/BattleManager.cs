using Godot;
using System;

public partial class BattleManager : Node
{
    [Export] public Node2D[] Allies { get; set; } = new Node2D[5];
    [Export] public Node2D[] Enemies { get; set; } = new Node2D[5];
    [Export] public int allyTurn = 0;
    [Export] public int enemyTurn = 0;

    private Timer turnTimer;

    public override void _Ready()
    {
        turnTimer = GetNode<Timer>("%TurnTimer");
        turnTimer.Start();
    }

    public void OnTurnTimerTimeout()
    {
        Abilities ally = Allies[allyTurn].GetNode<Abilities>("%AbilityController");
        Abilities enemy = Enemies[enemyTurn].GetNode<Abilities>("%AbilityController");
        ally.BasicAttack(Allies[allyTurn], Enemies);
        enemy.BasicAttack(Enemies[enemyTurn], Allies);

        if (allyTurn >= Allies.Length - 1)
        {
            allyTurn = 0;
        }
        else
        {
            allyTurn++;
        }

        if (enemyTurn >= Enemies.Length - 1)
        {
            enemyTurn = 0;
        }
        else
        {
            enemyTurn++;
        }
    }
}
