using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class MoveSpeedAuthoring : MonoBehaviour
{
    public float Speed;
}

public class MoveSpeedBaker : Baker<MoveSpeedAuthoring>
{
    public override void Bake(MoveSpeedAuthoring authoring)
    {
        Entity entity = GetEntity(new TransformUsageFlags());
        AddComponent(entity, new MoveSpeed
        {
            Value = authoring.Speed
        });

        AddComponent(entity, new MoveDirection
        {
            direction = new Vector3(0, 0, 1)
        });
    }
}