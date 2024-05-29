using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class UnitSpawnerAuthoring : MonoBehaviour
{
    public GameObject UnitPrefab;
    public int Quanlity = 1000;
}

public class UnitSpawnerBaker : Baker<UnitSpawnerAuthoring>
{
    public override void Bake(UnitSpawnerAuthoring authoring)
    {
        Entity entity = GetEntity(new TransformUsageFlags());
        AddComponent(entity, new UnitSpawner
        {
            quanlity = authoring.Quanlity,
            prefab = GetEntity(authoring.UnitPrefab, new TransformUsageFlags())
        });
    }
}
