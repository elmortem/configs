using Unity.Collections;
using UnityEngine;

namespace Configs
{
	public abstract class ConfigBase : ScriptableObject
	{
		[ReadOnly]
		public int Id;

#if UNITY_EDITOR
		protected virtual void OnValidate()
		{
			var path = UnityEditor.AssetDatabase.GetAssetPath(this);
			var guid = UnityEditor.AssetDatabase.GUIDFromAssetPath(path);
			Id = Mathf.Abs(guid.GetHashCode());
		}
#endif
	}
}