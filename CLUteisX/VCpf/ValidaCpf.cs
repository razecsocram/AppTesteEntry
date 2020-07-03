using System;
using System.Collections.Generic;
using System.Linq;

namespace CLUteisX.VCpf
{
    public class ValidaCpf
    {
        readonly IDictionary<string, bool> ischanged;
        public ValidaCpf()
        {
            ischanged =
            new Dictionary<string, bool>();
        }
        public bool CpfEValido(long cpf)
        {
            if (cpf == 0) return false;

            try
            {
                if (!ischanged.ContainsKey(string.Format("{0:00000000000}", cpf)))
                {
                    int calc0 = 0;
                    byte digDigitado = byte.Parse(string.Format("{0:00000000000}", cpf).Substring(9, 2));
                    var dig = new string[11];

                    for (byte idx = 0; idx < 9; idx++)
                    {
                        dig[idx] = string.Format("{0:00000000000}", cpf).Substring(idx, 1);
                        switch (idx)
                        {
                            case 0:
                                calc0 += int.Parse(dig[idx]) * 10;
                                break;
                            case 1:
                                calc0 += int.Parse(dig[idx]) * 9;
                                break;
                            case 2:
                                calc0 += int.Parse(dig[idx]) * 8;
                                break;
                            case 3:
                                calc0 += int.Parse(dig[idx]) * 7;
                                break;
                            case 4:
                                calc0 += int.Parse(dig[idx]) * 6;
                                break;
                            case 5:
                                calc0 += int.Parse(dig[idx]) * 5;
                                break;
                            case 6:
                                calc0 += int.Parse(dig[idx]) * 4;
                                break;
                            case 7:
                                calc0 += int.Parse(dig[idx]) * 3;
                                break;
                            case 8:
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
                    dig[9] = string.Format("{0:0}", calc0);
                    calc0 = 0;
                    for (byte idx = 0; idx < 10; idx++)
                    {
                        switch (idx)
                        {
                            case 0:
                                calc0 += int.Parse(dig[idx]) * 11;
                                break;
                            case 1:
                                calc0 += int.Parse(dig[idx]) * 10;
                                break;
                            case 2:
                                calc0 += int.Parse(dig[idx]) * 9;
                                break;
                            case 3:
                                calc0 += int.Parse(dig[idx]) * 8;
                                break;
                            case 4:
                                calc0 += int.Parse(dig[idx]) * 7;
                                break;
                            case 5:
                                calc0 += int.Parse(dig[idx]) * 6;
                                break;
                            case 6:
                                calc0 += int.Parse(dig[idx]) * 5;
                                break;
                            case 7:
                                calc0 += int.Parse(dig[idx]) * 4;
                                break;
                            case 8:
                                calc0 += int.Parse(dig[idx]) * 3;
                                break;
                            case 9:
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
                    dig[10] = string.Format("{0:0}", calc0);
                    if (digDigitado == byte.Parse(dig[9] + dig[10]))
                    {
                        ischanged.Add(string.Format("{0:00000000000}", cpf), true);
                        return true;
                    }
                    else
                    {
                        ischanged.Add(string.Format("{0:00000000000}", cpf), false);
                    }
                }
                else
                {
                    if (ischanged.Where(x => x.Key.Equals(string.Format("{0:00000000000}", cpf)) && x.Value).Any())
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
