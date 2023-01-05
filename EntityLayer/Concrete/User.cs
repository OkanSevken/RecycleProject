using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
     public class User:Carbon
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserMail { get; set; }

        [StringLength(50)]
        public string UserPassword { get; set; }

        [StringLength(100)]
        public string UserAdress { get; set; }
        public int TotalCarbon { get; set; }

        public int ArticleID { get; set; }
        public virtual Article Article { get; set; }

    }
}
