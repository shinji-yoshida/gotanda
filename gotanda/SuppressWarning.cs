using UnityEngine;
using System.Collections;

namespace gotanda {

	public class SuppressWarning {
		[System.Diagnostics.Conditional("NEVER")]
		public static void VariableNeverUsed(object unused){
		}
	}

}

