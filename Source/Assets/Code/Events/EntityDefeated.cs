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
    using ECSDemo;
    using uFrame.ECS;
    using UniRx;
    
    
    public partial class EntityDefeated : object {
        
        [UnityEngine.SerializeField()]
        private Int32 _Attacker;
        
        [UnityEngine.SerializeField()]
        private Int32 _Defender;
        
        public Int32 Attacker {
            get {
                return _Attacker;
            }
            set {
                _Attacker = value;
            }
        }
        
        public Int32 Defender {
            get {
                return _Defender;
            }
            set {
                _Defender = value;
            }
        }
    }
}
