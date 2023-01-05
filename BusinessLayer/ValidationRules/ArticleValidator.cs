using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.ArticleName).NotEmpty().WithMessage("Nesne adını bos gecemezsiniz");
            RuleFor(x => x.ArticleQuantity).NotEmpty().WithMessage("Miktarı bos gecemezsiniz");
            RuleFor(x => x.Carbon).NotEmpty().WithMessage("Karbon miktarını bos gecemezsiniz");
            RuleFor(x => x.RecyclType).MaximumLength(20).WithMessage("Lutfen 20 karakterden fazla deger girisi yapmayın");

        }
    }
}
