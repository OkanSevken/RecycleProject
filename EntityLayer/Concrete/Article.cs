using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Article:Carbon
    {
        [Key]
        public int ArticleID { get; set; }

        [StringLength(50)]
        public string ArticleName { get; set; }
        public int ArticleQuantity { get; set; }
        public int Carbon { get; set; }

        [StringLength(50)]
        public string RecyclType { get; set; }
        public ICollection<User> Users { get; set; }


    }
}
