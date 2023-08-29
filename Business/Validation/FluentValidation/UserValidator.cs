using Business.Contants;
using Core.Entities.Concrete.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
	public class UserValidator:AbstractValidator<User>
	{
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(Messages.FirstNameNotEmpty);
            RuleFor(u => u.LastName).NotEmpty().WithMessage(Messages.LastNameNotEmpty);
			RuleFor(u => u.Email).NotEmpty().WithMessage(Messages.EmailNotEmpty);
            RuleFor(u => u.Email).EmailAddress().WithMessage(Messages.NotEmailFormat);
        }
    }
}
