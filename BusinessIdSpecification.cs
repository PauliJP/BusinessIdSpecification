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
		
		public BusinessIdSpecification() {
			_ReasonsForDissatisfaction = new List<string>();
		}
		
		public IEnumerable<string> ReasonsForDissatisfaction { get { return _ReasonsForDissatisfaction; } }

		// Checks if given businessId satisfies the validation constraints
		/// <param name="entity">given businessId</param>
		/// <returns>true if businessId is valid</returns>
		public bool IsSatisfiedBy(string entity) {
			return false;
		}
	}
}