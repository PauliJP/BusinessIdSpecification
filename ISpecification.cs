/*
 * Created by SharpDevelop.
 * User: Pauli
 * Date: 27.1.2018
 * Time: 9:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace CGIExcercise
{
	/// <summary>
	/// Interface for Specification classes 
	/// </summary>
	public interface ISpecification<in TEntity>
	{
		IEnumerable<string> ReasonsForDissatisfaction { get; }

   		bool IsSatisfiedBy(TEntity entity);
	}
}
