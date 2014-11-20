using UnityEngine;
using System.Collections;
using System;

namespace gotanda{
	public class LambdaHelper {
		public static Action NullAction(){
			int saveFromAOT = 0;
			return () => saveFromAOT.GetHashCode();
		}

		public static Action<T> NullAction<T>(){
			int saveFromAOT = 0;
			return _ => saveFromAOT.GetHashCode();
		}
	}
}