
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public partial class RandomDirectionSystem : SystemBase {
    protected override void OnUpdate() {
        float deltaTime = Time.DeltaTime;
        var randomSystem = new Unity.Mathematics.Random(0x6E624EB7u);

        Entities.ForEach((ref SphereData sphereData) => {
            sphereData.timer += deltaTime;
            if (sphereData.timer > sphereData.timeToChangeDecision) {
                sphereData.timer = 0f;
                sphereData.direction.x = randomSystem.NextFloat(-1f, 1f);
                sphereData.direction.y = randomSystem.NextFloat(-1f, 1f);
                sphereData.direction.z = randomSystem.NextFloat(-1f, 1f);
                sphereData.direction = math.normalize(sphereData.direction);
            }
        }).Schedule();
    }
}
