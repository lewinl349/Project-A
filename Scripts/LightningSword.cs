using Godot;
using System;

public partial class LightningSword : Abilities
{
    public override void BasicAttack(Node2D sourceObj, Node2D[] targetObj)
    {
        for (int i = 0; i < 1; i++)
        {
            if (targetObj[i] != null)
            {
                Stats target = targetObj[i].GetNode<Stats>("%StatController");
                Stats source = sourceObj.GetNode<Stats>("%StatController");

                target.TakeDmg(Damage * source.GetStat(StatModifier));
            }
        }
    }

}
