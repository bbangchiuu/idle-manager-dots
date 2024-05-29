using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class RandomAuthoring : MonoBehaviour
{
    
}

public class RandomAuthoringBaker : Baker<RandomAuthoring>
{
    public override void Bake(RandomAuthoring authoring)
    {
        Entity entity = GetEntity(new TransformUsageFlags());

        AddComponent(entity, new RandomComponent
        {
            random = new Unity.Mathematics.Random(1)
        });
    }
}