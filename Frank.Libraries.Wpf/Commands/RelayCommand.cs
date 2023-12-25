﻿using System.Windows.Input;

namespace Frank.Libraries.Wpf.Commands;

public class RelayCommand(Action<object> execute, Predicate<object>? canExecute = null) : ICommand
{
    private readonly Action<object> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter) => parameter != null && (canExecute == null || canExecute(parameter));

    public void Execute(object? parameter)
    {
        if (parameter != null) _execute(parameter);
    }
}