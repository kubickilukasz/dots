using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Extensions;
using UnityEngine;


[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public partial class MovementSystem : SystemBase {

    protected override void OnUpdate() {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref PhysicsVelocity physicsVel, in PhysicsMass physicsMass, in SphereData data, in Translation translation) => {
            float3 direction = -translation.Value / 100 + math.normalize(data.direction);
            direction = math.normalize(direction);
            physicsVel.ApplyLinearImpulse(physicsMass, direction * data.speed * deltaTime);
        }).Schedule(); 

    }
}
