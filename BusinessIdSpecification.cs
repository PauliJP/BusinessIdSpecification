/*
 * Created by SharpDevelop.
 * User: Pauli
 * Date: 27.1.2018
 * Time: 8:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace CGIExcercise
{
	/// <summary>
	/// BusinessIdSpecification class represents a string format entity validator for business-id
	/// like "1234567-8"
	/// </summary>
	class BusinessIdSpecification : ISpecification<string>
	{
		private List<string> _ReasonsForDissatisfaction;
		
		public BusinessIdSpecification()
		{
			_ReasonsForDissatisfaction = new List<string>();
		}
		
		public IEnumerable<string> ReasonsForDissatisfaction { get { return _ReasonsForDissatisfaction; } }

		// Checks if given businessId satisfies the validation constraints
		// Specs from http://tarkistusmerkit.teppovuori.fi/tarkmerk.htm#y-tunnus2
		/// <param name="businessId">given businessId</param>
		/// <returns>true if businessId is valid</returns>
		public bool IsSatisfiedBy(string businessId)
		{
			_ReasonsForDissatisfaction = new List<string>();	// before each run, empty the errors list
			bool testOk = true;
			int[] multiplyOperands = { 7, 9, 10, 5, 8, 4, 2 };
			
			// static analysis
			if (businessId.Length != 9) {
				_ReasonsForDissatisfaction.Add(SpecificationHelper.OutOfRange);
				testOk = false;
			}
			for (int i = 0; i < businessId.Length; i++) {
				if ((i != 7) && !Char.IsNumber(businessId[i]) || (i == 7) && businessId[i] != '-') {
					_ReasonsForDissatisfaction.Add(SpecificationHelper.SyntacticallyIncorrect);
					testOk = false;
					break;
				}
			}
			
			// check digit analysis
			int sumOfProducts = 0;
			for (int i = 0; i < businessId.Length && i < multiplyOperands.Length; i++) {
				sumOfProducts += multiplyOperands[i] * (int)Char.GetNumericValue(businessId[i]);
			}
			sumOfProducts = sumOfProducts % 11;
			int checksum = 0;
			if (sumOfProducts == 0) {
				checksum = 0;
			} else if (sumOfProducts == 1) {	// no businessIds with checksum 1
				_ReasonsForDissatisfaction.Add(SpecificationHelper.CheckDigitFailed);
				testOk = false;
			} else {
				checksum = 11 - checksum;
			}
			
			// the last character in businessId must be the same as checksum
			if (checksum != (int)Char.GetNumericValue(businessId[businessId.Length - 1])) {
				if (!_ReasonsForDissatisfaction.Contains(SpecificationHelper.CheckDigitFailed)) {
					_ReasonsForDissatisfaction.Add(SpecificationHelper.CheckDigitFailed);
			    }
				testOk = false;
			}
			
			return testOk;
		}
	}
}