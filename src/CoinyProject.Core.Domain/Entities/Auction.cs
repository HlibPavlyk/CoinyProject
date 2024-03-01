﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinyProject.Core.Domain.Entities
{
    public class Auction
    {
        public int Id { get; set; }
        public AlbumElement Lot { get; set; }
        public AuctionBet AuctionBet { get; set; }
        public float StartPrice { get; set; }
        public float BetDelta { get; set; } 
        public DateTime StartTime { get; set; }
        public DateTime ExpirationTime { get; set; }
        public bool IsSoldEarlier { get; set; }
    }
}
