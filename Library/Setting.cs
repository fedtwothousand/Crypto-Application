﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MlkPwgen;

namespace Library
{
    public static class Setting
    {
        public static List<CryptoModelList> m = new List<CryptoModelList>();
        public static List<WalletModelList> wallet = new List<WalletModelList>();
        public static List<string> names = new List<string>() { "LTC Litecoin", "DOGE Dogecoin", "BTC Bitcoin", "ETH Ethereum" };
        public static System.Random r = new System.Random();
        public static int x = 900, z = 3000, y, w;
        public static string name, price, confirm;
        public static double p;

        public static void AddCustomListing(List<CryptoModelList> obj)
        {
            Console.Clear();

            Console.Write("You are adding a new listing.\nWhat will be your coin name?: ");
            name = Console.ReadLine();

            Console.Write($"What will be your first bid to '{name}': ");
            price = Console.ReadLine();
            p = double.Parse(price);

            Console.WriteLine($"\nYour listing will be:\nCrypto: {name}\nFirst bid: {p}");
            Console.Write("\ncrypto@do-you-confirm? yes/no: ");
            confirm = Console.ReadLine();

            if (confirm == "yes")
            {
                obj.Add(new CryptoModelList
                {
                    Id = y,
                    Name = name,
                    Price = p
                });

                Crypto.ShowListing(obj);
            }
            else
            {
                Console.Clear();
                Crypto.ShowListing(obj);
            }
        }

        public static List<CryptoModelList> AddListing()
        {
            for (int i = 0; i < 4; i++)
            {
                y = r.Next(x);
                w = r.Next(z);
                m.Add(new CryptoModelList
                {
                    Id = y,
                    Name = names[i],
                    Price = w
                });
            }
            return m;
        }

        public static void CalculateVariation(CryptoModelList variation, double x, double y)
        {
            double result = x - (y / x) * 100;
            variation.Variation = result;
            m.Add(variation);
        }

        public static List<WalletModelList> CryptoAddress()
        {
            var Key = PasswordGenerator.Generate(length: 64, allowed: Sets.Alphanumerics);

            wallet.Add(new WalletModelList
            {
                Key = Key
            });

            return wallet;
        }
    }
}
