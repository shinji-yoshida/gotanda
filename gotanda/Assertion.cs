using UnityEngine;
using System.Collections;

namespace gotanda{
	public static class Assertion {
		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void _assert_(bool condition){
			if(condition)
				return;
			throw new UnityException("assertion failure");
		}
		
		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void _assert_(bool condition, string message){
			if(condition)
				return;
			throw new UnityException(message);
		}
		
		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void _only_editor_(System.Action action){
			action ();
		}
	}
}
