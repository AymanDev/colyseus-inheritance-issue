// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 3.0.21
// 

using Colyseus.Schema;
#if UNITY_5_3_OR_NEWER
using UnityEngine.Scripting;
#endif

namespace Scripts.Schemas {
	public partial class WorldState : Schema {
#if UNITY_5_3_OR_NEWER
[Preserve]
#endif
public WorldState() { }
		[Type(0, "ref", typeof(StaticEntitiesMap))]
		public StaticEntitiesMap staticEntities = null;

		[Type(1, "ref", typeof(DynamicEntitiesMap))]
		public DynamicEntitiesMap dynamicEntities = null;

		[Type(2, "ref", typeof(PlayerMap))]
		public PlayerMap players = null;
	}
}
