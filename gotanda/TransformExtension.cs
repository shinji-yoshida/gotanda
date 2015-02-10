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
		
		public static void SetPositionY(this Transform transform, float y){
			transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}
		
		public static void SetLocalPosition2D(this Transform transform, float x, float y){
			transform.localPosition = new Vector3(x, y, transform.localPosition.z);
		}
		
		public static void SetLocalPosition2D(this Transform transform, Vector2 p){
			transform.localPosition = new Vector3(p.x, p.y, transform.localPosition.z);
		}

		public static void SetPosition2D(this Transform transform, Vector2 p){
			transform.position = new Vector3(p.x, p.y, transform.position.z);
		}
	}
}