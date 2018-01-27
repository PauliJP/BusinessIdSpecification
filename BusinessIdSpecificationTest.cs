/*
 * Created by SharpDevelop.
 * User: Pauli
 * Date: 27.1.2018
 * Time: 13:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace CGIExcercise
{
	[TestFixture]
	public class BusinessIdSpecificationTest
	{
		private readonly BusinessIdSpecification _businessIdSpecification;
		
		public BusinessIdSpecificationTest()
		{
			_businessIdSpecification = new BusinessIdSpecification();
		}
		
		[Test]
		public void TestInvalidLengthId()
		{
			bool result = _businessIdSpecification.IsSatisfiedBy("123");
			IEnumerable<string> reasons = _businessIdSpecification.ReasonsForDissatisfaction;
			Assert.IsFalse(result);
			Assert.IsNotEmpty(reasons);
			Assert.Contains(SpecificationHelper.OutOfRange, (System.Collections.ICollection)reasons);
		}
	}
}
