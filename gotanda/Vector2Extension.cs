using UnityEngine;
using System.Collections;

namespace gotanda{
	public static class Vector2Extension {
		public static Vector2 Rotate(this Vector2 v, float degrees) {
			return Quaternion.AngleAxis(degrees, Vector3.forward) * v;
		}
	}
}
