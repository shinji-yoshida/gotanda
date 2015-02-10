using UnityEngine;
using System.Collections;
using gotanda;

namespace gotanda{
	public class Vector2Math {
		public static Vector2 FootOfPerpendicular(Line2 line, Vector2 p){
			var ap = p - line.BasePoint;
			var len = Vector2.Dot(ap, line.Direction);
			return line.PointFromBasePoint(len);
		}
	}
}