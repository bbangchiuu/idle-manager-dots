using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public readonly partial struct MoveUnitAspect : IAspect
{
    public readonly RefRO<MoveSpeed> moveSpeed;
    public readonly RefRW<LocalToWorld> localPos;
    public readonly RefRW<TimeCounter> timeCount;
    public readonly RefRW<MoveDirection> direction;

    public void MoveUnit(float deltaTime)
    {
        float3 newPos = localPos.ValueRO.Position + direction.ValueRO.direction * moveSpeed.ValueRO.Value * deltaTime;
        localPos.ValueRW.Value = new float4x4(quaternion.identity, newPos);
    }

    public void UpdateTimer(RefRW<RandomComponent> randomComponent, float deltaTime)
    {
        if (timeCount.ValueRO.TimeCount <= 0)
        {
            GetNewDirection(randomComponent);
            timeCount.ValueRW.TimeCount = timeCount.ValueRO.DelayTime;
        }
        else
        {
            timeCount.ValueRW.TimeCount -= deltaTime;
        }
    }

    public void GetNewDirection(RefRW<RandomComponent> randomComponent)
    {
        direction.ValueRW.direction = new float3(randomComponent.ValueRW.random.NextFloat(-5f, 5f), 0, randomComponent.ValueRW.random.NextFloat(-5f, 5f));
    }
}