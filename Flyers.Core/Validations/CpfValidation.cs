using Flyers.Core.Helpers;
using System;
using System.Linq;

namespace Flyers.Core.Validations
{
    public class CpfValidation
    {
        public const int CpfMaxNumeros = 11;
        public string Cpf { get; }

        public CpfValidation(string cpf)
        {
            Cpf = cpf;
        }

        public bool Validar()
        {
            var cpf = Cpf.SomenteNumeros(Cpf);

            try
            {
                long converteCpf = long.Parse(cpf);
                cpf = converteCpf.ToString().PadLeft(11, '0');

                if (cpf.Distinct().Count() == 1)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            if (cpf.Length != 11)
            {
                return false;
            }
            else
            {
                int soma = 0;
                int multiplica = 10;
                string digitoVerificador = cpf.Substring(9, 2);
                int dv1 = 0;
                int dv2 = 0;
                string resultado;

                //Cálculo do primeiro dígito verificador
                for (int i = 0; i < 9; i++)
                {
                    soma += int.Parse(cpf[i].ToString()) * multiplica;
                    multiplica--;

                    if ((soma % 11) < 2)
                    {
                        dv1 = 0;
                    }
                    else
                    {
                        dv1 = 11 - (soma % 11);
                    }
                }

                //Cálculo do segundo dígito verificador
                soma = 0;
                multiplica = 11;
                for (int i = 0; i < 10; i++)
                {
                    soma += Int32.Parse(cpf[i].ToString()) * multiplica;
                    multiplica--;

                    if ((soma % 11) < 2)
                    {
                        dv2 = 0;
                    }
                    else
                    {
                        dv2 = 11 - (soma % 11);
                    }
                }

                //Verifica o número de Cpf
                resultado = (dv1.ToString() + dv2.ToString());
                if (digitoVerificador == resultado)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
