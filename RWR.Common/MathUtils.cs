using System;
using System.Data;
using System.Collections.Generic;

namespace RWR.Common
{
	/// <summary>
	/// Commonly used Math functions (static).
	/// </summary>
	public class MathUtils
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="x1"></param>
		/// <returns></returns>
		public static decimal[] GetLinearInterpolatedValues(decimal[] x, decimal[] y, decimal[] x1)
		{	
			var y1=new decimal[x1.Length];

			for(int index=0;index<x1.Length;index++)
				y1[index]=GetLinearInterpolatedValue(x,y,x1[index]);

			return y1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="x1"></param>
		/// <returns></returns>
		public static decimal GetLinearInterpolatedValue(decimal[] x, decimal[] y, decimal x1)
		{
			if(x1>x[x.Length-1] || x1<x[0])
				throw new Exception("Required point is out of range of given set of points.");
			
			for(int index=0;index<x.Length;index++)
			{
				if(x1==x[index])
					return y[index];
			
				if(x1>x[index] && x1<x[index+1])
					return y[index]+(((y[index+1]-y[index])/(x[index+1]-x[index]))*(x1-x[index]));
			}
			throw new Exception("Required point is out of range of given set of points.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Yield"></param>
		/// <param name="Tenor"></param>
		/// <returns></returns>
        public static double Duration(double Yield, double Tenor)
        {
            double ShYield = (.001 + Yield) / 200;
            Yield = Yield / 200;
            double Calc = Math.Pow(1 + Yield, -2 * Tenor);
            double ShCalc = Math.Pow(1 + ShYield, -2 * Tenor);

            return 100000 * (Yield * ((1 - Calc) / Yield - (1 - ShCalc) / ShYield) + Calc - ShCalc);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="values"></param>
		/// <param name="weights"></param>
		/// <returns></returns>
		public static decimal CalculateWeightedAverage(List<decimal> values, List<decimal> weights)
		{
			if (values.Count != weights.Count)
				throw new Exception(" The counts of values and weights array do not match.");
			if (values.Count == 0 && weights.Count == 0)
				throw new Exception("There is no data in the row array, therefore wt. avg cannot be calculated.");

			decimal sumProduct = 0;
			decimal sum = 0;
			int i = 0;
			foreach (decimal value in values)
			{
				sumProduct += value * weights[i++];
				sum += value;
			}
			if (sum > 0)
				return sumProduct / sum;
			
			throw new Exception("No values supplied to calculate the weighted average");
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="rows"></param>
		/// <param name="valIndex"></param>
		/// <param name="wtIndex"></param>
		/// <returns></returns>
		public static decimal CalculateWeightedAverage(DataRow[] rows, int valIndex, int wtIndex)
		{
			if (rows.Length <= 0)
				throw new Exception("There is no data in the row array, therefore wt. avg cannot be calculated.");
			decimal sumProduct = 0;
			decimal sum = 0;
			foreach (DataRow row in rows)
			{
				if (row[valIndex] != DBNull.Value && row[wtIndex] != DBNull.Value)
					sumProduct += Convert.ToDecimal(row[valIndex]) * Convert.ToDecimal(row[wtIndex]);
				if (row[wtIndex] != null)
					sum += Convert.ToDecimal(row[wtIndex]);
			}
			if (sum > 0)
				return sumProduct / sum;

			throw new Exception("No values supplied to calculate the weighted average");
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="rows"></param>
		/// <param name="valColName"></param>
		/// <param name="wtColName"></param>
		/// <returns></returns>
		public static decimal CalculateWeightedAverage(DataRow[] rows, string valColName, string wtColName)
		{
			if (rows.Length <= 0)
				throw new Exception("There is no data in the row array, therefore wt. avg cannot be calculated.");

			decimal sumProduct = 0;
			decimal sum = 0;
			foreach (DataRow row in rows)
			{
				if (row[valColName] != DBNull.Value && row[wtColName] != DBNull.Value)
					sumProduct += Convert.ToDecimal(row[valColName]) * Convert.ToDecimal(row[wtColName]);
				if (row[wtColName] != null)
					sum += Convert.ToDecimal(row[wtColName]);
			}
			if (sum > 0)
				return sumProduct / sum;

			throw new Exception("No values supplied to calculate the weighted average");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <param name="numeCol"></param>
		/// <param name="denomCol"></param>
		/// <returns></returns>
		public static decimal CalculateRatio(DataTable table, string numeCol, string denomCol)
		{
			decimal numerator = 0;
			decimal denominator = 0;
			if (table.Compute("SUM(" + numeCol + ")", "") != DBNull.Value)
				numerator = Convert.ToDecimal(table.Compute("SUM(" + numeCol + ")", ""));


			if (table.Compute("SUM(" + denomCol + ")", "") != DBNull.Value)
				denominator = Convert.ToInt32(table.Compute("SUM(" + denomCol + ")", ""));

			return (numerator / denominator);
		}
	}
}
