using UnityEngine;
using System.Collections;
using System;

namespace gotanda{
	public class LambdaHelper {
		public static Action NullAction(){
			return ()=>{};
		}

		public static Action<T> NullAction<T>(){
			return (t)=>{};
		}
	}
}