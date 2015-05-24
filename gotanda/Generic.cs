using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace gotanda{
	public static class Generic {
		public static T Tap<T>(this T self, Action<T> action){
			action(self);
			return self;
		}

		public static T TapDebugLog<T>(this T self, Func<T, string> msg){
			Debug.Log(msg(self));
			return self;
		}

		public static void Swap<T>(ref T lhs, ref T rhs){
			T temp;
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		public static IEnumerable<T> Enumerable<T>(this T self){
			yield return self;
		}

		public static T OrIfNullThenThrow<T>(this T self, Func<Exception> exceptionFactory){
			if(self != null)
				return self;

			throw exceptionFactory();
		}
		
		public static List<T> CreateList<T>(params T[] args){
			var result = new List<T>(args);
			return result;
		}
	}
}
	