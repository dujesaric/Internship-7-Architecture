﻿using Microsoft.EntityFrameworkCore;
using PointOfSaleApp.Data.Entities;
using PointOfSaleApp.Data.Entities.Models;
using PointOfSaleApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSaleApp.Domain.Repositories.BillRepositories
{
    public class BillItemRepository : BaseRepository
    {
        public BillItemRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public (ResponseResultType Response, BillItem BillItem) Add(int billId, int offerId)
        {
            var billItem = new BillItem
            {
                BillId = billId,
                OfferId = offerId,
                Quantity = 0
            };

            DbContext.BillItems.Add(billItem);
            
            return (SaveChanges(), billItem);
        }

        public BillItem GetById(int itemId)
        {
            return DbContext.BillItems
                .Where(bi => bi.Id == itemId)
                .FirstOrDefault();
        }

        public BillItem GetByOfferIdAndBillId(int offerId, int billId)
        {
            return DbContext.BillItems
                .Where(bi => bi.OfferId == offerId)
                .Where(bi => bi.BillId == billId)
                .FirstOrDefault();
        }

        public (ResponseResultType Respone, int IncreasedQuantity) IncreaseQuantityByIdFor(int id, int additionalQuantity)
        {
            var billItem = DbContext.BillItems
                .Include(bi => bi.Offer)
                .Where(bi => bi.Id == id)
                .FirstOrDefault();

            var offer = billItem.Offer;

            if (billItem == null || offer == null)
                return (ResponseResultType.NotFound, 0);

            var increasingQuantity = (additionalQuantity < offer.AvailableQuantity)
                ? additionalQuantity
                : offer.AvailableQuantity;

            billItem.Quantity += increasingQuantity;
            offer.AvailableQuantity -= increasingQuantity;
            offer.SoldQuantity += increasingQuantity;

            return (SaveChanges(), increasingQuantity);
        }

        public ICollection<BillItem> GetAllByBillId(int billId)
        {
            return DbContext.BillItems
                .Include(bi => bi.Offer)
                .Include(bi => bi.Bill)
                .Where(bi => bi.BillId == billId)
                .ToList();
        }

        public int CountByBillId(int id)
        {
            return DbContext.BillItems
                .Include(bi => bi.Offer)
                .Include(bi => bi.Bill)
                .Where(bi => bi.BillId == id)
                .Count();
        }
    }
}
