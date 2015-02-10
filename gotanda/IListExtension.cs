using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace gotanda{
	public static class IListExtension {
		public static bool IsEmpty<T>(this IList<T> list){
			return list.Count == 0;
		}
		
		public static T First<T>(this IList<T> list){
			return list[0];
		}
		
		public static T Last<T>(this IList<T> list){
			return list[list.Count - 1];
		}

		public static T Sample<T>(this IList<T> list) {
			Assertion._assert_(! list.IsEmpty());
			return list[Random.Range(0, list.Count)];
		}

		public static IList<T> Copy<T>(this IList<T> list){
			return new List<T>(list);
		}
	}
}