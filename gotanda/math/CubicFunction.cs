using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniLinq;


namespace gotanda {
	public class CubicFunction {
		public readonly float a, b, c, d;

		public CubicFunction (float a, float b, float c, float d) {
			this.a = a;
			this.b = b;
			this.c = c;
			this.d = d;
		}

		public float F(float x) {
			return (a * x * x * x) + (b * x * x) + (c * x) + d; 
		}

		public static CubicFunction Create(Vector2 v0, Vector2 v1, Vector2 v2, Vector2 v3) {
			Vector2[] v = new Vector2[]{v0, v1, v2, v3};
			List<float> m = 4.Times().SelectToList(i => CalcM(v, i));
			float a = m.Sum();
			float b = 4.Times().Map(i => m[i] * CalcFactorB(v.Take(i).Concat(v.Skip(i + 1)))).Sum();
			float c = 4.Times().Map(i => m[i] * CalcFactorC(v.Take(i).Concat(v.Skip(i + 1)))).Sum();
			float d = 4.Times().Map(i => m[i] * CalcFactorD(v.Take(i).Concat(v.Skip(i + 1)))).Sum();
			return new CubicFunction(a, b, c, d);
		}

		static float CalcM(Vector2[] v, int index) {
			var x = v[index].x;
			return v[index].y / v.Map(vn => (x - vn.x)).Where((xn, n) => n != index).Reduce(1, (memo, xn) => memo * xn);
		}

		static float CalcFactorB (IEnumerable<Vector2> v) {
			return - v.Select(vn => vn.x).Sum();
		}
		
		static float CalcFactorC (IEnumerable<Vector2> v) {
			var vList = v.ToList();
			var x0 = vList[0].x;
			var x1 = vList[1].x;
			var x2 = vList[2].x;
			return x0 * x1 + x1 * x2 + x2 * x0;
		}
		
		static float CalcFactorD (IEnumerable<Vector2> v) {
			return - v.Select(vn => vn.x).Reduce(1f, (memo, x) => memo * x);
		}

		public override string ToString ()
		{
			return string.Format ("[CubicFunction: a={0}, b={1}, c={2}, d={3}]", a, b, c, d);
		}
		
	}
}
