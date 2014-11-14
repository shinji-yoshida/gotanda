using UnityEngine;
using System.Collections;
using System;

namespace gotanda{
	public static class Generic {
		public static T Tap<T>(this T self, Action<T> action){
			action(self);
			return self;
		}

		public static void Swap<T>(ref T lhs, ref T rhs){
			T temp;
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}
	}
}
	