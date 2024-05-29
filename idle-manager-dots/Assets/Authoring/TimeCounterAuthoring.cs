using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class TimeCounterAuthoring : MonoBehaviour
{
    public float DelayTime = 1f;   
}

public class TimeCounterAuthoringBaker : Baker<TimeCounterAuthoring>
{
    public override void Bake(TimeCounterAuthoring authoring)
    {
        Entity entity = GetEntity(new TransformUsageFlags());

        AddComponent(entity, new TimeCounter
        {
            DelayTime = authoring.DelayTime,
            TimeCount = 0
        });
    }
}