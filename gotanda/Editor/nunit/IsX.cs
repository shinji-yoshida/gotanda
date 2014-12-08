using System.Collections;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;

namespace gotanda{
	public class IsX {
		
		public static BinarySerializableConstraint BinarySerializable
		{
			get
			{
				return Is.BinarySerializable;
			}
		}
		
		public static EmptyConstraint Empty
		{
			get
			{
				return Is.Empty;
			}
		}
		
		public static FalseConstraint False
		{
			get
			{
				return Is.False;
			}
		}
		
		public static NaNConstraint NaN
		{
			get
			{
				return Is.NaN;
			}
		}
		
		public static LessThanConstraint Negative
		{
			get
			{
				return Is.Negative;
			}
		}
		
		public static ConstraintExpression Not
		{
			get
			{
				return Is.Not;
			}
		}
		
		public static NullConstraint Null
		{
			get
			{
				return Is.Null;
			}
		}
		
		public static CollectionOrderedConstraint Ordered
		{
			get
			{
				return Is.Ordered;
			}
		}
		
		public static GreaterThanConstraint Positive
		{
			get
			{
				return Is.Positive;
			}
		}
		
		public static TrueConstraint True
		{
			get
			{
				return Is.True;
			}
		}
		
		public static UniqueItemsConstraint Unique
		{
			get
			{
				return Is.Unique;
			}
		}
		
		public static XmlSerializableConstraint XmlSerializable
		{
			get
			{
				return Is.XmlSerializable;
			}
		}
		
		//
		// Static Methods
		//
		public static AssignableFromConstraint AssignableFrom<T> ()
		{
			return Is.AssignableFrom<T>();
		}
		
		public static AssignableFromConstraint AssignableFrom (Type expectedType)
		{
			return Is.AssignableFrom(expectedType);
		}
		
		public static AssignableToConstraint AssignableTo<T> ()
		{
			return Is.AssignableTo<T>();
		}
		
		public static AssignableToConstraint AssignableTo (Type expectedType)
		{
			return Is.AssignableTo(expectedType);
		}
		
		public static GreaterThanOrEqualConstraint AtLeast (object expected)
		{
			return Is.AtLeast(expected);
		}
		
		public static LessThanOrEqualConstraint AtMost (object expected)
		{
				return Is.AtMost(expected);
		}
		
		public static EqualConstraint EqualTo (object expected)
		{
			return Is.EqualTo(expected);
		}
		
		public static CollectionEquivalentConstraint EquivalentTo (IEnumerable expected)
		{
			return Is.EquivalentTo(expected);
		}
		
		public static GreaterThanConstraint GreaterThan (object expected)
		{
			return Is.GreaterThan(expected);
		}
		
		public static GreaterThanOrEqualConstraint GreaterThanOrEqualTo (object expected)
		{
			return Is.GreaterThanOrEqualTo(expected);
		}
		
		public static RangeConstraint<T> InRange<T> (T from, T to) where T : IComparable<T>
		{
			return Is.InRange(from, to);
		}
		
		public static InstanceOfTypeConstraint InstanceOf<T> ()
		{
			return Is.InstanceOf<T>();
		}
		
		public static InstanceOfTypeConstraint InstanceOf (Type expectedType)
		{
			return new InstanceOfTypeConstraint (expectedType);
		}
		
		[Obsolete ("Use InstanceOf(expectedType)")]
		public static InstanceOfTypeConstraint InstanceOfType (Type expectedType)
		{
			return Is.InstanceOfType(expectedType);
		}
		
		[Obsolete ("Use InstanceOf<T>()")]
		public static InstanceOfTypeConstraint InstanceOfType<T> ()
		{
			return Is.InstanceOfType<T>();
		}
		
		public static LessThanConstraint LessThan (object expected)
		{
			return Is.LessThan(expected);
		}
		
		public static LessThanOrEqualConstraint LessThanOrEqualTo (object expected)
		{
			return Is.LessThanOrEqualTo(expected);
		}
		
		public static SameAsConstraint SameAs (object expected)
		{
			return Is.SameAs(expected);
		}
		
		public static SamePathConstraint SamePath (string expected)
		{
			return Is.SamePath(expected);
		}
		
		public static SamePathOrUnderConstraint SamePathOrUnder (string expected)
		{
			return Is.SamePathOrUnder(expected);
		}
		
		public static SubstringConstraint StringContaining (string expected)
		{
			return Is.StringContaining(expected);
		}
		
		public static EndsWithConstraint StringEnding (string expected)
		{
			return Is.StringEnding(expected);
		}
		
		public static RegexConstraint StringMatching (string pattern)
		{
			return Is.StringMatching(pattern);
		}
		
		public static StartsWithConstraint StringStarting (string expected)
		{
			return Is.StringStarting(expected);
		}
		
		public static SubPathConstraint SubPath (string expected)
		{
			return Is.SubPath(expected);
		}
		
		public static CollectionSubsetConstraint SubsetOf (IEnumerable expected)
		{
			return Is.SubsetOf(expected);
		}
		
		public static ExactTypeConstraint TypeOf (Type expectedType)
		{
			return Is.TypeOf(expectedType);
		}
		
		public static ExactTypeConstraint TypeOf<T> ()
		{
			return Is.TypeOf<T>();
		}

		public static EqualConstraint NearlyEqualTo (float val)
		{
			if(val == 0)
				return EqualTo(val).Within(0.000001);

			return EqualTo(val).Within(Math.Abs(val) * 0.000001);
		}
	}
}
