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
	public partial class Player : DynamicEntity {
#if UNITY_5_3_OR_NEWER
[Preserve]
#endif
public Player() { }
		[Type(3, "string")]
		public string name = default(string);
	}
}
