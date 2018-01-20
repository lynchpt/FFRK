using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IEventsLogic
    {
    }

    public class EventsLogic : IEventsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<EventsLogic> _logger;
        #endregion

        #region Constructors

        public EventsLogic(IEnlirRepository enlirRepository, ILogger<EventsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IEventsLogic Implementation

        #endregion
    }
}
