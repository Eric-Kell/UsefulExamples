#include "MathFuncsDll.h"

namespace MathFuncs
{
	double SummArray(double ar[], int l)
	{
		double m = 0;
		for (int i = 0; i < l; i++)
			m += ar[i];
		return m;
	}
	double Add(double a, double b)
	{
		return a + b;
	}
	double Subtract(double a, double b)
	{
		return a - b;
	}
	double Multiply(double a, double b)
	{
		return a*b;
	}
	double Divide(double a, double b)
	{
		if (b == 0)
			throw invalid_argument("b cannot be zero!");
		return a / b;
	}
}