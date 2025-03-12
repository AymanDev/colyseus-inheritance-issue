// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 3.0.18
// 

using Colyseus.Schema;
#if UNITY_5_3_OR_NEWER
using UnityEngine.Scripting;
#endif

namespace Scripts.Schemas {
	public partial class EntitiesMap : Schema {
#if UNITY_5_3_OR_NEWER
[Preserve]
#endif
public EntitiesMap() { }
		[Type(0, "map", typeof(MapSchema<Entity>))]
		public MapSchema<Entity> entities = null;
	}
}
