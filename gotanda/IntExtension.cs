using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace gotanda{
	public static class IntExtension {
		public static IEnumerable<int> Times(this int n){
			for(int i = 0; i < n; ++i)
				yield return i;
		}
		
		public static IEnumerable<int> ToExcluding(this int n, int to){
			while(n < to){
				yield return n;
				++n;
			}
		}
		
		public static IEnumerable<int> ToIncluding(this int n, int to){
			while(n <= to){
				yield return n;
				++n;
			}
		}

		public static bool IsEven(this int n){
			return n % 2 == 0;
		}
		
		public static bool IsOdd(this int n){
			return n % 2 != 0;
		}
	}
}