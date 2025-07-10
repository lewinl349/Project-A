using Godot;
using System;

public partial class AnimationController : AnimationPlayer
{
    [Export] public string BasicAttack = "BasicAttack";

    Sprite2D sprite;

    public override void _Ready()
    {
        sprite = GetParent<Node2D>().GetNode<Sprite2D>("%Sprite");
    }

    public void PlayBasicAttack()
    {
        Play(BasicAttack);
    }

    public void PlayHurt()
    {
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(sprite, "modulate", Colors.Red, 0.5f);
        tween.TweenProperty(sprite, "modulate", Colors.White, 0.5f);
    }
}
