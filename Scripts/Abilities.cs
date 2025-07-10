using Godot;
using System;

[GlobalClass]
public partial class Abilities : Node2D
{
    [Export] public float Damage { get; set; }  = 0;
    [Export] public float Cooldown { get; set; }  = 0;
    [Export] public ElementType Element { get; set; } = ElementType.PHYSICAL;
    [Export] public StatType StatModifier { get; set; } = StatType.ATK;

    public virtual void BasicAttack(Node2D sourceObj, Node2D[] targetObj)
    {
        Stats target = targetObj[0].GetNode<Stats>("%StatController");
        Stats source = sourceObj.GetNode<Stats>("%StatController");

        target.TakeDmg(Damage * source.GetStat(StatModifier));
    }
}