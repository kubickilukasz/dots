using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct SphereData : IComponentData{

    public float speed;
    public float3 direction;
    public float timer;
    public float timeToChangeDecision;

}
