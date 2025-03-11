namespace TaskBooking.Application.CommandQuery.Command;

public abstract class Validator<T> : AbstractValidator<T> where T : CategoryDTO
{
    public Validator()
    {
        RuleFor(TaskBooking => TaskBooking.Name)
           .NotEmpty().WithMessage("Name is required.");

        RuleFor(TaskBooking => TaskBooking.UrlHandle)
            .NotEmpty().WithMessage("UrlHandle is required.");
                 
    }
    
}

