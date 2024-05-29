using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

[DisableAutoCreation]
public partial class MoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        foreach (var (moveSpeed, localPos) in SystemAPI.Query<RefRO<MoveSpeed>, RefRW<LocalToWorld>>())
        {
            float3 newPos = localPos.ValueRO.Position + new float3(0, 0, 1) * moveSpeed.ValueRO.Value * SystemAPI.Time.DeltaTime;
            localPos.ValueRW.Value = new float4x4(quaternion.identity, newPos);
        }
    }
}
