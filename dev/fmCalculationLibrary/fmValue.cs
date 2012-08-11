using System;
using System.IO;

namespace fmCalculationLibrary
{
    public struct fmValue : IComparable
    {
        private const string UndefinedValue = "";
        public bool defined;
        public double value;
        public static int outputPrecision = 3;

        public static fmValue Infinity()
        {
            return new fmValue(1e100);
        }

        public fmValue(double x)
        {
            defined = true;
            value = x;
        }

        public fmValue(double x, bool d)
        {
            defined = d;
            value = x;
        }

        public fmValue(fmValue val)
        {
            defined = val.defined;
            value = val.value;
        }

        public fmValue Round(int precision)
        {
            var result = new fmValue(0, defined);

            if (value == 0 || double.IsInfinity(value))
            {
                return result;
            }

            double pMin = Math.Pow(10, precision - 1);
            double pMax = Math.Pow(10, precision);
            double factor = 1;
            const double eps = 1e-8;
            
            result.value = value;
            
            while (Math.Abs(result.value) < pMin - eps)
            {
                result.value *= 10; 
                factor *= 10;
            }

            while (Math.Abs(result.value) >= pMax - eps)
            {
                result.value /= 10;
                factor /= 10;
            }

            result.value = Math.Floor(result.value + 0.5 + eps);
            result.value /= factor;
            return result;
        }

        public override string ToString()
        {
            return ToString(outputPrecision);
        }

        public string ToString(int precision)
        {
            fmValue val = Round(precision);
            string res = Convert.ToString(val.value);
            res = val.defined ? res : UndefinedValue;
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
            sw.WriteLine(defined);
            sw.WriteLine(value);
        }

        public void ReadFromStream(StreamReader sr)
        {
            defined = Convert.ToBoolean(sr.ReadLine());
            value = Convert.ToDouble(sr.ReadLine());
        }

        public static fmValue StringToValue(String s)
        {
            var res = new fmValue();
            res.defined = double.TryParse(s, out res.value);
            return res;
        }

        public static fmValue ObjectToValue(object obj)
        {
            if (obj == null)
            {
                return new fmValue();
            }

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
            if (!op1.defined && !op2.defined)
                return false;
            if (!op1.defined)
                return true;
            if (!op2.defined)
                return false;
            return op1.value < op2.value;
        }

        public static bool operator <=(fmValue op1, fmValue op2)
        {
            if (!op1.defined && !op2.defined)
                return false;
            if (!op1.defined)
                return true;
            if (!op2.defined)
                return false;
            return op1.value <= op2.value;
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
            var res = new fmValue(-op.value, op.defined);
            return res;
        }

        public static fmValue operator +(fmValue op1, fmValue op2)
        {
            var res = new fmValue(op1.value + op2.value, op1.defined && op2.defined);
            return res;
        }

        public static fmValue operator +(fmValue op1, double op2)
        {
            var res = new fmValue(op1.value + op2, op1.defined);
            return res;
        }

        public static fmValue operator +(double op1, fmValue op2)
        {
            var res = new fmValue(op1 + op2.value, op2.defined);
            return res;
        }

        public static fmValue operator -(fmValue op1, fmValue op2)
        {
            var res = new fmValue(op1.value - op2.value, op1.defined && op2.defined);
            return res;
        }

        public static fmValue operator -(fmValue op1, double op2)
        {
            var res = new fmValue(op1.value - op2, op1.defined);
            return res;
        }

        public static fmValue operator -(double op1, fmValue op2)
        {
            var res = new fmValue(op1 - op2.value, op2.defined);
            return res;
        }

        public static fmValue operator *(fmValue op1, fmValue op2)
        {
            var res = new fmValue(op1.value*op2.value, op1.defined && op2.defined);
            return res;
        }

        public static fmValue operator *(fmValue op1, double op2)
        {
            var res = new fmValue(op1.value*op2, op1.defined);
            return res;
        }

        public static fmValue operator *(double op1, fmValue op2)
        {
            var res = new fmValue(op1*op2.value, op2.defined);
            return res;
        }

        public static fmValue operator /(fmValue op1, fmValue op2)
        {
            if (!op1.defined || !op2.defined)
                return new fmValue();

            if (op2.value == 0)
                return new fmValue(0, op1.value == 0);    

            return new fmValue(op1.value / op2.value);
        }

        public static fmValue operator /(fmValue op1, double op2)
        {
            return op1 / new fmValue(op2);
        }

        public static fmValue operator /(double op1, fmValue op2)
        {
            return new fmValue(op1) / op2;
        }

        public static fmValue Abs(fmValue op)
        {
            op.value = Math.Abs(op.value);
            return op;
        }

        public static fmValue LambertW(fmValue x)
        {
            if (x.value < -Math.Exp(-1.0) || x.defined == false)
            {
                return new fmValue();
            }
            if (x.value > 0)
            {
                double y = 0.5 * x.value, dy = 0.25 * x.value;
                while (dy > 1e-9)
                {
                    double f = y * Math.Exp(y);
                    if (f > x.value) y -= dy; else y += dy;
                    dy *= 0.5;
                }
                return new fmValue(y);
            }
            else
            {
                double y = 0.5, dy = 0.25;
                while (dy > 1e-9)
                {
                    double f = -y * Math.Exp(-y);
                    if (f < x.value) y -= dy; else y += dy;
                    dy *= 0.5;
                }
                return new fmValue(-y);
            }
        }

        public static fmValue Exp(fmValue op)
        {
            var res = new fmValue {defined = op.defined};
            res.value = res.defined ? Math.Exp(op.value) : 1;
            return res;
        }

        public static fmValue Log(fmValue op)
        {
            var res = new fmValue {defined = op.defined && op.value > 0};
            res.value = res.defined ? Math.Log(op.value) : 1;
            return res;
        }

        public static fmValue Pow(fmValue op1, fmValue degree)
        {
            var res = new fmValue
                          {
                              defined =
                                  op1.defined && degree.defined && (op1.value > 0 || op1.value == 0 && degree.value > 0)
                          };
            res.value = res.defined ? Math.Pow(op1.value, degree.value) : 1;
            return res;
        }

        public static fmValue Pow(fmValue op1, double degree)
        {
            var res = new fmValue {defined = op1.defined && op1.value > 0};
            res.value = res.defined ? Math.Pow(op1.value, degree) : 1;
            return res;
        }

        public static fmValue Sqrt(fmValue op1)
        {
            var res = new fmValue {defined = op1.defined && op1.value > 0};
            res.value = res.defined ? Math.Sqrt(op1.value) : 1;
            return res;
        }

        public static fmValue Sqr(fmValue op)
        {
            var res = new fmValue(op);
            res = res*op;
            return res;
        }

        public static fmValue Erf(fmValue op)
        {
            var res = new fmValue {defined = op.defined};
            res.value = res.defined ? normaldistr.erf(op.value) : 1;
            return res;
        }

        public bool Equals(fmValue obj)
        {
            return (!defined && !obj.defined || defined && obj.defined && obj.value == value);
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
                return (value.GetHashCode()*397) ^ defined.GetHashCode();
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is fmValue)
            {
                var temp = (fmValue)obj;

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
            var eps = new fmValue(1e-9 * Math.Max(Math.Abs(a.value), Math.Abs(b.value)));
            return a < b - eps;
        }

        public static bool Greater(fmValue a, fmValue b)
        {
            return Less(b, a);
        }

        public static fmValue Sign(fmValue beginValue, fmValue eps)
        {
            return new fmValue(Math.Abs(beginValue.value) <= eps.value ? 0 : beginValue.value > 0 ? 1 : -1, beginValue.defined && eps.defined);
        }

        public fmValue RoundUp(fmValue x, int precision)
        {
            if (x.value == 0)
                return x;

            double factor = GetFactor(x, precision);
            x.value *= factor;
            x.value = Math.Ceiling(x.value - 1e-12);
            x.value /= factor;
            return x;
        }

        public fmValue RoundDown(fmValue x, int precision)
        {
            if (x.value == 0)
                return x;

            double factor = GetFactor(x, precision);
            x.value *= factor;
            x.value = Math.Floor(x.value + 1e-12);
            x.value /= factor;
            return x;
        }

        private static double GetFactor(fmValue x, int precision)
        {
            double pMin = Math.Pow(10, precision - 1);
            double pMax = Math.Pow(10, precision);
            double factor = 1;
            fmValue result = x;
            
            while (Math.Abs(result.value) < pMin)
            {
                result.value *= 10;
                factor *= 10;
            }

            while (Math.Abs(result.value) >= pMax)
            {
                result.value /= 10;
                factor /= 10;
            }

            return factor;
        }

        public static fmValue Min(fmValue a, fmValue b)
        {
            return a < b ? a : b;
        }

        public static int EpsCompare(double x, double y, double eps)
        {
            double a = Math.Max(Math.Abs(x), Math.Abs(y));
            eps = Math.Max(eps, eps * a);
            if (Math.Abs(x - y) <= eps)
            {
                return 0;
            }
            return x < y ? -1 : 1;
        }
    }
}