using MarsRover.Common.Validation;
using MarsRover.Services.ServiceRover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.ServicePlateau
{
    public class PlateauService : IPlateauService
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public IList<IRoverService> Rovers { get; set; }

        public void AddRover(IRoverService rover)
        {
            this.Rovers.Add(rover);
        }

        public bool CreatePlateu(string gridSize)
        {
            if (ValidationHelper.StringIsNullOrEmpty(gridSize))
                return false;
            else
                return gridOperation(gridSize); 
        }

        private bool gridOperation(string gridSize)
        {
            try
            {
                this.XCoordinate = Convert.ToInt32(gridSize.Split(' ')[0].ToString());
                this.YCoordinate = Convert.ToInt32(gridSize.Split(' ')[1].ToString());
                this.Rovers = new List<IRoverService>();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
