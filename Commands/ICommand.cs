﻿namespace calculator.Commands;

public interface ICommand
{
    void Execute();
    void Undo();
}