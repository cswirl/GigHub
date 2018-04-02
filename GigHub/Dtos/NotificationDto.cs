using GigHub.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Dtos
{
    public class NotificationDto
    {
        public DateTime DateTime { get;  set; }
        public NotificationType Type { get;  set; }

        //The '?' means nullable. In convention, string is nullable so we don't need to declare it
        public DateTime? OriginalDateTime { get;  set; }
        public string OriginalVenue { get;  set; }


        public GigDto Gig { get;  set; }
    }
}