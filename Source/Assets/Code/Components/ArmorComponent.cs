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
    using UnityEngine;
    using uFrame.ECS;
    using UniRx;
    
    
    [uFrame.Attributes.uFrameIdentifier("c1d5fe32-ee88-4981-bace-911a4a4bca4c")]
    public partial class ArmorComponent : uFrame.ECS.EcsComponent {
        
        [UnityEngine.SerializeField()]
        private Int32 _Armor;
        
        private Subject<PropertyChangedEvent<Int32>> _ArmorObservable;
        
        private PropertyChangedEvent<Int32> _ArmorEvent;
        
        public int ComponentID {
            get {
                return 28;
            }
        }
        
        public IObservable<PropertyChangedEvent<Int32>> ArmorObservable {
            get {
                return _ArmorObservable ?? (_ArmorObservable = new Subject<PropertyChangedEvent<Int32>>());
            }
        }
        
        public Int32 Armor {
            get {
                return _Armor;
            }
            set {
                SetArmor(value);
            }
        }
        
        public virtual void SetArmor(Int32 value) {
            SetProperty(ref _Armor, value, ref _ArmorEvent, _ArmorObservable);
        }
    }
}
