﻿using Bang;
using Bang.Entities;
using Bang.Interactions;

namespace Murder.Interactions;

public readonly struct EnableChildrenInteraction : IInteraction
{

    public void Interact(World world, Entity interactor, Entity? interacted)
    {
        if (interacted == null)
            return;

        foreach (var c in interacted.Children)
        {
            if (world.TryGetEntity(c) is Entity child)
            {
                if (child.IsActive)
                {
                    continue;
                }

                if (child.HasSprite())
                {
                    child.SetAnimationStarted(Game.Now);
                }

                child.Activate();
            }
        }
    }
}