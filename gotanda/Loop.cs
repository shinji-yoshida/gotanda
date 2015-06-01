using UnityEngine;
using System.Collections;
using System;


namespace gotanda {
	///
	/// usage:
	/// 
	/// Loop.Limit(1000000)
	///     .While(() => cat.CanRelive())
	///     .Do(() => cat.Die());
	/// 
	public class Loop {
		public readonly int limit;
		int count;
		Func<bool> continueCheck;
		Action throwException;
		public static Action defaultException = () => {throw new Exception("loop exceeds max count.");};


		public static LimitedLoop Limit(int limit) {
			return new LimitedLoop(limit);
		}


		public Loop (Func<bool> continueCheck, int maxCount, Action throwException) {
			this.limit = maxCount;
			this.continueCheck = continueCheck;
			this.throwException = throwException;
		}

		public void Do(Action iterate) {
			count = 0;
			while(continueCheck()){
				iterate();

				count++;
				if(count >= limit)
					throwException();
			}
		}
		
		public void Do(Action<Action> iterate) {
			count = 0;
			var broken = false;
			Action breaker = () => broken = true;
			while(continueCheck()){
				iterate(breaker);
				if(broken)
					break;
				
				count++;
				if(count >= limit)
					throwException();
			}
		}

		public class LimitedLoop {
			int limit;
			Action throwException;

			public LimitedLoop (int limit) {
				this.limit = limit;
				throwException = Loop.defaultException;
			}

			public LimitedLoop Throws(Action onExceedLimit) {
				throwException = onExceedLimit;
				return this;
			}
			
			public Loop While(Func<bool> continueCheck) {
				return new Loop(continueCheck, limit, throwException);
			}
		}
	}
}
