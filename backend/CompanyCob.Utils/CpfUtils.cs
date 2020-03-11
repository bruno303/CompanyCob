using System;

namespace CompanyCob.Utils
{
    public static class CpfUtils
    {
        public static bool ValidarCpf(long cpf)
        {
            string numbers = cpf.ToString().PadLeft(11, '0');
            if (numbers.Length != 11)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(numbers.Replace(numbers[0], ' ').Trim()))
            {
                return false;
            }

            var numberInts = new int[11];

            for (int i = 0; i < 11; i++)
            {
                numberInts[i] = Convert.ToInt32(numbers[i].ToString());
            }

            int soma1 = 0, soma2 = 0;

            for (int i = 0; i < 10; i++)
            {
                soma1 += (i < 9) ? (numberInts[i] * (10 - i)) : 0;
                soma2 += numberInts[i] * (11 - i);
            }

            int resto1 = Mod11(soma1);
            int resto2 = Mod11(soma2);

            return resto1 == numberInts[9] &&
                   resto2 == numberInts[10];
        }

        private static int Mod11(int soma)
        {
            int digito = soma % 11;
            return (digito < 2) ? 0 : 11 - digito;
        }
    }
}
