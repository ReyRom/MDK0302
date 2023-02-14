using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR6
{
    internal class RSA
    {
        private int d;
        private int e;
        private int n;
        public int E { get => e; }
        public int N { get => n; }
        public int D { get => d; }

        public RSA()
        {
            GenerateKey();
        }
        public RSA(int e, int d, int n)
        {
            this.e = e;
            this.d = d;
            this.n = n;
        }

        public byte[] Encrypt(byte[] data, int e = 0, int n = 0)
        {
            if (e == 0 && n == 0) {  e = this.e; n = this.n; }
            ushort[] message = data.Select(o => (ushort)o).ToArray();
            byte[] encrypted = new byte[message.Length * 2];
            for (int i = 0; i < message.Length; i++)
            {
                Crypt(BitConverter.GetBytes(message[i]), e, n).CopyTo(encrypted, i * 2);
            }
            return encrypted;
        }

        public byte[] Decrypt(byte[] encrypted)
        {
            ushort[] decrypted = new ushort[encrypted.Length / 2];
            for (int i = 0; i < encrypted.Length / 2; i++)
            {
                decrypted[i] = BitConverter.ToUInt16(Crypt(encrypted.Skip(2 * i).Take(2).ToArray(), d, n));
            }
            return decrypted.Select(o => (byte)o).ToArray();
        }

        void GenerateKey()
        {
            int[] primes = Sieve(1000);
            Random random = new Random();
            int p = primes[random.Next(primes.Length)];
            int q;
            do
            {
                q = primes[random.Next(primes.Length)];
            } while (p == q || p * q < 255 || p * q > 65535);

            n = p * q;
            d = 0;
            e = 0;
            int fi = Euler(p, q);
            int x, y;
            for (int i = fi; i > 2; i--)
            {
                if (GCD(i, fi, out x, out y) == 1)
                {
                    e = i;
                    d = (x % fi + fi) % fi;
                    break;
                }
            }
        }

        private static byte[] Crypt(byte[] data, int key, int n)
        {
            ushort m = BitConverter.ToUInt16(data);
            long result = 1;
            long bit = m % n;

            while (key > 0)
            {
                if ((key & 1) == 1)
                {
                    result *= bit;
                    result %= n;
                }
                bit *= bit;
                bit %= n;
                key >>= 1;
            }
            return BitConverter.GetBytes((ushort)result);
        }

        private static int[] Sieve(int n)
        {
            int[] S = Enumerable.Range(0, n + 1).ToArray();

            S[1] = 0;

            for (int k = 2; k * k <= n; k++)
            {
                if (S[k] != 0)
                {
                    for (int l = k * k; l <= n; l += k)
                    {
                        S[l] = 0;
                    }
                }
            }
            return S.Where(x => x != 0).ToArray();
        }

        private static int Euler(int p, int q)
        {
            return (p - 1) * (q - 1);
        }

        private static int GCD(int a, int b, out int x, out int y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }
            int x1, y1;
            int d = GCD(b % a, a, out x1, out y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;
        }
    }
}
