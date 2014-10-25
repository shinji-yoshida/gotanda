using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace gotanda{
	public static class IntExtension {
		
		public static IEnumerable<int> Times(this int n){
			for(int i = 0; i < n; ++i)
				yield return i;
		}

	}
}