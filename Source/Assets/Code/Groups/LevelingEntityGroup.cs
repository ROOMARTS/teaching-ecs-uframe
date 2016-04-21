// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace ECSDemo {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using UniRx;
    using uFrame.Kernel;
    
    
    public partial class LevelingEntityGroup : ReactiveGroup<LevelingEntity> {
        
        private IEcsComponentManagerOf<LevelComponent> _LevelComponentManager;
        
        private int lastEntityId;
        
        private LevelComponent LevelComponent;
        
        public IEcsComponentManagerOf<LevelComponent> LevelComponentManager {
            get {
                return _LevelComponentManager;
            }
            set {
                _LevelComponentManager = value;
            }
        }
        
        public override System.Collections.Generic.IEnumerable<UniRx.IObservable<int>> Install(uFrame.ECS.IComponentSystem componentSystem) {
            LevelComponentManager = componentSystem.RegisterComponent<LevelComponent>();
            yield return LevelComponentManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return LevelComponentManager.RemovedObservable.Select(_=>_.EntityId);;
        }
        
        public override bool Match(int entityId) {
            lastEntityId = entityId;
            if ((LevelComponent = LevelComponentManager[entityId]) == null) {
                return false;
            }
            return true;
        }
        
        public override LevelingEntity Select() {
            var item = new LevelingEntity();;
            item.EntityId = lastEntityId;
            item.LevelComponent = LevelComponent;
            return item;
        }
    }
}
