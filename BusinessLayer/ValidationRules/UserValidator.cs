using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş gecemezsiniz");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Kullanıcı mailini boş gecemezsiniz");
            RuleFor(x => x.UserAdress).NotEmpty().WithMessage("Adres kısmını boş gecemezsiniz");
            RuleFor(x => x.UserPassword).MaximumLength(20).WithMessage("Lutfen en fazla 20 karakterli giris yapınız");    
        }
            
    }
}
