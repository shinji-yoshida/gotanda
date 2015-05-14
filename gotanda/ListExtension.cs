using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace gotanda{
	public static class ListExtension {
		public static bool IsEmpty<T>(this List<T> list) {
			return list.Count == 0;
		}
		
		public static T First<T>(this List<T> list) {
			return list[0];
		}
		
		public static T Last<T>(this List<T> list) {
			return list[list.Count - 1];
		}

		public static T Sample<T>(this List<T> list) {
			Assertion._assert_(! list.IsEmpty());
			return list[Random.Range(0, list.Count)];
		}

		public static List<T> Copy<T>(this List<T> list) {
			return new List<T>(list);
		}
	}
}