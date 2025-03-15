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
	public partial class Entity : Schema {
#if UNITY_5_3_OR_NEWER
[Preserve]
#endif
public Entity() { }
		[Type(0, "string")]
		public string uuid = default(string);

		[Type(1, "ref", typeof(Vector2D))]
		public Vector2D position = null;
	}
}
