using MarsRover.Domain.Enumarations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.ServiceCommand
{
    public interface ICommandService
    {
        #region properties
        IList<Commands> CommandList { get; set; }
        #endregion

        #region functions
        bool CommandsParse(string commandInput);
        #endregion
    }
}
