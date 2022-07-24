using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ConvertedEntityObject : MonoBehaviour, IConvertGameObjectToEntity {

    public Entity entity { private set; get; }
    public EntityManager entityManager { private set; get; }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        this.entity = entity;
        this.entityManager = dstManager;
        Debug.Log(entity);
    }
}
