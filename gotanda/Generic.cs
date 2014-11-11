using UnityEngine;
using System.Collections;
using System;

namespace gotanda{
	public static class Generic {
		public static T Tap<T>(this T self, Action<T> action){
			action(self);
			return self;
		}
	}
}
	