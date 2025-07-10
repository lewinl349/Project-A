using Godot;
using System;

public partial class FireMage : Abilities
{
    // Target all targets
    public override void BasicAttackEffect(Node2D sourceObj, Node2D[] targetObjs)
    {
        for (int i = 0; i < targetObjs.Length; i++)
        {
            if (targetObjs[i] != null)
            {
                Stats target = targetObjs[i].GetNode<Stats>("%StatController");
                Stats source = sourceObj.GetNode<Stats>("%StatController");

                target.TakeDmg(Damage * source.GetStat(StatModifier));
            }
        }
    }
}
