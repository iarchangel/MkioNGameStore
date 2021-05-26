using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web.Mvc.Html;

namespace OpenOrderFramework.Models
{
    [Bind(Exclude = "ID")]
    public class Item
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();


        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [DisplayName("Категория")]
        public int CatagorieId { get; set; }

        [Required(ErrorMessage = "Укажите название")]
        [StringLength(160)]
        public string Name { get; set; }



        [Required(ErrorMessage = "Укажите цену")]
        [Range(0.01, 999.99,ErrorMessage = "Цена должна быть от 0,01 до 999,99.")]
        public decimal Price { get; set; }

        public byte[] InternalImage { get; set; }

        [Display(Name = "Локальный файл")]
        [NotMapped]
        public HttpPostedFileBase File
        {
            get
            {
                return null;
            }

            set
            {
                try
                {
                    MemoryStream target = new MemoryStream();

                    if (value.InputStream == null)
                        return;

                    value.InputStream.CopyTo(target);
                    InternalImage = target.ToArray();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    logger.Error(ex.StackTrace);
                }
            }
        }

        [DisplayName("Ссылка на изображенеи")]
        [StringLength(1024)]
        public string ItemPictureUrl { get; set; }

        public virtual Catagorie Catagorie { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}