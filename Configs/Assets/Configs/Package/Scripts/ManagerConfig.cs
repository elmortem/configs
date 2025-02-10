using System.IO;
using UnityEngine;

namespace Configs
{
	public abstract class ManagerConfig<T> : ConfigBase where T : ManagerConfig<T>
	{
		private static T _instance;
		
		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					var all = UnityEngine.Resources.LoadAll<T>("Configs");
					if (all.Length == 0)
					{
#if UNITY_EDITOR
						if(!Directory.Exists("Assets/Resources/Configs"))
							Directory.CreateDirectory("Assets/Resources/Configs");
						_instance = ScriptableObject.CreateInstance<T>();
						UnityEditor.AssetDatabase.CreateAsset(_instance, $"Assets/Resources/Configs/{typeof(T).Name}.asset");
#else
						Debug.LogError("No manager of type: " + typeof(T).Name);
						return null;
#endif
					}
					else
					{
						if (all.Length > 1)
						{
							Debug.LogError("Too many managers of type: " + typeof(T).Name);
						}

						_instance = all[0];
					}
				}

				return _instance;
			}
		}
	}
}