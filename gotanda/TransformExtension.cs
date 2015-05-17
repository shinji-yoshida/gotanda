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
		
		public static void SetPositionX(this Transform transform, float x){
			var p = transform.position;
			p.x = x;
			transform.position = p;
		}
		
		public static void SetPositionY(this Transform transform, float y){
			var p = transform.position;
			p.y = y;
			transform.position = p;
		}
		
		public static void SetLocalPosition2D(this Transform transform, float x, float y){
			transform.localPosition = new Vector3(x, y, transform.localPosition.z);
		}
		
		public static void SetLocalPosition2D(this Transform transform, Vector2 p){
			transform.localPosition = new Vector3(p.x, p.y, transform.localPosition.z);
		}
		
		public static void SetLocalPositionX(this Transform transform, float x){
			var p = transform.localPosition;
			p.x = x;
			transform.localPosition = p;
		}

		public static void SetPosition2D(this Transform transform, Vector2 p){
			transform.position = new Vector3(p.x, p.y, transform.position.z);
		}
	}
}