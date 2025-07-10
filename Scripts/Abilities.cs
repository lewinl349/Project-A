using Godot;
using System;

[GlobalClass]
public partial class Abilities : Node2D
{
    [Export] public float Damage { get; set; } = 0;
    [Export] public float Cooldown { get; set; } = 0;
    [Export] public ElementType Element { get; set; } = ElementType.PHYSICAL;
    [Export] public StatType StatModifier { get; set; } = StatType.ATK;

    AnimationController aniPlayer;

    public override void _Ready()
    {
        aniPlayer = GetParent<Node2D>().GetNode<AnimationController>("%AnimationPlayer");
    }

    public virtual void BasicAttack(Node2D sourceObj, Node2D[] allyObjs, Node2D[] enemyObjs)
    {
        aniPlayer.PlayBasicAttack();

        BasicAttackEffect(sourceObj, allyObjs, enemyObjs);
    }

    public virtual void BasicAttackEffect(Node2D sourceObj, Node2D[] allyObjs, Node2D[] enemyObjs)
    {
        if (enemyObjs.Length >= 1)
        {
            Stats target = enemyObjs[0].GetNode<Stats>("%StatController");
            Stats source = sourceObj.GetNode<Stats>("%StatController");

            target.TakeDmg(Damage * source.GetStat(StatModifier));
        }
    }
}