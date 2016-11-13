using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixNumbersCShape.src
{
    class SixNumbers
    {
        private int ans;
        private List<string> eqs;
        public SixNumbers(List<int> v, int ans)
        {
            this.ans = ans;
            this.eqs = new List<string>();
            this.Solve(v);
            this.printEqs();
        }

        private bool Solve(List<int> v)
        {
            if(v.Count == 2)
            {
                if (this.Calc(v[0], v[1], "+") == this.ans)
                {
                    this.eqs.Add(this.getEq(v[0], v[1], "+"));
                    return true;
                }
                if (this.Calc(v[0], v[1], "-") == this.ans)
                {
                    this.eqs.Add(this.getEq(v[0], v[1], "-"));
                    return true;
                }
                if (this.Calc(v[0], v[1], "*") == this.ans)
                {
                    this.eqs.Add(this.getEq(v[0], v[1], "*"));
                    return true;
                }
                if (this.Calc(v[0], v[1], "/") == this.ans)
                {
                    this.eqs.Add(this.getEq(v[0], v[1], "/"));
                    return true;
                }
                return false;
            }

            for(int i = 0; i < v.Count-1; i++)
            {
                for(int j = i+1; j < v.Count; j++)
                {
                    List<int> localv = new List<int>();
                    for (int k = 0; k < v.Count; k++)
                    {
                        if(i != k && j != k)
                        {
                            localv.Add(v[k]);
                        }
                    }
                    int resultcalc = this.Calc(v[i], v[j], "+");
                    localv.Add(resultcalc);
                    if (this.Solve(localv))
                    {
                        this.eqs.Add(this.getEq(v[i], v[j], "+"));
                        return true;
                    }
                    localv.RemoveAt(localv.Count - 1);
                    resultcalc = this.Calc(v[i], v[j], "-");
                    if (resultcalc != 0)
                    {
                        localv.Add(resultcalc);
                        if (this.Solve(localv))
                        {
                            this.eqs.Add(this.getEq(v[i], v[j], "-"));
                            return true;
                        }
                        localv.RemoveAt(localv.Count - 1);
                    }
                    resultcalc = this.Calc(v[i], v[j], "*");
                    localv.Add(resultcalc);
                    if (this.Solve(localv))
                    {
                        this.eqs.Add(this.getEq(v[i], v[j], "*"));
                        return true;
                    }
                    localv.RemoveAt(localv.Count - 1);
                    resultcalc = this.Calc(v[i], v[j], "/");
                    if(resultcalc != 0)
                    {
                        localv.Add(resultcalc);
                        if (this.Solve(localv))
                        {
                            this.eqs.Add(this.getEq(v[i], v[j], "/"));
                            return true;
                        }
                        localv.RemoveAt(localv.Count - 1);
                    }

                }
            }
            return false;
        }

        private void printEqs()
        {
            for (int i = this.eqs.Count() - 1; i >= 0; i--)
            {
                Console.WriteLine(this.eqs[i]);
            }
            if(this.eqs.Count() == 0)
            {
                Console.WriteLine("解なし");
            }
        }

        private string getEq(int n1, int n2, string ope)
        {
            if (ope == "+") return n1.ToString() + " + " + n2.ToString() + " = " + (n1 + n2).ToString();
            if(ope == "-")
            {
                if(n1 - n2 > 0)
                {
                    return n1.ToString() + " - " + n2.ToString() + " = " + (n1 - n2).ToString();
                }else
                {
                    return n2.ToString() + " - " + n1.ToString() + " = " + (n2 - n1).ToString();
                }
            }
            if (ope == "*") return n1.ToString() + " * " + n2.ToString() + " = " + (n1 * n2).ToString();
            if(ope == "/")
            {
                if(n1 % n2 == 0)
                {
                    return n1.ToString() + " / " + n2.ToString() + " = " + ((int)(n1 / n2)).ToString();
                }else if(n2 % n1 == 0)
                {
                    return n2.ToString() + " / " + n1.ToString() + " = " + ((int)(n2 / n1)).ToString();
                }
            }
            return "Error";
        }

        private int Calc(int n1, int n2, string ope)
        {
            if(ope == "+")
            {
                return n1 + n2;
            }
            if(ope == "-"){
                if(n1 - n2 > 0)
                {
                    return n1 - n2;
                }else
                {
                    return n2 - n1;
                }
            }
            if(ope == "*")
            {
                return n1 * n2;
            }
            if(ope == "/")
            {
                if(n1 % n2 == 0)
                {
                    return (int)(n1 / n2);
                }else if(n2 % n1 == 0)
                {
                    return (int)(n2 / n1);
                }
            }
            return 0;
        }
    }
}
