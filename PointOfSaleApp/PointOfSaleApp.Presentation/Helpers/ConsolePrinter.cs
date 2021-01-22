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
                $"Id: {offer.Id}\n" +
                $"Name: {offer.Name}\n" +
                $"Type: {offer.OfferType}\n" +
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

        public static void PrintOfferCategory(OfferCategory offerCategory)
        {
            Console.WriteLine($"Id: {offerCategory.Id} - Name: {offerCategory.Name}\n");
        }

        public static void ShortPrintOffer(int id, Offer offer)
        {
            Console.WriteLine(
                $"Id: {id} - Name: {offer.Name}\n" +
                $"--------------------\n");
        }

        public static void ShortPrintOfferCategories(ICollection<OfferCategory> offerCategories)
        {
            foreach (var offerCategory in offerCategories)
                PrintOfferCategory(offerCategory);
        }

        public static void PrintArticles(ICollection<Article> articles)
        {
            foreach (var article in articles)
                PrintArticle(article);
        }

        internal static void PrintOffers(ICollection<Offer> offers)
        {
            foreach (var offer in offers)
                PrintOffer(offer);
        }

        public static void ShortPrintArticles(ICollection<Article> articles)
        {
            foreach (var article in articles)
                ShortPrintOffer(article.Id, article.Offer);
        }

        public static void ShortPrintServices(ICollection<Service> services)
        {
            foreach (var service in services)
                ShortPrintOffer(service.Id, service.Offer);
        }

        public static void ShortPrintSubscriptions(ICollection<Subscription> subscriptions)
        {
            foreach (var subscription in subscriptions)
                ShortPrintOffer(subscription.Id, subscription.Offer);
        }

        public static void DisplayArticle(Article article)
        {
            PrintOffer(article.Offer);
            Console.WriteLine($"Price: {article.Price}\n");
        }

        public static void DisplayService(Service service)
        {
            PrintOffer(service.Offer);
            Console.WriteLine($"Price per hour: {service.PricePerHour}\n");
            Console.WriteLine($"Working hours needed: {service.WorkingHoursNeeded}\n");
        }

        public static void DisplaySubscription(Subscription subscription)
        {
            PrintOffer(subscription.Offer);
            Console.WriteLine($"Price per day: {subscription.PricePerDay}\n");
        }

        public static void ClearScreenWithSleep()
        {
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
