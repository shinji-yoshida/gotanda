using System.Collections;
using System.Collections.Generic;

namespace gotanda {
	/**
	 * new IntRange(2, 5) represents [2,3,4] (5 is excluded).
	 */
	public class IntRange : IEnumerable<int> {
		int start;
		int end;

		public IntRange (int start, int end) {
			this.start = start;
			this.end = end;
		}

		public static IntRange CreateIncludingEnd(int start, int end){
			return new IntRange(start, end+1);
		}
		
		public static IntRange Create(int start, int end){
			return new IntRange(start, end);
		}

		public IEnumerator<int> GetEnumerator () {
			for(var i = start; i < end; i++){
				yield return i;
			}
		}

		IEnumerator IEnumerable.GetEnumerator () {
			return this.GetEnumerator();
		}
	}
}