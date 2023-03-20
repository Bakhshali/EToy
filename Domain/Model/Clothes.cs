using Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Model
{
    public class Clothes : BaseEntity
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string StockCode { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required, MaxLength(50)]
        public string Phone { get; set; }

        public bool IsNew { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DailyPrice { get; set; }

        [Required]
        public string About { get; set; }

        public CategoryOfClothes Category { get; set; }
        public Guid CategoryId { get; set; }

        public Gender Gender { get; set; }
        public Guid GenderId { get; set; }

        public Industrial Industrial { get; set; }
        public Guid IndustrialId { get; set; }

        public ModelOfClothes Model { get; set; }
        public Guid? ModelId { get; set; }

        public Store Store { get; set; }
        public Guid StoreId { get; set; }

        public Discount Discount { get; set; }
        public Guid? DiscountId { get; set; }

        public Textile Textile { get; set; }
        public Guid? TextileId { get; set; }

        public Neckline Neckline { get; set; }
        public Guid? NecklineId { get; set; }

        public Silhouette Silhouette { get; set; }
        public Guid? SilhouetteId { get; set; }

        public ICollection<ClothesColor> ColorOfClothes { get; set; }
        public ICollection<ClothesSize> SizeOfClothes { get; set; }

        [NotMapped]
        public ICollection<IFormFile> Images { get; set; }

        public ICollection<PalaceImage> ImagesOfPalace { get; set; }


    }
}
