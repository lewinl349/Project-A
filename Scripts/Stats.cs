using Godot;
using System;

public partial class Stats : Node2D
{
    [Export] public float MaxHp { get; set; } = 10;
    [Export] public float Def { get; set; } = 10;
    [Export] public float Atk { get; set; } = 10;

    float currentHp;

    Label statText;
    Sprite2D sprite;
    AnimationController aniPlayer;

    public override void _Ready()
    {
        statText = GetNode<Label>("StatText");
        sprite = GetParent<Node2D>().GetNode<Sprite2D>("Sprite");
        aniPlayer = GetParent<Node2D>().GetNode<AnimationController>("%AnimationPlayer");
        currentHp = MaxHp;
        UpdateText();
    }

    public float GetStat(StatType type)
    {
        return type switch
        {
            StatType.HP => MaxHp,
            StatType.DEF => Def,
            StatType.ATK => Atk,
            _ => 0,
        };

    }

    public void UpdateText()
    {
        statText.Text = $"HP: {currentHp}";
    }

    public void TakeDmg(float dmg)
    {
        aniPlayer.PlayHurt();
        currentHp -= Mathf.Floor(dmg);
        UpdateText();
    }

    public void Heal(float healedHp)
    {
        aniPlayer.PlayHeal();
        currentHp = Mathf.Min(MaxHp, currentHp + Mathf.Floor(healedHp));
        UpdateText();
    }
}
