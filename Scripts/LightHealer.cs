using Godot;
using System;

public partial class LightHealer : Abilities
{
    // Target all allies and heal
    public override void BasicAttackEffect(Node2D sourceObj, Node2D[] allyObjs, Node2D[] enemyObjs)
    {
        for (int i = 0; i < allyObjs.Length; i++)
        {
            Stats target = allyObjs[i].GetNode<Stats>("%StatController");
            Stats source = sourceObj.GetNode<Stats>("%StatController");

            target.Heal(Damage * source.GetStat(StatModifier));
        }
    }
}
