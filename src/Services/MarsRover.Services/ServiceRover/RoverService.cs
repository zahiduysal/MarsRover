using MarsRover.Domain.Enumarations;
using MarsRover.Services.ServiceCommand;
using MarsRover.Services.ServicePlateau;
using MarsRover.Services.ServicePosition;
using System;

namespace MarsRover.Services.ServiceRover
{
    public class RoverService : IRoverService
    {
        #region properties
        public IPositionService RoverPosition { get; set; }
        public IPlateauService RoverPlateau { get; set; }
        public ICommandService RoverCommands { get; set; }

        #endregion

        #region constructor

        public RoverService(IPositionService roverPosition, IPlateauService plateau, ICommandService roverCommands)
        {
            this.RoverPosition = roverPosition;
            this.RoverPlateau = plateau;
            this.RoverCommands = roverCommands;
        }

        #endregion

        #region functions
        public string Process(IRoverService rover)
        {
            foreach (Commands command in rover.RoverCommands.CommandList)
                rover.RoverPosition = ProcessCommand(command, rover.RoverPosition);

            string finalX = rover.RoverPosition.X.ToString();
            string finalY = rover.RoverPosition.Y.ToString();
            string finalDirection = rover.RoverPosition.Direction.ToString();

            return finalX + " " + finalY + " " + finalDirection;
        }

        private IPositionService ProcessCommand(Commands command, IPositionService roverPosition)
        {
            switch (command)
            {
                case Commands.M:
                    return MoveCommand(roverPosition);
                case Commands.L:
                    return MoveLeft(roverPosition);
                case Commands.R:
                    return MoveRight(roverPosition);
                default:
                    break;
            }
            return roverPosition;
        }

        private IPositionService MoveCommand(IPositionService positionMove)
        {
            CheckPosition(positionMove.X, positionMove.Y);

            switch (positionMove.Direction)
            {
                case Directions.N:
                    positionMove.X = positionMove.X;
                    positionMove.Y = positionMove.Y + 1;
                    break;
                case Directions.S:
                    positionMove.X = positionMove.X;
                    positionMove.Y = positionMove.Y - 1;
                    break;
                case Directions.W:
                    positionMove.X = positionMove.X - 1;
                    positionMove.Y = positionMove.Y;
                    break;
                case Directions.E:
                    positionMove.X = positionMove.X + 1;
                    positionMove.Y = positionMove.Y;
                    break;
                default:
                    break;
            }
            return positionMove;
        }

        private IPositionService MoveLeft(IPositionService positionLeft)
        {
            switch (positionLeft.Direction)
            {
                case Directions.N:
                    positionLeft.Direction = Directions.W;
                    break;
                case Directions.S:
                    positionLeft.Direction = Directions.E;
                    break;
                case Directions.W:
                    positionLeft.Direction = Directions.S;
                    break;
                case Directions.E:
                    positionLeft.Direction = Directions.N;
                    break;
                default:
                    break;
            }
            return positionLeft;
        }

        private IPositionService MoveRight(IPositionService positionRight)
        {
            switch (positionRight.Direction)
            {
                case Directions.N:
                    positionRight.Direction = Directions.E;
                    break;
                case Directions.S:
                    positionRight.Direction = Directions.W;
                    break;
                case Directions.W:
                    positionRight.Direction = Directions.N;
                    break;
                case Directions.E:
                    positionRight.Direction = Directions.S;
                    break;
                default:
                    break;
            }
            return positionRight;
        }

        private void CheckPosition(int X, int Y)
        {
            if (X < 0 || Y < 0
                || this.RoverPlateau.XCoordinate < X
                || this.RoverPlateau.YCoordinate < Y)
                throw new Exception("Gezici plato dışına çıktı!");
        }

        #endregion
    }
}
