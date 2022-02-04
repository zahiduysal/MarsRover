using MarsRover.Domain.Constant;
using MarsRover.Domain.Enumarations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.ServiceCommand
{
    public class CommandService : ICommandService
    {
        public IList<Commands> CommandList { get; set; }

        public CommandService()
        {
            this.CommandList = new List<Commands>();
        }

        public bool CommandsParse(string commandInput)
        {
            try
            {
                char[] charArr = commandInput.ToCharArray();
                foreach (char ch in charArr)
                {
                    if (Constant.AcceptableCommandCharacters.Contains(ch))
                        CommandList.Add((Commands)Enum.Parse(typeof(Commands), ch.ToString()));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
