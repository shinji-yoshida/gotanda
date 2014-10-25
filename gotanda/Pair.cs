using UnityEngine;
using System.Collections;
using System;

namespace gotanda{
	public class Pair<T, U> where T : class where U : class {
		public T first;
		public U second;

		public Pair(T first, U second){
			this.first = first;
			this.second = second;
		}
	}
}