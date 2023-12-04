using CoreLib.Submodules.ModEntity.Atributes;
using MoreMinecarts;
using PugMod;
using Unity.Entities;
using UnityEngine;

[EntityModification]
public static class MoreMinecartsTweaks
{
    [EntityModification(ObjectID.RailwayForge)]
    private static void EditRailwayForge(Entity entity, GameObject authoring, EntityManager entityManager)
    {
        var canCraftBuffer = entityManager.GetBuffer<CanCraftObjectsBuffer>(entity);

        addBufferEntry(canCraftBuffer, API.Authoring.GetObjectID("MoreMinecarts:CartScarlet"));
        addBufferEntry(canCraftBuffer, API.Authoring.GetObjectID("MoreMinecarts:CartSolar"));
        //addBufferEntry(canCraftBuffer, API.Authoring.GetObjectID("MoreMinecarts:CartInvisible"));
        //addBufferEntry(canCraftBuffer, API.Authoring.GetObjectID("MoreMinecarts:CartLegendaryParchment"));
    }

    private static void addBufferEntry(DynamicBuffer<CanCraftObjectsBuffer> canCraftBuffer, ObjectID itemId)
    {
        Debug.Log($"[{MoreMinecartsMod.NAME}]: Adding itemId {itemId} to crafter");
        canCraftBuffer.Add(new CanCraftObjectsBuffer
        {
            objectID = itemId,
            amount = 1,
            entityAmountToConsume = 0
        });
    }
}
