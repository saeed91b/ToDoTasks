using System;
using Application.Commands;
using FluentValidation;

namespace Application.Validators;

public class CreateTaskValidator : AbstractValidator<CreateTask.Command>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.TaskDTO.Title).NotEmpty().WithMessage("Title must not be empty.").MaximumLength(50).WithMessage("Title can't be longer than 50 characters.");
        RuleFor(x => x.TaskDTO.Description).NotEmpty().WithMessage("Description must not be empty.").MaximumLength(100).WithMessage("Title can't be longer than 50 characters.");
        RuleFor(x => x.TaskDTO.DueDate).GreaterThan(DateTime.UtcNow).WithMessage("Due date must be in the future.");
    }
    
}
