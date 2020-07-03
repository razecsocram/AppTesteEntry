using System;
using System.Collections.Generic;
using System.Linq;

namespace CLUteisX.VCnpj
{
    public class ValidaCnpj
    {
        readonly IDictionary<string, bool> ischanged;

        public ValidaCnpj()
        {
            ischanged =
            new Dictionary<string, bool>();
        }
        public bool CnpjEValido(long cnpj)
        {
            if (cnpj == 0) return false;

            try
            {
                if (!ischanged.ContainsKey(string.Format("{0:00000000000000}", cnpj)))
                {
                    int calc0 = 0;
                    byte digDigitado = byte.Parse(string.Format("{0:00000000000000}", cnpj).Substring(12, 2));
                    var dig = new string[14];

                    for (byte idx = 0; idx < 12; idx++)
                    {
                        dig[idx] = string.Format("{0:00000000000000}", cnpj).Substring(idx, 1);
                        switch (idx)
                        {
                            case 0:
                                calc0 += int.Parse(dig[idx]) * 5;
                                break;
                            case 1:
                                calc0 += int.Parse(dig[idx]) * 4;
                                break;
                            case 2:
                                calc0 += int.Parse(dig[idx]) * 3;
                                break;
                            case 3:
                                calc0 += int.Parse(dig[idx]) * 2;
                                break;
                            case 4:
                                calc0 += int.Parse(dig[idx]) * 9;
                                break;
                            case 5:
                                calc0 += int.Parse(dig[idx]) * 8;
                                break;
                            case 6:
                                calc0 += int.Parse(dig[idx]) * 7;
                                break;
                            case 7:
                                calc0 += int.Parse(dig[idx]) * 6;
                                break;
                            case 8:
                                calc0 += int.Parse(dig[idx]) * 5;
                                break;
                            case 9:
                                calc0 += int.Parse(dig[idx]) * 4;
                                break;
                            case 10:
                                calc0 += int.Parse(dig[idx]) * 3;
                                break;
                            case 11:
                                calc0 += int.Parse(dig[idx]) * 2;
                                break;
                        }
                    }
                    calc0 %= 11;
                    if (calc0 > 1)
                    {
                        calc0 = 11 - calc0;
                    }
                    else
                    {
                        calc0 = 0;
                    }
                    dig[12] = string.Format("{0:0}", calc0);
                    calc0 = 0;
                    for (byte idx = 0; idx < 13; idx++)
                    {
                        switch (idx)
                        {
                            case 0:
                                calc0 += int.Parse(dig[idx]) * 6;
                                break;
                            case 1:
                                calc0 += int.Parse(dig[idx]) * 5;
                                break;
                            case 2:
                                calc0 += int.Parse(dig[idx]) * 4;
                                break;
                            case 3:
                                calc0 += int.Parse(dig[idx]) * 3;
                                break;
                            case 4:
                                calc0 += int.Parse(dig[idx]) * 2;
                                break;
                            case 5:
                                calc0 += int.Parse(dig[idx]) * 9;
                                break;
                            case 6:
                                calc0 += int.Parse(dig[idx]) * 8;
                                break;
                            case 7:
                                calc0 += int.Parse(dig[idx]) * 7;
                                break;
                            case 8:
                                calc0 += int.Parse(dig[idx]) * 6;
                                break;
                            case 9:
                                calc0 += int.Parse(dig[idx]) * 5;
                                break;
                            case 10:
                                calc0 += int.Parse(dig[idx]) * 4;
                                break;
                            case 11:
                                calc0 += int.Parse(dig[idx]) * 3;
                                break;
                            case 12:
                                calc0 += int.Parse(dig[idx]) * 2;
                                break;
                        }
                    }
                    calc0 %= 11;
                    if (calc0 > 1)
                    {
                        calc0 = 11 - calc0;
                    }
                    else
                    {
                        calc0 = 0;
                    }
                    dig[13] = string.Format("{0:0}", calc0);
                    if (digDigitado == byte.Parse(dig[12] + dig[13]))
                    {
                        ischanged.Add(string.Format("{0:00000000000000}", cnpj), true);
                        return true;
                    }
                    else
                    {
                        ischanged.Add(string.Format("{0:00000000000000}", cnpj), false);
                    }
                }
                else
                {
                    if(ischanged.Where(x=>x.Key.Equals(string.Format("{0:00000000000000}", cnpj)) && x.Value).Any())
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
