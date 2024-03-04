﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CoinyProject.Core.Domain.Entities
{
    public class AlbumElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int AlbumId { get; set; }
        public int AccessibilityId { get; set; }

        public virtual Album Album { get; set; }
        public virtual AlbumElementAccessibility Accessibility { get; set; }
        public virtual Auction Auction { get; set; }
    }
}
