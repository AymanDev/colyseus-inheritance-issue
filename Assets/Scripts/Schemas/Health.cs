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
	public partial class Health : Schema {
#if UNITY_5_3_OR_NEWER
[Preserve]
#endif
public Health() { }
		[Type(0, "uint32")]
		public uint max = default(uint);

		[Type(1, "uint32")]
		public uint current = default(uint);
	}
}
