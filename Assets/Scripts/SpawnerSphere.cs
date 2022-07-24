using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

public class SpawnerSphere : MonoBehaviour{

    [SerializeField] ConvertedEntityObject prefab1;
    [SerializeField] ConvertedEntityObject prefab2;

    [Space]

    [SerializeField] Vector3 startSpawnPos;
    [SerializeField] Vector3 spawnBounds;

    [SerializeField] int numberOfObjects = 100;

    BlobAssetStore blobAssetStore;
    EntityManager manager;

    void Start() {
        manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        blobAssetStore = new BlobAssetStore();

        StartCoroutine(SpawnAndWait()); 
    }

    IEnumerator SpawnAndWait() {
        
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blobAssetStore);

        GameObjectConversionUtility.ConvertGameObjectHierarchy(prefab1.gameObject, settings);
        GameObjectConversionUtility.ConvertGameObjectHierarchy(prefab2.gameObject, settings);

        int half = numberOfObjects / 2;

        for (int i = 0; i < half; i++) {
            Entity ent = manager.Instantiate(prefab1.entity);
            yield return null;
        }

        for (int i = half; i < numberOfObjects; i++) {
            manager.Instantiate(prefab2.entity);
            yield return null;
        }
    }

    void OnDestroy() {
        blobAssetStore.Dispose();
    }

}
