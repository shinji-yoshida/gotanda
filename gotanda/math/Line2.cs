using UnityEngine;
using System.Collections;



namespace gotanda{
	public class Line2{
		Vector2 basePoint;
		Vector2 direction;
		
		public Vector2 BasePoint {
			get {
				return basePoint;
			}
		}
		
		public Vector2 Direction {
			get {
				return direction;
			}
		}
		
		public Line2 (Vector2 basePoint, Vector2 direction)
		{
			Assertion._assert_(Mathf.Abs(direction.magnitude - 1) < 0.000001);
			
			this.basePoint = basePoint;
			this.direction = direction;
		}
		
		public Vector2 PointFromBasePoint(float length){
			return basePoint + direction * length;
		}
	}
}