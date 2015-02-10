using UnityEngine;
using System.Collections;

namespace gotanda{
	public static class Vector2Extension {
		public static Vector2 Rotate(this Vector2 v, float degrees) {
			return Quaternion.AngleAxis(degrees, Vector3.forward) * v;
		}
		
		public static float Cross(this Vector2 self, Vector2 v) {
			return self.x * v.y - v.x * self.y;
		}

		public static float SignedAngle(this Vector2 self, Vector2 v) {
			var angle = Vector2.Angle(self, v);
			if(self.Cross(v) < 0)
				return - angle;
			else
				return angle;
		}
	}
}
