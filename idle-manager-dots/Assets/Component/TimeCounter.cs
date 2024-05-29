using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct TimeCounter : IComponentData
{
    public float DelayTime;
    public float TimeCount;
}