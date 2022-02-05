using MarsRover.Common.Logger;
using MarsRover.Services.ServicePlateau;
using MarsRover.Services.ServiceRover;
using System;
using System.Runtime.Caching;

namespace MarsRover.App.Operations
{
    class MoveOperations : IMoveOperations
    {
        readonly MemoryCache _memoryCache;
        
        public MoveOperations()
        {
            this._memoryCache = new MemoryCache("MarsRover_MoveOperations");
        }

        public void Run(ILogger _logger, IPlateauService _plateauService)
        {
            _logger.writeLog("");
            _logger.writeLog("Expected Output: ");
            foreach (IRoverService rover in _plateauService.Rovers)
            {
                string key = GetKey(rover);
                string cacheVal = GetCache(key);
                if (string.IsNullOrEmpty(cacheVal))
                {
                    string output = rover.Process(rover);
                    _logger.writeLog(output);
                    SetCache(key, output);
                }
                else
                    _logger.writeLog(cacheVal);
            }
        }

        private string GetKey(IRoverService rover)
        {
            string commands = null;
            foreach (var item in rover.RoverCommands.CommandList)
                commands += item.ToString(); 

            return $"{rover.RoverPlateau.XCoordinate}_{rover.RoverPlateau.YCoordinate}_{rover.RoverPosition.X}_" +
                $"{rover.RoverPosition.Y}_{rover.RoverPosition.Direction}_" + commands;
        }

        private string GetCache(string key)
        {
            try
            {
                var result = _memoryCache.GetCacheItem(key);
                string strVal = result != null ? result.Value.ToString() : null;
                return strVal;
            }
            catch
            {
                return null;
            }
        }

        private void SetCache(string key, string value)
        {
            _memoryCache.Set(key, value,
                new CacheItemPolicy()
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                    Priority = CacheItemPriority.Default
                });
        }
    }
}
