using CoreLib.Submodules.ModEntity.Atributes;
using MoreMinecarts;
using PugMod;
using System.Linq;
using Unity.Entities;
using UnityEngine;

[EntityModification]
public static class MoreMinecartsTweaks
{
    [EntityModification(ObjectID.RailwayForge)]
    private static void EditRailwayForge(Entity entity, GameObject authoring, EntityManager entityManager)
    {
        var canCraftBuffer = entityManager.GetBuffer<CanCraftObjectsBuffer>(entity);

        addBufferEntry(canCraftBuffer, API.Authoring.GetObjectID("MoreMinecarts:CartScarlet"), 1);
        addBufferEntry(canCraftBuffer, API.Authoring.GetObjectID("MoreMinecarts:CartSolar"), 1);
        //addBufferEntry(canCraftBuffer, API.Authoring.GetObjectID("MoreMinecarts:CartInvisible"));
        //addBufferEntry(canCraftBuffer, API.Authoring.GetObjectID("MoreMinecarts:CartLegendaryParchment"));
    }

    private static void addBufferEntry(DynamicBuffer<CanCraftObjectsBuffer> canCraftBuffer, ObjectID itemId, int outputAmount)
    {
        CanCraftObjectsBuffer entry = new CanCraftObjectsBuffer
        {
            objectID = itemId,
            amount = outputAmount,
            entityAmountToConsume = 0
        };
        if (canCraftBuffer.Contains(entry))
        {
            Debug.Log($"[{MoreMinecartsMod.NAME}]: Crafter already contained itemId {itemId} so not adding it again");
        }
        else
        {
            canCraftBuffer.Add(entry);
            Debug.Log($"[{MoreMinecartsMod.NAME}]: Adding itemId {itemId} to crafter");
        }
    }
}
