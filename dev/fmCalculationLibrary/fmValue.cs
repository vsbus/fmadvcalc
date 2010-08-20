using System;
using System.IO;

namespace fmCalculationLibrary
{
    public struct fmValue : IComparable
    {
        private const string UNDEFINED_VALUE = "n/a";
        public bool Defined;
        public double Value;
        public static int outputPrecision = 3;

        public static fmValue Infinity()
        {
            return new fmValue(1e100);
        }

        public fmValue(double x)
        {
            Defined = true;
            Value = x;
        }

        public fmValue(double x, bool d)
        {
            Defined = d;
            Value = x;
        }

        public fmValue(fmValue val)
        {
            Defined = val.Defined;
            Value = val.Value;
        }

        public fmValue Round(int precision)
        {
            fmValue result = new fmValue(0, Defined);

            if (Value == 0)
            {
                return result;
            }

            double pMin = Math.Pow(10, precision - 1);
            double pMax = Math.Pow(10, precision);
            double factor = 1;
            const double eps = 1e-8;
            
            result.Value = Value;
            
            while (Math.Abs(result.Value) < pMin - eps)
            {
                result.Value *= 10; 
                factor *= 10;
            }

            while (Math.Abs(result.Value) >= pMax - eps)
            {
                result.Value /= 10;
                factor /= 10;
            }

            result.Value = Math.Floor(result.Value + 0.5 + eps);
            result.Value /= factor;
            return result;
        }

        public override string ToString()
        {
            return ToString(outputPrecision);
        }

        public string ToString(int precision)
        {
            fmValue val = Round(precision);
            string res = Convert.ToString(val.Value);
            res = val.Defined ? res : UNDEFINED_VALUE;
            return res;
        }

        public static bool IsValueString(String s)
        {
            try
            {
                Convert.ToDouble(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public void WriteToStream(StreamWriter sw)
        {
            sw.WriteLine(Defined);
            sw.WriteLine(Value);
        }

        public void ReadFromStream(StreamReader sr)
        {
            Defined = Convert.ToBoolean(sr.ReadLine());
            Value = Convert.ToDouble(sr.ReadLine());
        }

        public static fmValue StringToValue(String s)
        {
            fmValue res = new fmValue();
            res.Defined = double.TryParse(s, out res.Value);
            return res;
        }

        public static fmValue ObjectToValue(object obj)
        {
            if (obj.GetType() == typeof(string))
            {
                return StringToValue(Convert.ToString(obj));
            }

            if (obj.GetType() == typeof(fmValue))
            {
                return (fmValue)obj;
            }

            if (obj.GetType() == typeof(double))
            {
                return new fmValue((double)obj);
            }

            throw new Exception("Can't convert object to fmValue");
        }

        public static bool operator <(fmValue op1, fmValue op2)
        {
            if (!op1.Defined && !op2.Defined)
                return false;
            if (!op1.Defined)
                return true;
            if (!op2.Defined)
                return false;
            return op1.Value < op2.Value;
        }

        public static bool operator <=(fmValue op1, fmValue op2)
        {
            if (!op1.Defined && !op2.Defined)
                return false;
            if (!op1.Defined)
                return true;
            if (!op2.Defined)
                return false;
            return op1.Value <= op2.Value;
        }

        public static bool operator >(fmValue op1, fmValue op2)
        {
            return op2 < op1;
        }

        public static bool operator >=(fmValue op1, fmValue op2)
        {
            return op2 <= op1;
        }

        public static bool operator ==(fmValue op1, fmValue op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(fmValue op1, fmValue op2)
        {
            return !op1.Equals(op2);
        }

        public static fmValue operator -(fmValue op)
        {
            fmValue res = new fmValue(-op.Value, op.Defined);
            return res;
        }

        public static fmValue operator +(fmValue op1, fmValue op2)
        {
            fmValue res = new fmValue(op1.Value + op2.Value, op1.Defined && op2.Defined);
            return res;
        }

        public static fmValue operator +(fmValue op1, double op2)
        {
            fmValue res = new fmValue(op1.Value + op2, op1.Defined);
            return res;
        }

        public static fmValue operator +(double op1, fmValue op2)
        {
            fmValue res = new fmValue(op1 + op2.Value, op2.Defined);
            return res;
        }

        public static fmValue operator -(fmValue op1, fmValue op2)
        {
            fmValue res = new fmValue(op1.Value - op2.Value, op1.Defined && op2.Defined);
            return res;
        }

        public static fmValue operator -(fmValue op1, double op2)
        {
            fmValue res = new fmValue(op1.Value - op2, op1.Defined);
            return res;
        }

        public static fmValue operator -(double op1, fmValue op2)
        {
            fmValue res = new fmValue(op1 - op2.Value, op2.Defined);
            return res;
        }

        public static fmValue operator *(fmValue op1, fmValue op2)
        {
            fmValue res = new fmValue(op1.Value*op2.Value, op1.Defined && op2.Defined);
            return res;
        }

        public static fmValue operator *(fmValue op1, double op2)
        {
            fmValue res = new fmValue(op1.Value*op2, op1.Defined);
            return res;
        }

        public static fmValue operator *(double op1, fmValue op2)
        {
            fmValue res = new fmValue(op1*op2.Value, op2.Defined);
            return res;
        }

        public static fmValue operator /(fmValue op1, fmValue op2)
        {
            fmValue res = new fmValue();
            res.Defined = op1.Defined && op2.Defined && (op2.Value != 0.0);
            res.Value = res.Defined ? op1.Value/op2.Value : 1;
            return res;
        }

        public static fmValue operator /(fmValue op1, double op2)
        {
            fmValue res = new fmValue();
            res.Defined = op1.Defined && (op2 != 0.0);
            res.Value = res.Defined ? op1.Value/op2 : 1;
            return res;
        }

        public static fmValue operator /(double op1, fmValue op2)
        {
            fmValue res = new fmValue();
            res.Defined = op2.Defined && (op2.Value != 0.0);
            res.Value = res.Defined ? op1/op2.Value : 1;
            return res;
        }

        public static fmValue Abs(fmValue op)
        {
            op.Value = Math.Abs(op.Value);
            return op;
        }

        public static fmValue Exp(fmValue op)
        {
            fmValue res = new fmValue();
            res.Defined = op.Defined;
            res.Value = res.Defined ? Math.Exp(op.Value) : 1;
            return res;
        }

        public static fmValue Log(fmValue op)
        {
            fmValue res = new fmValue();
            res.Defined = op.Defined && op.Value > 0;
            res.Value = res.Defined ? Math.Log(op.Value) : 1;
            return res;
        }

        public static fmValue Pow(fmValue op1, fmValue degree)
        {
            fmValue res = new fmValue();
            res.Defined = op1.Defined && degree.Defined && (op1.Value > 0 || op1.Value == 0 && degree.Value > 0);
            res.Value = res.Defined ? Math.Pow(op1.Value, degree.Value) : 1;
            return res;
        }

        public static fmValue Pow(fmValue op1, double degree)
        {
            fmValue res = new fmValue();
            res.Defined = op1.Defined && op1.Value > 0;
            res.Value = res.Defined ? Math.Pow(op1.Value, degree) : 1;
            return res;
        }

        public static fmValue Sqrt(fmValue op1)
        {
            fmValue res = new fmValue();
            res.Defined = op1.Defined && op1.Value > 0;
            res.Value = res.Defined ? Math.Sqrt(op1.Value) : 1;
            return res;
        }

        public static fmValue Sqr(fmValue op)
        {
            fmValue res = new fmValue(op);
            res = res*op;
            return res;
        }

        public static fmValue Erf(fmValue op)
        {
            fmValue res = new fmValue();
            res.Defined = op.Defined;
            res.Value = res.Defined ? normaldistr.erf(op.Value) : 1;
            return res;
        }

        public bool Equals(fmValue obj)
        {
            return (!Defined && !obj.Defined || Defined && obj.Defined && obj.Value == Value);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (fmValue)) return false;
            return Equals((fmValue) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode()*397) ^ Defined.GetHashCode();
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is fmValue)
            {
                fmValue temp = (fmValue)obj;

                if (this < temp) return -1;
                if (this > temp) return 1;
                return 0;                
            }

            throw new ArgumentException("object is not a fmValue");
        }


        public static fmValue Max(fmValue a, fmValue b)
        {
            return a > b ? a : b;
        }

        public static bool Less(fmValue a, fmValue b)
        {
            fmValue eps = new fmValue(1e-9 * Math.Max(Math.Abs(a.Value), Math.Abs(b.Value)));
            return a < b - eps;
        }

        public static bool Greater(fmValue a, fmValue b)
        {
            return Less(b, a);
        }

        internal static fmValue Sign(fmValue beginValue, fmValue eps)
        {
            return new fmValue(Math.Abs(beginValue.Value) <= eps.Value ? 0 : beginValue.Value > 0 ? 1 : -1, beginValue.Defined && eps.Defined);
        }

        public fmValue RoundUp(fmValue x, int precision)
        {
            if (x.Value == 0)
                return x;

            double factor = GetFactor(x, precision);
            x.Value *= factor;
            x.Value = Math.Ceiling(x.Value - 1e-12);
            x.Value /= factor;
            return x;
        }

        public fmValue RoundDown(fmValue x, int precision)
        {
            if (x.Value == 0)
                return x;

            double factor = GetFactor(x, precision);
            x.Value *= factor;
            x.Value = Math.Floor(x.Value + 1e-12);
            x.Value /= factor;
            return x;
        }

        private double GetFactor(fmValue x, int precision)
        {
            double pMin = Math.Pow(10, precision - 1);
            double pMax = Math.Pow(10, precision);
            double factor = 1;
            fmValue result = x;
            
            while (Math.Abs(result.Value) < pMin)
            {
                result.Value *= 10;
                factor *= 10;
            }

            while (Math.Abs(result.Value) >= pMax)
            {
                result.Value /= 10;
                factor /= 10;
            }

            return factor;
        }

        public static fmValue Min(fmValue a, fmValue b)
        {
            return a < b ? a : b;
        }

        public static int epsCompare(double x, double y, double eps)
        {
            double A = Math.Max(Math.Abs(x), Math.Abs(y));
            eps = Math.Max(eps, eps * A);
            if (Math.Abs(x - y) <= eps)
            {
                return 0;
            }
            return x < y ? -1 : 1;
        }
    }
}