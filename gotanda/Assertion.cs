using UnityEngine;
using System.Collections;

namespace gotanda{
	public static class Assertion {
		public static void _assert_<T>(this T dammy, bool condition){
#if DEBUG
			if(condition)
				return;
			throw new UnityException("assertion failure");
#endif
		}

		public static void _assert_(bool condition){
#if DEBUG
			if(condition)
				return;
			throw new UnityException("assertion failure");
#endif
		}
	}
}
