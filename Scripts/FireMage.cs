using Godot;
using System;

public partial class FireMage : Abilities
{
    // Target all targets
    public override void BasicAttackEffect(Node2D sourceObj, Node2D[] allyObjs, Node2D[] enemyObjs)
    {
        for (int i = 0; i < enemyObjs.Length; i++)
        {
            Stats target = enemyObjs[i].GetNode<Stats>("%StatController");
            Stats source = sourceObj.GetNode<Stats>("%StatController");

            target.TakeDmg(Damage * source.GetStat(StatModifier));
        }
    }
}
