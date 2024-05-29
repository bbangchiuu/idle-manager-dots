using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

[BurstCompile]
public partial struct MoveISystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var randomComp = SystemAPI.GetSingletonRW<RandomComponent>();
        new MoveJob
        {
            randomComponent = randomComp,
            deltaTime = SystemAPI.Time.DeltaTime
        }.Schedule();
    }


    [BurstCompile]
    public partial struct MoveJob : IJobEntity
    {
        public float deltaTime;
        [NativeDisableUnsafePtrRestriction]
        public RefRW<RandomComponent> randomComponent;

        [BurstCompile]
        public void Execute(MoveUnitAspect aspect)
        {
            aspect.UpdateTimer(randomComponent, deltaTime);
            aspect.MoveUnit(deltaTime);
        }
    }
}