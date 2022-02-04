using MarsRover.Services.ServiceRover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.ServicePlateau
{
    public interface IPlateauService
    {
        #region properties
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public IList<IRoverService> Rovers { get; set; }
        #endregion

        #region functions
        bool CreatePlateu(string gridSize);
        void AddRover(IRoverService rover);
        #endregion
    }
}
