﻿using PointOfSaleApp.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSaleApp.Presentation.Helpers
{
    public static class ConsolePrinter
    {
        public static void PrintOffer(Offer offer)
        {
            Console.WriteLine(
                $"Name: {offer.Name}\n" +
                $"Description: {offer.Description}\n" +
                $"Available quantity: {offer.AvailableQuantity}\n");
        }

        public static void PrintArticle(Article article)
        {
            Console.WriteLine($"Id: {article.Id}\n");
            PrintOffer(article.Offer);
            Console.WriteLine($"Price: {article.Price}\n" +
                $"--------------------\n");
        }        
        
        public static void ShortPrintOffer(int id, Offer offer)
        {
            Console.WriteLine(
                $"Id: {id} - Name: {offer.Name}\n" +
                $"--------------------\n");
        }

        public static void PrintArticles(ICollection<Article> articles)
        {
            foreach (var article in articles)
                PrintArticle(article);
        }

        public static void ShortPrintArticles(ICollection<Article> articles)
        {
            foreach (var article in articles)
                ShortPrintOffer(article.Id, article.Offer);
        }

        public static void DisplayArticle(Article article)
        {
            PrintOffer(article.Offer);
            Console.WriteLine($"Price: {article.Price}\n");
        }

        public static void ClearScreenWithSleep()
        {
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
