using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using uFrame.Actions.Attributes;
using uFrame.Kernel;
using UniRx;
using UnityEngine;

namespace uFrame.ECS
{
    public class EntityService : EcsSystem
    {

        public List<EntityPrefabPool> Pools = new List<EntityPrefabPool>();

        public static int LastUsedId
        {
            get { return _lastUsedId; }
            set { _lastUsedId = value; }
        }
        private static int _lastUsedId = 0;

        private static Dictionary<int, Entity> _entities = new Dictionary<int, Entity>();

        public static Dictionary<int, Entity> Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public static int NewId()
        {
            _lastUsedId--;
            return _lastUsedId;
        }

        public static Entity GetEntityView(int entityId)
        {
            if (Entities.ContainsKey(entityId))
                return Entities[entityId];
            return null;
        }

        public static void DestroyEntity(int entityId)
        {
            if (Entities.ContainsKey(entityId))
                Destroy(Entities[entityId]);
        }

        public static void RegisterEntityView(Entity entity)
        {
            if (!Entities.ContainsKey(entity.EntityId))
            {
                Entities.Add(entity.EntityId, entity);
            }
        }

        public static void UnRegisterEntityView(Entity entity)
        {
            Entities.Remove(entity.EntityId);
        }

        public override void Setup()
        {
            base.Setup();
            
            this.OnEvent<SpawnEntity>().Subscribe(_ => Spawn(_)).DisposeWith(this);
        }

        public override IEnumerator SetupAsync()
        {
            
            return base.SetupAsync();
        }

        private void Spawn(SpawnEntity spawnEntity)
        {
            EntityPrefab prefab = null;
            //if (!string.IsNullOrEmpty(spawnEntity.PrefabName))
            //{
            //    var prefabItem = EntityPrefabs.Components.FirstOrDefault(p => p.Name == spawnEntity.PrefabName);
            //    if (prefabItem != null)
            //    {
            //        prefab = prefabItem;
            //    }
            //} else
            if (!string.IsNullOrEmpty(spawnEntity.PoolName))
            {
                var pool = Pools.FirstOrDefault(p => p.Name == spawnEntity.PoolName);
                if (pool == null) throw new Exception(string.Format("Pool {0} not found.", spawnEntity.PoolName));
                prefab = pool.GetComponents<EntityPrefab>().FirstOrDefault(p => p.Name == spawnEntity.PrefabName);
                if (prefab == null)
                {
                    prefab = pool.GetComponents<EntityPrefab>().FirstOrDefault();
                }
            }

            if (prefab == null) return;
            var result = Instantiate(prefab.Prefab.gameObject, spawnEntity.Position,Quaternion.Euler(spawnEntity.Rotation)) as GameObject;
            if (result != null)
            {
                spawnEntity.Result = result.GetComponent<Entity>();
            }


        }

    }
}