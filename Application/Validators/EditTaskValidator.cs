using System;
using Application.Commands;
using FluentValidation;

namespace Application.Validators;

public class EditTaskValidator : AbstractValidator<EditTask.Command>
{
    public EditTaskValidator()
    {
        RuleFor(x => x.TaskDTO.Id).NotEmpty().WithMessage("Id must not be empty.");
        RuleFor(x => x.TaskDTO.Title).NotEmpty().WithMessage("Title must not be empty.").MaximumLength(50).WithMessage("Title can't be longer than 50 characters.");
        RuleFor(x => x.TaskDTO.Description).NotEmpty().WithMessage("Description must not be empty.").MaximumLength(100).WithMessage("Title can't be longer than 50 characters.");
        RuleFor(x => x.TaskDTO.DueDate).GreaterThan(DateTime.UtcNow).WithMessage("Due date must be in the future.");
        RuleFor(x => x.TaskDTO.IsCompleted).NotNull().WithMessage("IsCompleted can not be null.");
    }
}
