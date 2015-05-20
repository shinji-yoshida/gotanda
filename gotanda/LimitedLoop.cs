using UnityEngine;
using System.Collections;
using System;


namespace gotanda {
	public class LimitedLoop {
		public readonly int maxCount;
		int count;
		Func<bool> continueCheck;
		Action throwException;
		public static Action defaultException = () => {throw new Exception("loop exceeds max count.");};

		public LimitedLoop (Func<bool> continueCheck, int maxCount, Action throwException) {
			this.maxCount = maxCount;
			this.continueCheck = continueCheck;
			this.throwException = throwException;
		}

		public LimitedLoop (Func<bool> continueCheck, int maxCount)
			: this(continueCheck, maxCount, defaultException)
		{
		}

		public static LimitedLoop While(Func<bool> continueCheck, int maxCount, Action throwException) {
			return new LimitedLoop(continueCheck, maxCount, throwException);
		}
		
		public static LimitedLoop While(Func<bool> continueCheck, int maxCount) {
			return new LimitedLoop(continueCheck, maxCount);
		}

		public void Do(Action iterate) {
			count = 0;
			while(continueCheck()){
				iterate();

				if(count > maxCount)
					throwException();
				count++;
			}
		}
	}
}
