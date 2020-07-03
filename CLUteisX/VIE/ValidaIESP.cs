using System;
using System.Collections.Generic;
using System.Linq;

namespace CLUteisX.VIE
{
    public class ValidaIESP
    {
        readonly IDictionary<string, bool> ischanged;
        public ValidaIESP()
        {
            ischanged = new Dictionary<string, bool>();
        }
        public bool IESPEValido(long ie)
        {
            //if (ie == 0) return false;

            try
            {
                if (!ischanged.ContainsKey(string.Format("{0:000000000000}", ie)))
                {
                    int calc0 = 0;
                    var dig = new string[12];
                    for (byte idx = 0; idx < 12; idx++)
                    {                              //110042490114 
                        dig[idx] = string.Format("{0:000000000000}", ie).Substring(idx, 1);
                        switch (idx)
                        {
                            case 0:
                                calc0 += int.Parse(dig[idx]) * 1;
                                break;
                            case 1:
                                calc0 += int.Parse(dig[idx]) * 3;
                                break;
                            case 2:
                                calc0 += int.Parse(dig[idx]) * 4;
                                break;
                            case 3:
                                calc0 += int.Parse(dig[idx]) * 5;
                                break;
                            case 4:
                                calc0 += int.Parse(dig[idx]) * 6;
                                break;
                            case 5:
                                calc0 += int.Parse(dig[idx]) * 7;
                                break;
                            case 6:
                                calc0 += int.Parse(dig[idx]) * 8;
                                break;
                            case 7:
                                calc0 += int.Parse(dig[idx]) * 10;
                                break;
                        }
                    }

                    calc0 %= 11;
                    if (calc0 == 10)
                    {
                        calc0 = 0;
                    }

                    if (calc0 != int.Parse(dig[8]))
                    {
                        ischanged.Add(string.Format("{0:000000000000}", ie), false);
                        return false;
                    }

                    calc0 = 0;
                    for (byte idx = 0; idx < 13; idx++)
                    {
                        switch (idx)
                        {
                            case 0:
                                calc0 += int.Parse(dig[idx]) * 3;
                                break;
                            case 1:
                                calc0 += int.Parse(dig[idx]) * 2;
                                break;
                            case 2:
                                calc0 += int.Parse(dig[idx]) * 10;
                                break;
                            case 3:
                                calc0 += int.Parse(dig[idx]) * 9;
                                break;
                            case 4:
                                calc0 += int.Parse(dig[idx]) * 8;
                                break;
                            case 5:
                                calc0 += int.Parse(dig[idx]) * 7;
                                break;
                            case 6:
                                calc0 += int.Parse(dig[idx]) * 6;
                                break;
                            case 7:
                                calc0 += int.Parse(dig[idx]) * 5;
                                break;
                            case 8:
                                calc0 += int.Parse(dig[idx]) * 4;
                                break;
                            case 9:
                                calc0 += int.Parse(dig[idx]) * 3;
                                break;
                            case 10:
                                calc0 += int.Parse(dig[idx]) * 2;
                                break;
                        }
                    }

                    calc0 %= 11;
                    if (calc0 == 10)
                    {
                        calc0 = 0;
                    }

                    if (calc0 == int.Parse(dig[11]))
                    {
                        ischanged.Add(string.Format("{0:000000000000}", ie), true);
                        return true;
                    }
                    else
                    {
                        ischanged.Add(string.Format("{0:000000000000}", ie), false);
                        return false;
                    }
                }
                else
                {
                    if (ischanged.Where(x => x.Key.Equals(string.Format("{0:000000000000}", ie)) && x.Value).Any())
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return false;
        }
    }
}
