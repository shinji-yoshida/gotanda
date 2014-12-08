using UnityEngine;
using System.Collections;

namespace gotanda{
	public static class Assertion {
		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void _assert_<T>(this T dammy, bool condition){
			if(condition)
				return;
			throw new UnityException("assertion failure");
		}

		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void _assert_(bool condition){
			if(condition)
				return;
			throw new UnityException("assertion failure");
		}
	}
}
