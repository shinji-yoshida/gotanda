using UnityEngine;
using System.Collections;

namespace gotanda{
	public static class TransformExtension {
		public static void SetLocalScale2D(this Transform transform, float x, float y){
			transform.localScale = new Vector3(x, y, 1);
		}

		public static void SetLocalScale2D(this Transform transform, Vector2 scale){
			transform.localScale = new Vector3(scale.x, scale.y, 1);
		}
	}
}