using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class UnitSpawnerSystem : SystemBase
{
    protected override void OnStartRunning()
    {
        var randomComp = SystemAPI.GetSingleton<RandomComponent>();
        foreach (var item in SystemAPI.Query<RefRO<UnitSpawner>>())
        {
            for (int i = 0; i < item.ValueRO.quanlity; i++)
            {
                Entity entity = EntityManager.Instantiate(item.ValueRO.prefab);
                float3 position = new float3(randomComp.random.NextFloat(-5f, 5f), 0, randomComp.random.NextFloat(-5f, 5f));
                EntityManager.SetComponentData(entity, LocalTransform.FromPosition(position));
            }
        }
    }
    protected override void OnUpdate()
    {
    }
}
